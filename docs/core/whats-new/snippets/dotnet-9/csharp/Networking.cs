using System;
using System.IO;
using System.Net.Http;
using System.Net.ServerSentEvents;
using System.Net.WebSockets;
using System.Threading;

internal class Networking
{
    public static async void RunIt()
    {
        // <SseParser>
        Stream responseStream = new MemoryStream();
        await foreach (SseItem<string> e in SseParser.Create(responseStream).EnumerateAsync())
        {
            Console.WriteLine(e.Data);
        }
        // </SseParser>

        var uri = new Uri("http://localhost:5000");
        var httpClient = new HttpClient();
        var cancellationToken = new CancellationToken();

        // <KeepAliveTimeout>
        using var cws = new ClientWebSocket();
        cws.Options.HttpVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher;
        cws.Options.KeepAliveInterval = TimeSpan.FromSeconds(5);
        cws.Options.KeepAliveTimeout = TimeSpan.FromSeconds(1);

        await cws.ConnectAsync(uri, httpClient, cancellationToken);
        // </KeepAliveTimeout>
    }
}
