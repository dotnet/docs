internal static partial class Program
{
    internal static async ValueTask ConsumeWithAwaitForeachAsync<T>(
        ChannelReader<T> reader)
    {
        await foreach (T coordinates in reader.ReadAllAsync())
        {
            Console.WriteLine(coordinates);
        }
    }

    internal static async ValueTask ConsumeWithWhileWaitToReadAsync<T>(
        ChannelReader<T> reader)
    {
        while (await reader.WaitToReadAsync())
        {
            if (reader.TryRead(out T item))
            {
                Console.WriteLine(item);
            }
        }
    }

    internal static async ValueTask ConsumeWithWhileAsync<T>(
        ChannelReader<T> reader)
    {
        while (true) // Only with unending/infinite producer.
        {
            T item = await reader.ReadAsync();
            Console.WriteLine(item);
        }
    }

    internal static async ValueTask ConsumeWithNestedWhileAsync<T>(
        ChannelReader<T> reader)
    {
        while (await reader.WaitToReadAsync())
        {
            while (reader.TryRead(out T item))
            {
                Console.WriteLine(item);
            }
        }
    }
}
