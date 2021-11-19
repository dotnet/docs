using System.Collections.Concurrent;

namespace WorkerScope.Example;

internal class ObjectWorkerService :
    IObjectProcessor,
    IObjectRelay,
    IObjectStore
{
    static readonly Random s_random = new((int)DateTime.Now.Ticks);
    static readonly ConcurrentDictionary<int, ObjectGraph> s_objects = new();

    static int NextRandomDelay => s_random.Next(250, 3000);

    readonly IObjectIdProvider _objectIdProvider;

    public ObjectWorkerService(ILogger<ObjectWorkerService> logger, IServiceProvider serviceProvider)
    {
        _objectIdProvider = serviceProvider.GetRequiredService<IObjectIdProvider>();

        logger.LogInformation(
            "ObjectWorkerService's provider hash: {hash}",
            serviceProvider.GetHashCode());
    }

    public async Task<ObjectGraph> GetNextAsync()
    {
        await Task.Delay(NextRandomDelay);

        var id = _objectIdProvider.GetNextId();

        return s_objects.GetOrAdd(id, _ => new(id, $"Object #{id}"));
    }

    public int GetNextId() => s_objects.Count + 1;

    public async Task<ObjectGraph> MarkAsync(ObjectGraph obj)
    {
        await Task.Delay(NextRandomDelay);

        return s_objects.TryUpdate(obj.Id, obj with { IsProcessed = true }, obj) &&
            s_objects.TryGetValue(obj.Id, out ObjectGraph updatedObject)
            ? updatedObject
            : obj;
    }

    public Task ProcessAsync(ObjectGraph obj) => Task.Delay(NextRandomDelay);

    public Task RelayAsync(ObjectGraph obj) => Task.Delay(NextRandomDelay);
}
