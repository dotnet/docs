internal static partial class Program
{
    internal static async ValueTask ProduceWithWhileWriteAsync(
        ChannelWriter<Coordinates> writer)
    {
        Coordinates coordinates =
            new(DeviceId: Guid.NewGuid(), Latitude: -90, Longitude: -180);
        while (coordinates is { Latitude: < 90, Longitude: < 180 })
        {
            await writer.WriteAsync(
                item: coordinates = coordinates with
                {
                    Latitude = coordinates.Latitude + .5,
                    Longitude = coordinates.Longitude + 1
                });

            await Task.Delay(TimeSpan.FromMilliseconds(10));
        }

        writer.Complete();
    }

    internal static async ValueTask ProduceWithWaitToWriteAsync(
        ChannelWriter<Coordinates> writer)
    {
        Coordinates coordinates =
            new(DeviceId: Guid.NewGuid(), Latitude: -90, Longitude: -180);
        while (coordinates is { Latitude: < 90, Longitude: < 180 } &&
            await writer.WaitToWriteAsync())
        {
            writer.TryWrite(
                item: coordinates = coordinates with
                {
                    Latitude = coordinates.Latitude + .5,
                    Longitude = coordinates.Longitude + 1
                });

            await Task.Delay(TimeSpan.FromMilliseconds(10));
        }

        writer.Complete();
    }
}
