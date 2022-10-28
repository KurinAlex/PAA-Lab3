namespace PAA_Lab3
{
    public class Edge
    {
        public Edge(int start, int end, double weight)
        {
            Start = start;
            End = end;
            Weight = weight;
        }

        public int Start { get; init; }
        public int End { get; init; }
        public double Weight { get; init; }
    }
}
