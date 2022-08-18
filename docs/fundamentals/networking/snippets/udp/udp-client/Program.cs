// UDP client example
Console.WriteLine("UDP client starting...");
var endPoint = await NetworkDiscovery.GetUdpEndPointAsync();

// <udpclient>
try
{
    using UdpClient client = new();
    client.Connect(endPoint);

    var result = await client.ReceiveAsync();

    var message = Encoding.ASCII.GetString(result.Buffer, 0, result.Buffer.Length);
    Console.WriteLine($"Message received: {message}");
}
catch (SocketException ex)
{
    Console.Error.WriteLine(ex);
    Console.Error.WriteLine(ex.SocketErrorCode);
}
// </udpclient>

Console.WriteLine("Press ENTER to continue...");
Console.Read();
