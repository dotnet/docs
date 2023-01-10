bool isBounded = true;
Channel<Coordinates> gps = isBounded
    ? CreateBounded()
    : CreateUnbounded();

string producer = args?.Length > 0 ? args[0] : "whilewrite";
Func<ChannelWriter<Coordinates>, Coordinates, ValueTask> produceCoordinatesAsync = producer switch
{
    "whilewrite" => ProduceWithWhileWriteAsync,
    "waittowrite" => ProduceWithWaitToWriteAsync,

    _ => ProduceWithWhileWriteAsync
};

string consumer = args?.Length > 1 ? args[1] : "nestedwhile";
Func<ChannelReader<Coordinates>, ValueTask> consumeCoordinatesAsync = consumer switch
{
    "nestedwhile" => ConsumeWithNestedWhileAsync,
    "awaitforeach" => ConsumeWithAwaitForeachAsync,
    "whiletrue" => ConsumeWithWhileAsync,

    _ => ConsumeWithAwaitForeachAsync
};

Coordinates initialCoordinates = new(
    DeviceId: Guid.NewGuid(),
    Latitude: -90,
    Longitude: -180);

using (LoggingStopwatch.WriteDurationToConsole())
{
    await Task.WhenAll(
        produceCoordinatesAsync(gps.Writer, initialCoordinates).AsTask(),
        consumeCoordinatesAsync(gps.Reader).AsTask());
}
