// Socket client example
Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("Socket client starting...");

var endPoint = await NetworkDiscovery.GetSocketEndPointAsync();

// <socketclient>
using Socket client = new(
    endPoint.AddressFamily, 
    SocketType.Stream, 
    ProtocolType.Tcp);

await client.ConnectAsync(endPoint);
while (true)
{
    // Send message.
    var message = "Hi friends 👋!<EOM>";
    var messageBytes = Encoding.UTF8.GetBytes(message);
    _ = await client.SendAsync(messageBytes, SocketFlags.None);
    Console.WriteLine($"Socket client sent message: \"{message}\"");

    // Receive ack.
    var buffer = new byte[1_024];
    var response = new StringBuilder();
    var received = await client.ReceiveAsync(buffer, SocketFlags.None);
    response.Append(Encoding.UTF8.GetString(buffer, 0, received));
    if (response.ToString() == "<ACK>" /* is acknowledgement */)
    {
        Console.WriteLine($"Socket client received acknowledgement: \"{response}\"");
        break;
    }
    // Sample output:
    //     Socket client sent message: "Hi friends 👋!<EOM>"
    //     Socket client received acknowledgement: "<ACK>"
}

client.Shutdown(SocketShutdown.Both);
// </socketclient>

Console.WriteLine("Press ENTER to continue...");
Console.Read();
