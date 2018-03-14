using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

public class Sample
{
 protected void Method(Socket mySocket)
 {
// <Snippet1>
 LingerOption myOpts = new LingerOption(true,1);
 
 mySocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Linger, myOpts);
 
// </Snippet1>
 }
}
