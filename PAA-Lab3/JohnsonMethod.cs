namespace PAA_Lab3
{
    public class JohnsonMethod : IMethod
    {
        public string Name => "Johnson";

        public double GetShortestPath(Graph graph, int source, int destination)
        {
            return GetShortestPaths(graph)[source][destination];
        }

        public double[] GetShortestPaths(Graph graph, int source)
        {
            return GetShortestPaths(graph)[source];
        }

        public double[][] GetShortestPaths(Graph graph)
        {
            Graph newGraph = new(graph);
            int q = newGraph.AddVertice();

            BellmanFordMethod bellmanFord = new();
            var h = bellmanFord.GetShortestPaths(newGraph, q);

            foreach (Edge edge in newGraph.Edges)
            {
                edge.Weight = edge.Weight + h[edge.Start] - h[edge.End];
            }
            newGraph.RemoveVertice(q);

            DijkstraMethod dijkstra = new();
            var d = dijkstra.GetShortestPaths(newGraph);
            for (int i = 0; i < d.Length; i++)
            {
                for (int j = 0; j < d[i].Length; j++)
                {
                    d[i][j] += h[j] - h[i];
                }
            }
            return d;
        }
    }
}
