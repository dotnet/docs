internal static partial class Program
{
    // <multiplerw>
    static async Task UseMultipleProducersAndConsumersAsync()
    {
        Channel<Coordinates> channel = Channel.CreateUnbounded<Coordinates>(
            new UnboundedChannelOptions
            {
                SingleWriter = false,
                SingleReader = false
            });

        // Start three concurrent producer tasks.
        Task[] producerTasks = Enumerable.Range(0, 3).Select(id => Task.Run(async () =>
        {
            Coordinates coordinates = new(
                DeviceId: Guid.NewGuid(),
                Latitude: -90 + (id * 30),
                Longitude: -180 + (id * 60));

            while (coordinates is { Latitude: < 90, Longitude: < 180 })
            {
                await channel.Writer.WriteAsync(
                    coordinates = coordinates with
                    {
                        Latitude = coordinates.Latitude + .5,
                        Longitude = coordinates.Longitude + 1
                    });
            }
        })).ToArray();

        // Start two concurrent consumer tasks.
        Task[] consumerTasks = Enumerable.Range(0, 2).Select(_ => Task.Run(async () =>
        {
            await foreach (Coordinates coordinates in channel.Reader.ReadAllAsync())
            {
                Console.WriteLine(coordinates);
            }
        })).ToArray();

        // Wait for all producers to finish, then mark the channel as complete.
        await Task.WhenAll(producerTasks);
        channel.Writer.Complete();

        // Wait for all consumers to finish.
        await Task.WhenAll(consumerTasks);
    }
    // </multiplerw>
}
