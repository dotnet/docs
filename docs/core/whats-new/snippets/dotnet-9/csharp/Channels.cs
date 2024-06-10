using System;
using System.Threading.Channels;

internal class Channels
{
    public static async void RunIt()
    {
        // <SnippetChannel>
        Channel<int> c = Channel.CreateUnboundedPrioritized<int>();

        await c.Writer.WriteAsync(1);
        await c.Writer.WriteAsync(5);
        await c.Writer.WriteAsync(2);
        await c.Writer.WriteAsync(4);
        await c.Writer.WriteAsync(3);
        c.Writer.Complete();

        while (await c.Reader.WaitToReadAsync())
        {
            while (c.Reader.TryRead(out int item))
            {
                Console.Write($"{item} ");
            }
        }

        // Output: 1 2 3 4 5
        // </SnippetChannel>
    }
}
