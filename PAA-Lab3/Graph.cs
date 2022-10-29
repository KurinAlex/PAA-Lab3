namespace PAA_Lab3
{
    public class Graph
    {
        private int _verticesCount;
        private readonly HashSet<Edge> _edges;

        public Graph(int[][] adjacency, double[][] weights)
        {
            int n = adjacency.Length;
            _verticesCount = n;
            _edges = new();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (adjacency[i][j] == 1)
                    {
                        _edges.Add(new(i, j, weights[i][j]));
                    }
                }
            }
        }
        public Graph(Graph graph)
        {
            _verticesCount = graph._verticesCount;
            _edges = new(graph._edges);
        }

        public int VerticesCount => _verticesCount;
        public IEnumerable<Edge> Edges => _edges;

        public int AddVertice()
        {
            int v = _verticesCount++;
            for (int i = 0; i < _verticesCount - 1; i++)
            {
                Edge newEdge = new(v, i, 0.0);
                _edges.Add(newEdge);
            }
            return v;
        }
        public IEnumerable<Edge> GetIncidentEdges(int start)
        {
            return _edges.Where(e => e.Start == start);
        }
        public void RemoveVertice(int v)
        {
            _edges.RemoveWhere(e => e.Start == v || e.End == v);
            _verticesCount--;
        }
    }
}
