// TCP listener example
Console.WriteLine("TCP listener starting...");
var endPoint = await NetworkDiscovery.GetTcpEndPointAsync();

// <tcplistener>
try
{
    TcpListener listener = new(endPoint);
    listener.Start();

    using TcpClient handler = await listener.AcceptTcpClientAsync();
    await using NetworkStream stream = handler.GetStream();

    var message = DateTime.Now.ToString();
    var dateTimeBytes = Encoding.ASCII.GetBytes(message);
    await stream.WriteAsync(dateTimeBytes);
    Console.WriteLine($"Sent message: {message}");

    listener.Stop();
}
catch (SocketException ex)
{
    Console.Error.WriteLine(ex);
    Console.Error.WriteLine(ex.SocketErrorCode);
}
// </tcplistener>

Console.WriteLine("Press ENTER to continue...");
Console.Read();
