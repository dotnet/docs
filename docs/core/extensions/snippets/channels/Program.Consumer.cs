internal static partial class Program
{
    // <awaitforeach>
    static async ValueTask ConsumeWithAwaitForeachAsync<T>(
        ChannelReader<T> reader)
    {
        await foreach (T coordinates in reader.ReadAllAsync())
        {
            Console.WriteLine(coordinates);
        }
    }
    // </awaitforeach>

    // <whilewaittoread>
    static async ValueTask ConsumeWithWhileWaitToReadAsync<T>(
        ChannelReader<T> reader)
    {
        while (await reader.WaitToReadAsync())
        {
            if (reader.TryRead(out T? item) && item is not null)
            {
                Console.WriteLine(item);
            }
        }
    }
    // </whilewaittoread>

    // <whiletrue>
    static async ValueTask ConsumeWithWhileAsync<T>(
        ChannelReader<T> reader)
    {
        while (true) // Only valid with never ending (infinite) producer.
        {
            T item = await reader.ReadAsync();
            Console.WriteLine(item);
        }
    }
    // </whiletrue>

    // <nestedwhile>
    static async ValueTask ConsumeWithNestedWhileAsync<T>(
        ChannelReader<T> reader)
    {
        while (await reader.WaitToReadAsync())
        {
            while (reader.TryRead(out T? item) && item is not null)
            {
                Console.WriteLine(item);
            }
        }
    }
    // </nestedwhile>
}
