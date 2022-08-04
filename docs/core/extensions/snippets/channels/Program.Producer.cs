internal static partial class Program
{
    // <whiletrywrite>
    static void ProduceWithWhileAndTryWrite(
        ChannelWriter<Coordinates> writer, Coordinates coordinates)
    {
        while (coordinates is { Latitude: < 90, Longitude: < 180 })
        {
            var tempCoordinates = coordinates with
            {
                Latitude = coordinates.Latitude + .5,
                Longitude = coordinates.Longitude + 1
            };

            if (writer.TryWrite(item: tempCoordinates))
            {
                coordinates = tempCoordinates;
            }
        }
    }
    // </whiletrywrite>

    // <whilewrite>
    static async ValueTask ProduceWithWhileWriteAsync(
        ChannelWriter<Coordinates> writer, Coordinates coordinates)
    {
        while (coordinates is { Latitude: < 90, Longitude: < 180 })
        {
            await writer.WriteAsync(
                item: coordinates = coordinates with
                {
                    Latitude = coordinates.Latitude + .5,
                    Longitude = coordinates.Longitude + 1
                });
        }

        writer.Complete();
    }
    // </whilewrite>

    // <waittowrite>
    static async ValueTask ProduceWithWaitToWriteAsync(
        ChannelWriter<Coordinates> writer, Coordinates coordinates)
    {
        while (coordinates is { Latitude: < 90, Longitude: < 180 } &&
            await writer.WaitToWriteAsync())
        {
            var tempCoordinates = coordinates with
            {
                Latitude = coordinates.Latitude + .5,
                Longitude = coordinates.Longitude + 1
            };

            if (writer.TryWrite(item: tempCoordinates))
            {
                coordinates = tempCoordinates;
            }

            await Task.Delay(TimeSpan.FromMilliseconds(10));
        }

        writer.Complete();
    }
    // </waittowrite>
}
