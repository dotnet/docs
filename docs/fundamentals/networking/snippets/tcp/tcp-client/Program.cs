// TCP client example
Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("TCP client starting...");

var ipAddress = await NetworkDiscovery.GetLocalhostIPAddressAsync();

// <tcpclient>
var ipEndPoint = new IPEndPoint(ipAddress, 13);

using TcpClient client = new();
await client.ConnectAsync(ipEndPoint);
await using NetworkStream stream = client.GetStream();

var buffer = new byte[1_024];
int received = await stream.ReadAsync(buffer);

var message = Encoding.UTF8.GetString(buffer, 0, received);
Console.WriteLine($"Message received: \"{message}\"");
// Sample output:
//     Message received: "📅 8/22/2022 9:07:17 AM 🕛"
// </tcpclient>

Console.WriteLine("Press ENTER to continue...");
Console.Read();
