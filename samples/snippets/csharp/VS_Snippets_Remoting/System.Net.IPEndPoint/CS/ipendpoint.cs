// File name:ipendpoint.cs.

// <Internal>
// This program contains snippets applicable to the following:
// System.Net.IPEndPoint (Snippet1);  
// System.Net.IPEndPoint.IPEndPoint(IPAddress, int) (Snippet2);
// System.Net.IPEndPoint.Address (Snippet3);
// System.Net.IPEndPoint.AddressFamily (Snippet3);
// System.Net.IPEndPoint.Port (Snippet3);
// System.Net.IPEndPoint.Serialize (Snippet4);
// System.Net.IPEndPoint.Create (Snippet5);
// </Internal>


//<Snippet1>

// This example uses the IPEndPoint class and its members to display the home page 
// of the server selected by the user.



using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;


namespace Mssc.Services.ConnectionManagement
{
  public class TestIPEndPoint
  {

    // The getPage method gets the server's home page content by 
    // recreating the server's endpoint from the original serialized endpoint.
    // Then it creates a new socket and connects it to the endpoint.
    private static string getPage(string server, SocketAddress socketAddress)
    {
      //Set up variables and string to write to the server.
      Encoding ASCII = Encoding.ASCII;
      string Get = "GET / HTTP/1.1\r\nHost: " + server + 
        "\r\nConnection: Close\r\n\r\n";
      Byte[] ByteGet = ASCII.GetBytes(Get);
      Byte[] RecvBytes = new Byte[256];
      String strRetPage = null;

      Socket socket = null;

//<Snippet5>
      // Recreate the connection endpoint from the serialized information.
      IPEndPoint endpoint = new IPEndPoint(0,0);
      IPEndPoint clonedIPEndPoint = (IPEndPoint) endpoint.Create(socketAddress);
      Console.WriteLine("clonedIPEndPoint: " + clonedIPEndPoint.ToString());
//</Snippet5>

      Console.WriteLine("Press any key to continue.");
      Console.ReadLine();

      try
      {
        // Create a socket object to establish a connection with the server.
        socket = 
          new Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        // Connect to the cloned end point.
        socket.Connect(clonedIPEndPoint);
      }
      catch(SocketException e) 
      {
        Console.WriteLine("Source : " + e.Source);
        Console.WriteLine("Message : " + e.Message);
      }
      catch(Exception e)
      {
        Console.WriteLine("Source : " + e.Source);
        Console.WriteLine("Message : " + e.Message);
      }

      if (socket == null)
        return ("Connection to cloned endpoint failed");
      
      // Send request to the server.
      socket.Send(ByteGet, ByteGet.Length, 0);  
        
      // Receive the server  home page content.
      Int32 bytes = socket.Receive(RecvBytes, RecvBytes.Length, 0);
   
      // Read the first 256 bytes.
      strRetPage = "Default HTML page on " + server + ":\r\n";
      strRetPage = strRetPage + ASCII.GetString(RecvBytes, 0, bytes);

      while (bytes > 0)
      {
        bytes = socket.Receive(RecvBytes, RecvBytes.Length, 0);
        strRetPage = strRetPage + ASCII.GetString(RecvBytes, 0, bytes);
      }
      
      socket.Close();

      return strRetPage;
    }

//<Snippet4>
    // The serializeEndpoint method serializes the endpoint and returns the 
    // SocketAddress containing the serialized endpoint data.
    private static SocketAddress serializeEndpoint(IPEndPoint endpoint)
    {
 
      // Serialize IPEndPoint details to a SocketAddress instance.
      SocketAddress socketAddress = endpoint.Serialize();
  
      // Display the serialized endpoint information.
      Console.WriteLine("Endpoint.Serialize() : " + socketAddress.ToString());
 
      Console.WriteLine("Socket.Family : " + socketAddress.Family);
      Console.WriteLine("Socket.Size : " + socketAddress.Size);

      Console.WriteLine("Press any key to continue.");
      Console.ReadLine();

      return socketAddress;
    }
//</Snippet4>

//<Snippet3>
    private static void displayEndpointInfo(IPEndPoint endpoint)
    {
      Console.WriteLine("Endpoint.Address : " + endpoint.Address);
      Console.WriteLine("Endpoint.AddressFamily : " + endpoint.AddressFamily);
      Console.WriteLine("Endpoint.Port : " + endpoint.Port);
      Console.WriteLine("Endpoint.ToString() : " + endpoint.ToString());

      Console.WriteLine("Press any key to continue.");
      Console.ReadLine();
    }
//</Snippet3>

    // The serializeEndpoint method determines the server endpoint and then 
    // serializes it to obtain the related SocketAddress object.
    // Note that in the for loop a temporary socket is created to ensure that 
    // the current IP address format matches the AddressFamily type.
    // In fact, in the case of servers supporting both IPv4 and IPv6, an exception 
    // may arise if an IP address format does not match the address family type.
    private static SocketAddress getSocketAddress(string server, int port)
    {
      Socket tempSocket = null;
      IPHostEntry host = null;
      SocketAddress serializedSocketAddress = null;
    
      try
      {
        // Get the object containing Internet host information.
        host = Dns.Resolve(server);

// <Snippet2>
        // Obtain the IP address from the list of IP addresses associated with the server.
        foreach(IPAddress address in host.AddressList)
        {
          IPEndPoint endpoint = new IPEndPoint(address, port);

            
          tempSocket = 
            new Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

          tempSocket.Connect(endpoint);

          if(tempSocket.Connected)
          {
            // Display the endpoint information.
            displayEndpointInfo(endpoint);
            // Serialize the endpoint to obtain a SocketAddress object.
            serializedSocketAddress = serializeEndpoint(endpoint);
            break;
          }
          else
            continue;
        }
// </Snippet2>

        // Close the temporary socket.
        tempSocket.Close();
      }
    
      catch(SocketException e) 
      {
        Console.WriteLine("Source : " + e.Source);
        Console.WriteLine("Message : " + e.Message);
      }
      catch(Exception e)
      {
        Console.WriteLine("Source : " + e.Source);
        Console.WriteLine("Message : " + e.Message);
      }
      return serializedSocketAddress;

    }


    // The requestServerHomePage method obtains the server's home page and returns
    // its content.
    private static string requestServerHomePage(string server, int port) 
    {
      String strRetPage = null;

      // Get a socket address using the specified server and port.
      SocketAddress socketAddress = getSocketAddress(server, port);

      if (socketAddress == null)
        strRetPage = "Connection failed";
      else 
        // Obtain the server's home page content.
        strRetPage = getPage(server, socketAddress);
     
      return strRetPage;
    }
    
    // Show to the user how to use this program when wrong input parameters are entered.
    private static void showUsage() 
    {
      Console.WriteLine("Enter the server name as follows:");
      Console.WriteLine("\tcs_ipendpoint servername");
    }

    // This is the program entry point. It allows the user to enter 
    // a server name that is used to locate its current homepage.
    public static void Main(string[] args) 
    {
      string host= null;
      int port = 80;

      // Define a regular expression to parse user's input.
      // This is a security check. It allows only
      // alphanumeric input string between 2 to 40 character long.
      Regex rex = new Regex(@"^[a-zA-Z]\w{1,39}$");

      if (args.Length < 1)
        showUsage();
      else
      {
        string message = args[0];
        if ((rex.Match(message)).Success)
        {
          host = args[0];
          // Get the specified server home_page and display its content.
          string result = requestServerHomePage(host, port); 
          Console.WriteLine(result);
        }
        else
          Console.WriteLine("Input string format not allowed.");
      }

    }
  
  }
}
//</Snippet1>
 


