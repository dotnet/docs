 //<Snippet1>
using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

public class Sample
{

  public static string DoSocketGet(string server) 
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


    try
    {


      // Define those variables to be evaluated in the next for loop and 
      // then used to connect to the server. These variables are defined
      // outside the for loop to make them accessible there after.
      Socket s = null;
      IPEndPoint hostEndPoint;
      IPAddress hostAddress = null;
      int conPort = 80;

      // Get DNS host information.
      IPHostEntry hostInfo = Dns.GetHostEntry(server);
      // Get the DNS IP addresses associated with the host.
      IPAddress[] IPaddresses = hostInfo.AddressList;

      // Evaluate the socket and receiving host IPAddress and IPEndPoint. 
      for (int index=0; index<IPaddresses.Length; index++)
      {
        hostAddress = IPaddresses[index];
        hostEndPoint = new IPEndPoint(hostAddress, conPort);

  //<Snippet3>

        // Creates the Socket to send data over a TCP connection.
        s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );

 //<Snippet2>

 
        // Connect to the host using its IPEndPoint.
        s.Connect(hostEndPoint);

        if (!s.Connected)
        {
          // Connection failed, try next IPaddress.
          strRetPage = "Unable to connect to host";
          s = null;
          continue;
        }

//</Snippet2>
        // Sent the GET request to the host.
        s.Send(ByteGet, ByteGet.Length, 0);

//</Snippet3>

      } // End of the for loop.      


//<Snippet4>
 
      // Receive the host home page content and loop until all the data is received.
      Int32 bytes = s.Receive(RecvBytes, RecvBytes.Length, 0);
      strRetPage = "Default HTML page on " + server + ":\r\n";
      strRetPage = strRetPage + ASCII.GetString(RecvBytes, 0, bytes);
 
      while (bytes > 0)
      {
        bytes = s.Receive(RecvBytes, RecvBytes.Length, 0);
        strRetPage = strRetPage + ASCII.GetString(RecvBytes, 0, bytes);
      }

//</Snippet4>
    
    } // End of the try block.
    
    catch(SocketException e) 
    {
      Console.WriteLine("SocketException caught!!!");
      Console.WriteLine("Source : " + e.Source);
      Console.WriteLine("Message : " + e.Message);
    }
    catch(ArgumentNullException e)
    {
      Console.WriteLine("ArgumentNullException caught!!!");
      Console.WriteLine("Source : " + e.Source);
      Console.WriteLine("Message : " + e.Message);
    }
    catch(NullReferenceException e)
    {
      Console.WriteLine("NullReferenceException caught!!!");
      Console.WriteLine("Source : " + e.Source);
      Console.WriteLine("Message : " + e.Message);
    }
    catch(Exception e)
    {
      Console.WriteLine("Exception caught!!!");
      Console.WriteLine("Source : " + e.Source);
      Console.WriteLine("Message : " + e.Message);
    }
    
    return strRetPage;

}
   public static void Main()
   {
      Console.WriteLine(DoSocketGet("localhost"));
   }
 }
//</Snippet1>
 


