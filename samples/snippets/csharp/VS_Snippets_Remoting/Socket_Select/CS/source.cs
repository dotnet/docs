using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;

class Test
{
  public static void Main()
  {
// <Snippet1>
    IPHostEntry ipHostEntry = Dns.Resolve(Dns.GetHostName());
    IPAddress ipAddress = ipHostEntry.AddressList[0];

    Socket socket0 = null;
    Socket socket1 = null; 
    Socket socket2 = null; 
    Socket socket3 = null; 
    Socket socket4 = null; 
    Socket socket5 = null; 

    ArrayList listenList = new ArrayList();
    listenList.Add(socket0);
    listenList.Add(socket1);
    listenList.Add(socket2);

    ArrayList acceptList = new ArrayList();
    acceptList.Add(socket3);
    acceptList.Add(socket4);
    acceptList.Add(socket5);

    for( int i = 0; i < 3; i++ )
    {
      listenList[i] = new Socket(AddressFamily.InterNetwork,
                                 SocketType.Stream,
                                 ProtocolType.Tcp);
      ((Socket)listenList[i]).Bind(new IPEndPoint(ipAddress, 11000 + i));
      ((Socket)listenList[i]).Listen(10);
    }

    // Only the sockets that contain a connection request
    // will remain in listenList after Select returns.

    Socket.Select(listenList, null, null, 1000);

    for( int i = 0; i < listenList.Count; i++ )
    {
      acceptList[i] = ((Socket)listenList[i]).Accept();
    }
// </Snippet1>
  }
}
