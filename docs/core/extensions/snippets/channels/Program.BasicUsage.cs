internal static partial class Program
{
    // <basicusage>
    static async Task BasicUsageAsync()
    {
        Channel<int> channel = Channel.CreateUnbounded<int>();

        Task producer = ProduceAsync(channel.Writer);
        Task consumer = ConsumeAsync(channel.Reader);

        await Task.WhenAll(producer, consumer);

        static async Task ProduceAsync(ChannelWriter<int> writer)
        {
            for (int i = 0; i < 5; i++)
            {
                await writer.WriteAsync(i);
            }

            writer.Complete();
        }

        static async Task ConsumeAsync(ChannelReader<int> reader)
        {
            await foreach (int item in reader.ReadAllAsync())
            {
                Console.WriteLine($"Received: {item}");
            }
        }
    }
    // </basicusage>
}
