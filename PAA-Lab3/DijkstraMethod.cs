using System.Collections;

namespace PAA_Lab3
{
    public class DijkstraMethod : IPathFindingMethod
    {
        public string Name => "Dijkstra";

        private double[] GetShortestPaths(Graph graph, int source)
        {
            var d = Enumerable
                .Repeat(double.PositiveInfinity, graph.VerticesCount)
                .ToArray();
            d[source] = 0.0;

            PriorityQueue<int, double> pq = new();
            pq.Enqueue(source, d[source]);

            BitArray visited = new(graph.VerticesCount, false);

            while (pq.Count > 0)
            {
                int u = pq.Dequeue();

                if (visited[u])
                {
                    continue;
                }
                visited[u] = true;

                foreach (Edge edge in graph.GetIncidentEdges(u))
                {
                    double alt = d[u] + edge.Weight;
                    if (d[edge.End] > alt)
                    {
                        d[edge.End] = alt;
                        pq.Enqueue(edge.End, d[edge.End]);
                    }
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
