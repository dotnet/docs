// Socket client example
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
    var messageBytes = Encoding.ASCII.GetBytes("This is a test<EOM>");
    _ = await client.SendAsync(messageBytes, SocketFlags.None);
    //if (sent is 0)
    //{
    //    continue;
    //}
    //else
    //{
    //    Console.WriteLine("Socket client sent message.");
    //}

    // Receive ack.
    var buffer = new byte[1_024];
    var response = new StringBuilder();
    var received = await client.ReceiveAsync(buffer, SocketFlags.None);
    response.Append(Encoding.ASCII.GetString(buffer, 0, received));
    if (response.ToString() == "<ACK>" /* is acknowledgement */)
    {
        Console.WriteLine($"Socket client received acknowledgement: '{response}'");
        break;
    }
}

client.Shutdown(SocketShutdown.Both);
// </socketclient>

Console.WriteLine("Press ENTER to continue...");
Console.Read();
