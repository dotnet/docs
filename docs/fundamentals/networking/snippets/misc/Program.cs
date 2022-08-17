using System.Net;
using System.Net.Cache;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Net.Sockets;
using System.Net.WebSockets;

//using SmtpClient smtpClient = new()
//{
//    DeliveryFormat = SmtpDeliveryFormat.International,
//    EnableSsl = true
//};

//using ClientWebSocket clientWebSocket = new()
//{
//    Options =
//    {
//        KeepAliveInterval = TimeSpan.FromMinutes(1)
//    }
//};

using Ping ping = new();

var host = Dns.GetHostEntry("docs.microsoft.com");
var reply = await ping.SendPingAsync(host.HostName);

Console.WriteLine($"Ping status: {reply.Status}");
if (reply is { Status: IPStatus.Success })
{
    Console.WriteLine($"Address: {reply.Address}");
    Console.WriteLine($"RoundTrip time: {reply.RoundtripTime}");
    Console.WriteLine($"Time to live: {reply.Options?.Ttl}");
    Console.WriteLine($"Don't fragment: {reply.Options?.DontFragment}");
    Console.WriteLine($"Buffer size: {reply.Buffer?.Length}");
}

using Socket socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
{
    NoDelay = true
};
