namespace PAA_Lab3
{
    public interface IMethod
    {
        string Name { get; }
        double[] GetShortestPaths(Graph graph, int source);
        double[][] GetShortestPaths(Graph graph);
    }
}
