namespace WorkerScope.Example;

interface IObjectRelay
{
    Task RelayAsync(ObjectGraph obj);
}
