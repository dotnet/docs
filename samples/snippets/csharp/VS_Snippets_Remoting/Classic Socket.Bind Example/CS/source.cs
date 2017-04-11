using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

public class Sample
{
 protected void Method(Socket aSocket, EndPoint anEndPoint)
 {
// <Snippet1>
 try {
     aSocket.Bind(anEndPoint);
 }
 catch (Exception e) {
     Console.WriteLine("Winsock error: " + e.ToString());
 }
 
// </Snippet1>
 }
}
