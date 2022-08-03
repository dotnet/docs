static string GetArg(
    string[] args, int index, string defaultValue) =>
    args?.Length > index ? args[index] : defaultValue;

var isBounded = false;
var gps = isBounded
    ? CreateBounded(10)
    : CreateUnbounded();

var producer = GetArg(args, 0, "waittowrite");
var producerMap =
    new Dictionary<string, Func<ChannelWriter<Coordinates>, Coordinates, ValueTask>>(
        StringComparer.OrdinalIgnoreCase)
    {
        ["whilewrite"] = ProduceWithWhileWriteAsync,
        ["waittowrite"] = ProduceWithWaitToWriteAsync
    };
var consumer = GetArg(args, 1, "awaitforeach");
var consumerMap =
    new Dictionary<string, Func<ChannelReader<Coordinates>, ValueTask>>(
        StringComparer.OrdinalIgnoreCase)
    {
        ["nestedwhile"] = ConsumeWithNestedWhileAsync,
        ["awaitforeach"] = ConsumeWithAwaitForeachAsync,
        ["whiletrue"] = ConsumeWithWhileAsync,
        ["waittoread"] = ConsumeWithWhileWaitToReadAsync
    };

var produceCooridnatesAsync = producerMap[producer];
var consumeCoordinatesAsync = consumerMap[consumer];

var initialCoordinates = new Coordinates(
    DeviceId: Guid.NewGuid(),
    Latitude: -90,
    Longitude: -180);

using (LoggingStopwatch.WriteDurationToConsole())
{
    await Task.WhenAll(
        produceCooridnatesAsync(gps.Writer, initialCoordinates).AsTask(),
        consumeCoordinatesAsync(gps.Reader).AsTask());
}
