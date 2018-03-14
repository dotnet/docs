using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

public class Sample
{
// <Snippet1>
 protected void AcceptMethod(Socket listeningSocket)
 {
  Socket mySocket = listeningSocket.Accept();
 }
// </Snippet1>
}
