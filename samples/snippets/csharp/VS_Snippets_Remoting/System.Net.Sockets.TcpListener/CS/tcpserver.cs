// System.Net.Sockets.TcpListener

/**
  * This program shows how to use the TcpListener class. 
  * It creates a TcpListener that listen on the specified port (13000). 
  * To run this program at the command line you enter:
  * cs_tcpserver
  * Any TcpClient that wants to use this server
  * has to explicitly connect to an address obtained by the combination of
  * the sever on which this TcpServer is runnig and the port 13000. 
  * This TcpServer simply echoes back the message sent by the TcpClient, after
  * translating it into uppercase. 
  * To avoid permission settings you can run this console application and the related 
  * TcpClient from your hard disk and not from a shared location on the network.
  **/
// <Snippet1>
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class MyTcpListener
{
  public static void Main()
  { 
    TcpListener server=null;   
    try
    {
      // Set the TcpListener on port 13000.
      Int32 port = 13000;
      IPAddress localAddr = IPAddress.Parse("127.0.0.1");
      
      // TcpListener server = new TcpListener(port);
      server = new TcpListener(localAddr, port);

      // Start listening for client requests.
      server.Start();
         
      // Buffer for reading data
      Byte[] bytes = new Byte[256];
      String data = null;

      // Enter the listening loop.
      while(true) 
      {
        Console.Write("Waiting for a connection... ");
        
        // Perform a blocking call to accept requests.
        // You could also user server.AcceptSocket() here.
        TcpClient client = server.AcceptTcpClient();            
        Console.WriteLine("Connected!");

        data = null;

        // Get a stream object for reading and writing
        NetworkStream stream = client.GetStream();

        int i;

        // Loop to receive all the data sent by the client.
        while((i = stream.Read(bytes, 0, bytes.Length))!=0) 
        {   
          // Translate data bytes to a ASCII string.
          data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
          Console.WriteLine("Received: {0}", data);
       
          // Process the data sent by the client.
          data = data.ToUpper();

          byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

          // Send back a response.
          stream.Write(msg, 0, msg.Length);
          Console.WriteLine("Sent: {0}", data);            
        }
         
        // Shutdown and end connection
        client.Close();
      }
    }
    catch(SocketException e)
    {
      Console.WriteLine("SocketException: {0}", e);
    }
    finally
    {
       // Stop listening for new clients.
       server.Stop();
    }

      
    Console.WriteLine("\nHit enter to continue...");
    Console.Read();
  }   
}
// </Snippet1>