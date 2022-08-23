public static partial class Program
{
    // <ping>
    static async Task PingAsync()
    {
        using Ping ping = new();

        var hostName = "stackoverflow.com";
        var reply = await ping.SendPingAsync(hostName);
        Console.WriteLine($"Ping status for ({hostName}): {reply.Status}");
        if (reply is { Status: IPStatus.Success })
        {
            Console.WriteLine($"Address: {reply.Address}");
            Console.WriteLine($"RoundTrip time: {reply.RoundtripTime}");
            Console.WriteLine($"Time to live: {reply.Options?.Ttl}");
            Console.WriteLine();
        }
    }
    // </ping>
}
