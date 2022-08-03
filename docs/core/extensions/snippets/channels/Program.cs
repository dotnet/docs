bool isBounded = false;
Channel<Coordinates> gps = isBounded
    ? CreateBounded(10)
    : CreateUnbounded();

string producer = args?.Length > 0 ? args[0] : "waittowrite";
Func<ChannelWriter<Coordinates>, Coordinates, ValueTask> produceCooridnatesAsync = producer switch
{
    "whilewrite" => ProduceWithWhileWriteAsync,
    "waittowrite" => ProduceWithWaitToWriteAsync,

    _ => ProduceWithWhileWriteAsync
};

string consumer = args?.Length > 1 ? args[1] : "awaitforeach";
Func<ChannelReader<Coordinates>, ValueTask> consumeCoordinatesAsync = consumer switch
{
    "nestedwhile" => ConsumeWithNestedWhileAsync,
    "awaitforeach" => ConsumeWithAwaitForeachAsync,
    "whiletrue" => ConsumeWithWhileAsync,
    "waittoread" => ConsumeWithWhileWaitToReadAsync,

    _ => ConsumeWithAwaitForeachAsync
};

Coordinates initialCoordinates = new(
    DeviceId: Guid.NewGuid(),
    Latitude: -90,
    Longitude: -180);

using (LoggingStopwatch.WriteDurationToConsole())
{
    await Task.WhenAll(
        produceCooridnatesAsync(gps.Writer, initialCoordinates).AsTask(),
        consumeCoordinatesAsync(gps.Reader).AsTask());
}
