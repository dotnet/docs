public static partial class Program
{
    static async Task PingAsync()
    {
        // <ping>
        using Ping ping = new();

        string hostName = "stackoverflow.com";
        PingReply reply = await ping.SendPingAsync(hostName);
        Console.WriteLine($"Ping status for ({hostName}): {reply.Status}");
        if (reply is { Status: IPStatus.Success })
        {
            Console.WriteLine($"Address: {reply.Address}");
            Console.WriteLine($"Roundtrip time: {reply.RoundtripTime}");
            Console.WriteLine($"Time to live: {reply.Options?.Ttl}");
            Console.WriteLine();
        }
        // </ping>
    }
}
