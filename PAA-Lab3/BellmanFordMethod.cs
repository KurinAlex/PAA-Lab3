namespace PAA_Lab3
{
    public class BellmanFordMethod : IMethod
    {
        public string Name => "Bellman-Ford";

        public double[] GetShortestPaths(Graph graph, int source)
        {
            var d = Enumerable
                .Repeat(double.PositiveInfinity, graph.VerticesCount)
                .ToArray();
            d[source] = 0.0;

            for (int i = 1; i < graph.VerticesCount; i++)
            {
                foreach (Edge edge in graph.Edges)
                {
                    d[edge.End] = Math.Min(d[edge.End], d[edge.Start] + edge.Weight);
                }
            }
            return d;
        }

        public double[][] GetShortestPaths(Graph graph)
        {
            return Enumerable.Range(0, graph.VerticesCount)
                .Select(i => GetShortestPaths(graph, i))
                .ToArray();
        }
    }
}
