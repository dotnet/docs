// System.Net.Sockets.TcpClient main functionality. 

/**
  * This program shows how to use the TcpClient 
  * It creates a TcpClient that connects to a TcpServer listening on the specified port 
  * (13000). When connecting to the server it forwards a message, as specified in 
  * the input parameter.
  * To run this program at the command line you enter:
  * cs_tcpclient serverName "My message"
  * Where the serverName is the name on which the server is running.
  * For this program to work you need to have the TcpServer running in another
  * console window.
  * To avoid permission settings you can run this console application and the related 
  * TcpServer from your hard disk and not from a shared location on the network.
  **/

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Security.Permissions;


class MyTcpClient
{
  public static void Main(String[] args)
  {
    // Parse arguments
    String server;
    String message;
    if(args.Length < 2)
    {
      message = "This is a test!";
      if(args.Length == 0)
      {
        server = "localhost";
      }
      else
      {
        server = args[0];
      }
    }
    else
    {
      message = args[1];
      server = args[0];
    }

    // Connect to server
    Connect(server, message);
  }


  /**
   * The following function creates a TcpClient that connects to a 
   * TcpServer listening on the specified port (13000). 
   * When connecting to the server it forwards a message, as specified in 
   * the input parameter.
   **/ 
// <Snippet1>
  static void Connect(String server, String message) 
  {
    try 
    {
      // Create a TcpClient.
      // Note, for this client to work you need to have a TcpServer 
      // connected to the same address as specified by the server, port
      // combination.
      Int32 port = 13000;
      TcpClient client = new TcpClient(server, port);
      
      // Translate the passed message into ASCII and store it as a Byte array.
      Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);         

      // Get a client stream for reading and writing.
     //  Stream stream = client.GetStream();
      
      NetworkStream stream = client.GetStream();

      // Send the message to the connected TcpServer. 
      stream.Write(data, 0, data.Length);

      Console.WriteLine("Sent: {0}", message);         

      // Receive the TcpServer.response.
      
      // Buffer to store the response bytes.
      data = new Byte[256];

      // String to store the response ASCII representation.
      String responseData = String.Empty;

      // Read the first batch of the TcpServer response bytes.
      Int32 bytes = stream.Read(data, 0, data.Length);
      responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
      Console.WriteLine("Received: {0}", responseData);         

      // Close everything.
      stream.Close();         
      client.Close();         
    } 
    catch (ArgumentNullException e) 
    {
      Console.WriteLine("ArgumentNullException: {0}", e);
    } 
    catch (SocketException e) 
    {
      Console.WriteLine("SocketException: {0}", e);
    }
      
    Console.WriteLine("\n Press Enter to continue...");
    Console.Read();
  }
// </Snippet1>
}