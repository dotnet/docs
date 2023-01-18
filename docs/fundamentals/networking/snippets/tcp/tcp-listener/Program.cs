// TCP listener example
Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("TCP listener starting...");

// <tcplistener>
var ipEndPoint = new IPEndPoint(IPAddress.Any, 13);
TcpListener listener = new(ipEndPoint);

try
{    
    listener.Start();

    using TcpClient handler = await listener.AcceptTcpClientAsync();
    await using NetworkStream stream = handler.GetStream();

    var message = $"📅 {DateTime.Now} 🕛";
    var dateTimeBytes = Encoding.UTF8.GetBytes(message);
    await stream.WriteAsync(dateTimeBytes);

    Console.WriteLine($"Sent message: \"{message}\"");
    // Sample output:
    //     Sent message: "📅 8/22/2022 9:07:17 AM 🕛"
}
finally
{
    listener.Stop();
}
// </tcplistener>

Console.WriteLine("Press ENTER to continue...");
Console.Read();
