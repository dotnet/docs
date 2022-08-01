// <createunbounded>
var gps = Channel.CreateUnbounded<Coordinates>();
// </createunbounded>

var producer = args is { Length: > 0 } ? args[0] : "waittoreach";
var consumer = args is { Length: > 1 } ? args[1] : "waittoreach";

var producerMap =
    new Dictionary<string, Func<ChannelWriter<Coordinates>, Coordinates, ValueTask>>(
        StringComparer.OrdinalIgnoreCase)
    {
        ["whilewrite"] = ProduceWithWhileWriteAsync,
        ["waittowrite"] = ProduceWithWaitToWriteAsync
    };
var consumerMap =
    new Dictionary<string, Func<ChannelReader<Coordinates>, ValueTask>>(
        StringComparer.OrdinalIgnoreCase)
    {
        ["nestedwhile"] = ConsumeWithNestedWhileAsync,
        ["awaitforeach"] = ConsumeWithAwaitForeachAsync,
        ["while"] = ConsumeWithWhileAsync,
        ["waittoreach"] = ConsumeWithWhileWaitToReadAsync
    };
var consumeCoordinatesAsync = consumerMap[decision];

var coordinates = new Coordinates(
    DeviceId: Guid.NewGuid(),
    Latitude: -90,
    Longitude: -180);

var sw = Stopwatch.StartNew();
await Task.WhenAll(
    ProduceWithWhileWriteAsync(gps.Writer, coordinates).AsTask(),
    consumeCoordinatesAsync(gps.Reader).AsTask());

sw.Stop();
Console.WriteLine($"Finished in: {sw.Elapsed}");
