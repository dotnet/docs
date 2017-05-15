// <Internal>
// File name: ipaddress.cs
// The snippets contained here apply to:
// 1) System.Net.IPAddress.AddressFamily, snippet3.
// 2) System.Net.IPAddess.ScopeId, snippet3.
// more
// Note. This program is compiled via the csc command line. Waiting for VS
// update that contains th eIPV6 types.
// </Internal>

// <Snippet1>

// This program shows how to use the IPAddress class to obtain a server 
// IP addressess and related information.

using System;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace Mssc.Services.ConnectionManagement
{

  class TestIPAddress 
  {

    /**
      * The IPAddresses method obtains the selected server IP address information.
      * It then displays the type of address family supported by the server and its 
      * IP address in standard and byte format.
      **/
    private static void IPAddresses(string server) 
    {
      try 
      {
        System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();
  
        // Get server related information.
        IPHostEntry heserver = Dns.GetHostEntry(server);

        // Loop on the AddressList
        foreach (IPAddress curAdd in heserver.AddressList) 
        {

//<Snippet3>

          // Display the type of address family supported by the server. If the
          // server is IPv6-enabled this value is: InternNetworkV6. If the server
          // is also IPv4-enabled there will be an additional value of InterNetwork.
          Console.WriteLine("AddressFamily: " + curAdd.AddressFamily.ToString());
          
          // Display the ScopeId property in case of IPV6 addresses.
          if(curAdd.AddressFamily.ToString() == ProtocolFamily.InterNetworkV6.ToString())
            Console.WriteLine("Scope Id: " + curAdd.ScopeId.ToString());

//</Snippet3>

          // Display the server IP address in the standard format. In 
          // IPv4 the format will be dotted-quad notation, in IPv6 it will be
          // in in colon-hexadecimal notation.
          Console.WriteLine("Address: " + curAdd.ToString());
        
          // Display the server IP address in byte format.
          Console.Write("AddressBytes: ");



//<Snippet2>
          Byte[] bytes = curAdd.GetAddressBytes();
          for (int i = 0; i < bytes.Length; i++) 
          {
            Console.Write(bytes[i]);
          }                          
// </Snippet2>

          Console.WriteLine("\r\n");

        }

      }
      catch (Exception e) 
      {
        Console.WriteLine("[DoResolve] Exception: " + e.ToString());
      }
    }

    // This IPAddressAdditionalInfo displays additional server address information.
    private static void IPAddressAdditionalInfo() 
    {
      try 
      {
        // Display the flags that show if the server supports IPv4 or IPv6
        // address schemas.
        Console.WriteLine("\r\nSupportsIPv4: " + Socket.SupportsIPv4);
        Console.WriteLine("SupportsIPv6: " + Socket.SupportsIPv6);

        if (Socket.SupportsIPv6)
        {
          // Display the server Any address. This IP address indicates that the server 
          // should listen for client activity on all network interfaces. 
          Console.WriteLine("\r\nIPv6Any: " + IPAddress.IPv6Any.ToString());

          // Display the server loopback address. 
          Console.WriteLine("IPv6Loopback: " + IPAddress.IPv6Loopback.ToString());
      
          // Used during autoconfiguration first phase.
          Console.WriteLine("IPv6None: " + IPAddress.IPv6None.ToString());
      
          Console.WriteLine("IsLoopback(IPv6Loopback): " + IPAddress.IsLoopback(IPAddress.IPv6Loopback));
        }
        Console.WriteLine("IsLoopback(Loopback): " + IPAddress.IsLoopback(IPAddress.Loopback));
      }
      catch (Exception e) 
      {
        Console.WriteLine("[IPAddresses] Exception: " + e.ToString());
      }
    }


    public static void Main(string[] args) 
    {
      string server = null;
    
      // Define a regular expression to parse user's input.
      // This is a security check. It allows only
      // alphanumeric input string between 2 to 40 character long.
      Regex rex = new Regex(@"^[a-zA-Z]\w{1,39}$");

      if (args.Length < 1)
      {
        // If no server name is passed as an argument to this program, use the current 
        // server name as default.
        server = Dns.GetHostName();
        Console.WriteLine("Using current host: " + server);
      }
      else
      {
        server = args[0];
        if (!(rex.Match(server)).Success)
        {
          Console.WriteLine("Input string format not allowed.");
          return;
        }
      }

      // Get the list of the addresses associated with the requested server.
      IPAddresses(server);
    
      // Get additonal address information.
      IPAddressAdditionalInfo();
    }

  }
}
  // </Snippet1>