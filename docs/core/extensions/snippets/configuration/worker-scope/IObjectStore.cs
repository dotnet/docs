namespace WorkerScope.Example;

interface IObjectStore
{
    Task<ObjectGraph> GetNextAsync();

    Task<ObjectGraph> MarkAsync(ObjectGraph graph);
}
