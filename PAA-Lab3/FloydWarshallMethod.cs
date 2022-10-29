namespace PAA_Lab3
{
    public class FloydWarshallMethod : IMethod
    {
        public string Name => "Floyd-Warshall";

        public double[] GetShortestPaths(Graph graph, int source)
        {
            return GetShortestPaths(graph)[source];
        }

        public double[][] GetShortestPaths(Graph graph)
        {
            var d = Enumerable
                .Range(0, graph.VerticesCount)
                .Select(n =>
                    Enumerable
                    .Repeat(double.PositiveInfinity, graph.VerticesCount)
                    .ToArray())
                .ToArray();

            foreach (Edge edge in graph.Edges)
            {
                d[edge.Start][edge.End] = edge.Weight;
            }
            for (int i = 0; i < graph.VerticesCount; i++)
            {
                d[i][i] = 0.0;
            }

            for (int k = 0; k < graph.VerticesCount; k++)
            {
                for (int i = 0; i < graph.VerticesCount; i++)
                {
                    for (int j = 0; j < graph.VerticesCount; j++)
                    {
                        d[i][j] = Math.Min(d[i][j], d[i][k] + d[k][j]);
                    }
                }
            }
            return d;
        }
    }
}
