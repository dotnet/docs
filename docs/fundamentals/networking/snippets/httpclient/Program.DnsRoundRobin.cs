using System.Net;
using System.Net.Http;
using System.Net.Sockets;

static partial class Program
{
    const string Uri = "http://example.com";
    // <DnsRoundRobinConnect>
    private static readonly DnsRoundRobinConnector s_roundRobinConnector = new(
            dnsRefreshInterval: TimeSpan.FromSeconds(10),
            endpointConnectTimeout: TimeSpan.FromSeconds(5));
    static async Task DnsRoundRobinConnectAsync()
    {
        var handler = new SocketsHttpHandler
        {
            ConnectCallback = async (context, cancellation) =>
            {
                Socket socket = await DnsRoundRobinConnector.Shared.ConnectAsync(context.DnsEndPoint, cancellation);
                // Or you can create and use your custom DnsRoundRobinConnector instance
                // Socket socket = await s_roundRobinConnector.ConnectAsync(context.DnsEndPoint, cancellation);
                return new NetworkStream(socket, ownsSocket: true);
            }
        };
        var client = new HttpClient(handler);
        HttpResponseMessage response = await client.GetAsync(Uri);
    }
    // </DnsRoundRobinConnect>
}
