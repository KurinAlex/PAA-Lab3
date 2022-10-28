namespace PAA_Lab3
{
    public interface IMethod
    {
        string Name { get; }
        double GetShortestPath(Graph graph, int source, int destination);
        double[] GetShortestPaths(Graph graph, int source);
        double[][] GetShortestPaths(Graph graph);
    }
}
