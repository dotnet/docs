internal static partial class Program
{
    // <awaitforeach>
    static async ValueTask ConsumeWithAwaitForeachAsync(
        ChannelReader<Coordinates> reader)
    {
        await foreach (Coordinates coordinates in reader.ReadAllAsync())
        {
            Console.WriteLine(coordinates);
        }
    }
    // </awaitforeach>

    // <whiletrue>
    static async ValueTask ConsumeWithWhileAsync(
        ChannelReader<Coordinates> reader)
    {
        while (true)
        {
            // May throw ChannelClosedException if
            // the parent channel's writer signals complete.
            Coordinates coordinates = await reader.ReadAsync();
            Console.WriteLine(coordinates);
        }
    }
    // </whiletrue>

    // <nestedwhile>
    static async ValueTask ConsumeWithNestedWhileAsync(
        ChannelReader<Coordinates> reader)
    {
        while (await reader.WaitToReadAsync())
        {
            while (reader.TryRead(out Coordinates coordinates))
            {
                Console.WriteLine(coordinates);
            }
        }
    }
    // </nestedwhile>
}
