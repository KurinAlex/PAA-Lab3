using System.Diagnostics;

namespace PAA_Lab3
{
    public class Program
    {
        const string InputFolderPath = @"D:\Sources\University\2 course\PAA\PAA-Lab3\Input";
        const string AdjacencyMatrixFileName = "adjacency.txt";
        const string WeightsMatrixFileName = "weights.txt";

        static readonly string adjacencyMatrixFilePath = Path.Combine(InputFolderPath, AdjacencyMatrixFileName);
        static readonly string weightsMatrixFilePath = Path.Combine(InputFolderPath, WeightsMatrixFileName);

        static readonly IPathFindingMethod[] methods = {
            new BellmanFordMethod(),
            new DijkstraMethod(),
            new FloydWarshallMethod(),
            new JohnsonMethod()
        };

        static void WriteDivider()
        {
            Console.WriteLine(new string('-', 59));
        }

        static void Main(string[] args)
        {
            try
            {
                List<double[][]> results = new(methods.Length);

                int[][] adjacencyMatrix = ArrayHelper.ReadFromFile<int>(adjacencyMatrixFilePath);
                double[][] weightsMatrix = ArrayHelper.ReadFromFile<double>(weightsMatrixFilePath);
                Graph graph = new(adjacencyMatrix, weightsMatrix);


                foreach (IPathFindingMethod method in methods)
                {
                    WriteDivider();
                    Console.WriteLine($"{method.Name} method:");
                    WriteDivider();

                    var stopwatch = Stopwatch.StartNew();
                    var result = method.GetShortestPaths(graph);
                    stopwatch.Stop();

                    Console.WriteLine($"Result:");
                    ArrayHelper.WriteArray(result);
                    WriteDivider();

                    Console.WriteLine("Computation time:");
                    Console.WriteLine($"{stopwatch.Elapsed.TotalMilliseconds} ms");
                    WriteDivider();

                    results.Add(result);
                }

                WriteDivider();
                Console.WriteLine("All results are equal:");
                Console.WriteLine(ArrayHelper.AreArraysEqual(results));
                WriteDivider();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}