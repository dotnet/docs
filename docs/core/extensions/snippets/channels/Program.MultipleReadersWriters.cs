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
        Task[] producerTasks = Enumerable.Range(0, 3)
            .Select(id => ProduceAsync(id, channel))
            .ToArray();

        // Start two concurrent consumer tasks.
        Task[] consumerTasks = Enumerable.Range(0, 2)
            .Select(_ => ConsumeAsync(channel))
            .ToArray();

        // Wait for all producers to finish, then mark the channel as complete.
        await Task.WhenAll(producerTasks);
        channel.Writer.Complete();

        // Wait for all consumers to finish.
        await Task.WhenAll(consumerTasks);

        static async Task ProduceAsync(int id, Channel<Coordinates> channel)
        {
            Coordinates coordinates = new(
                DeviceId: Guid.NewGuid(),
                Latitude: -90 + (id * 30),
                Longitude: -180 + (id * 60));

            while (coordinates is { Latitude: < 90, Longitude: < 180 })
            {
                coordinates = coordinates with
                {
                    Latitude = coordinates.Latitude + 0.5,
                    Longitude = coordinates.Longitude + 1
                };
                    
                await channel.Writer.WriteAsync(coordinates);
            }
        }

        static async Task ConsumeAsync(Channel<Coordinates> channel)
        {
            await foreach (Coordinates coordinates in channel.Reader.ReadAllAsync())
            {
                Console.WriteLine(coordinates);
            }
        }
    }
    // </multiplerw>
}
