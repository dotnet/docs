using System;
using System.IO;
using System.Net.ServerSentEvents;

internal class Networking
{
    public async static void RunIt()
    {
        // <SseParser>
        Stream responseStream = new MemoryStream();
        await foreach (SseItem<string> e in SseParser.Create(responseStream).EnumerateAsync())
        {
            Console.WriteLine(e.Data);
        }
        // </SseParser>
    }
}
