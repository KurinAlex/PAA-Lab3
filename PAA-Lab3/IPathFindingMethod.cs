namespace PAA_Lab3
{
    public interface IPathFindingMethod
    {
        string Name { get; }
        double[][] GetShortestPaths(Graph graph);
    }
}
