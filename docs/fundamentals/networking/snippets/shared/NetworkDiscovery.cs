public static class NetworkDiscovery
{
    public static ValueTask<IPEndPoint> GetTcpEndPointAsync(int port = 13) =>
        GetLocalEndPointAsync(port);

    public static ValueTask<IPEndPoint> GetSocketEndPointAsync(int port = 9_000) =>
        GetLocalEndPointAsync(port);

    static async ValueTask<IPEndPoint> GetLocalEndPointAsync(int startingPort)
    {
        var port = startingPort;
        while (IsActivelyBeingUsed(port) && port > IPEndPoint.MaxPort) ++ port;

        var localIP = await GetLocalhostIPAddressAsync();

        Console.WriteLine($"Found: {localIP} available on port {port}.");

        return new IPEndPoint(localIP, port);
    }

    public static async ValueTask<IPAddress> GetLocalhostIPAddressAsync()
    {
        var localhost = await Dns.GetHostEntryAsync(Dns.GetHostName());
        var isInterNetwork = static (IPAddress ip) =>
            ip.AddressFamily is AddressFamily.InterNetwork;
        var localIP = localhost.AddressList.FirstOrDefault(isInterNetwork)
            ?? throw new Exception("Unable to get a local inter network IP.");

        return localIP;
    }

    static bool IsActivelyBeingUsed(int port) =>
        IPGlobalProperties.GetIPGlobalProperties()
            .GetActiveTcpListeners()
            .Any(ip => ip.Port == port);
}
