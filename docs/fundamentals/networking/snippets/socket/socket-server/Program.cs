// Socket server example
Console.WriteLine("Socket server starting...");

var endPoint = await NetworkDiscovery.GetSocketEndPointAsync();

// <socketserver>
using Socket listener = new(
    endPoint.AddressFamily,
    SocketType.Stream,
    ProtocolType.Tcp);

listener.Bind(endPoint);
listener.Listen(100);

var handler = await listener.AcceptAsync();
while (true)
{
    // Receive message.
    var buffer = new byte[1_024];
    var response = new StringBuilder();
    var received = await handler.ReceiveAsync(buffer, SocketFlags.None);
    if (received is 0)
    {
        await Task.Delay(500);
        continue;
    }

    // Send ack.
    var message = Encoding.ASCII.GetString(buffer, 0, received);
    response.Append(message);
    if (message.IndexOf("<EOM>") > -1 /* is end of message */)
    {
        Console.WriteLine($"Socket server received message: '{response}'");
        
        var echoBytes = Encoding.ASCII.GetBytes("<ACK>");
        await handler.SendAsync(echoBytes, 0);
        Console.WriteLine("Socket server sent acknowledgement.");

        break;
    }
}
// </socketserver>

Console.WriteLine("Press ENTER to continue...");
Console.Read();
