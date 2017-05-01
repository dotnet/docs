using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

public class Sample
{

public static void DoSocketGet(string server) 
 {
    //Set up variables and String to write to the server.
    Encoding ASCII = Encoding.ASCII;
    string Get = "GET / HTTP/1.1\r\nHost: " + server + 
                 "\r\nConnection: Close\r\n\r\n";
    Byte[] ByteGet = ASCII.GetBytes(Get);
    Byte[] RecvBytes = new Byte[256];
    String strRetPage = null;
 

    // IPAddress and IPEndPoint represent the endpoint that will
    //   receive the request.
    // Get first IPAddress in list return by DNS.
  
  
    IPAddress hostadd = Dns.GetHostEntry(server).AddressList[0];
    IPEndPoint EPhost = new IPEndPoint(hostadd, 80);
    //<Snippet1>
    //Creates the Socket for sending data over TCP.
    Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
       ProtocolType.Tcp );
 
    // Connects to host using IPEndPoint.
    s.Connect(EPhost);
    if (!s.Connected)
    {
       strRetPage = "Unable to connect to host";
    }
    // Use the SelectWrite enumeration to obtain Socket status.
     if(s.Poll(-1, SelectMode.SelectWrite)){
          Console.WriteLine("This Socket is writable.");
     }
     else if (s.Poll(-1, SelectMode.SelectRead)){
     	   Console.WriteLine("This Socket is readable." );
     }
     else if (s.Poll(-1, SelectMode.SelectError)){
          Console.WriteLine("This Socket has an error.");
     }

     //</Snippet1>

    // Sent the GET text to the host.
    s.Send(ByteGet, ByteGet.Length, 0);

    // Receives the page, loops until all bytes are received.
    Int32 bytes = s.Receive(RecvBytes, RecvBytes.Length, 0);
    strRetPage = "Default HTML page on " + server + ":\r\n";
    strRetPage = strRetPage + ASCII.GetString(RecvBytes, 0, bytes);
 
    while (bytes > 0)
    {
       bytes = s.Receive(RecvBytes, RecvBytes.Length, 0);
       strRetPage = strRetPage + ASCII.GetString(RecvBytes, 0, bytes);
   
}
}
   public static void Main(){
       DoSocketGet("www.contoso.com");
   }

}
 


