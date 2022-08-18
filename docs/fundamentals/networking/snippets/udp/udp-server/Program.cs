// UDP client example
Console.WriteLine("UDP server starting...");
var endPoint = await NetworkDiscovery.GetUdpEndPointAsync();

// <udpclient>
try
{
    using UdpClient client = new();
    client.Connect(endPoint);

    var message = DateTime.Now.ToString();
    var dateTimeBytes = Encoding.ASCII.GetBytes(message);
    await client.SendAsync(dateTimeBytes);
    Console.WriteLine($"Sent message: {message}");
}
catch (SocketException ex)
{
    Console.Error.WriteLine(ex);
    Console.Error.WriteLine(ex.SocketErrorCode);
}
// </udpclient>

Console.WriteLine("Press ENTER to continue...");
Console.Read();
