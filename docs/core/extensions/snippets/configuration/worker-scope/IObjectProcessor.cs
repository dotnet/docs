namespace WorkerScope.Example;

interface IObjectProcessor
{
    Task ProcessAsync(ObjectGraph obj);
}
