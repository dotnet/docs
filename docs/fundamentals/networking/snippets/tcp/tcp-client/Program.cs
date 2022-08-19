// TCP client example
Console.WriteLine("TCP client starting...");
var endPoint = await NetworkDiscovery.GetTcpEndPointAsync();

// <tcpclient>
using TcpClient client = new();
await client.ConnectAsync(endPoint);
await using NetworkStream stream = client.GetStream();

var buffer = new byte[1_024];
int received = await stream.ReadAsync(buffer);

var message = Encoding.ASCII.GetString(buffer, 0, received);
Console.WriteLine($"Message received: {message}");
// </tcpclient>

Console.WriteLine("Press ENTER to continue...");
Console.Read();
