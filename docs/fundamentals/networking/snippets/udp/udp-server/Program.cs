// TCP client example
Console.WriteLine("TCP client starting...");
var endPoint = await NetworkDiscovery.GetTcpEndPointAsync();

// <tcpclient>
try
{
    using TcpClient client = new();
    await client.ConnectAsync(endPoint);
    await using NetworkStream stream = client.GetStream();

    var buffer = new byte[1_024];
    int received = await stream.ReadAsync(buffer);

    var message = Encoding.ASCII.GetString(buffer, 0, received);
    Console.WriteLine($"Message received: {message}");
}
catch (SocketException ex)
{
    Console.Error.WriteLine(ex);
    Console.Error.WriteLine(ex.SocketErrorCode);
}
// </tcpclient>

Console.WriteLine("Press ENTER to continue...");
Console.Read();
