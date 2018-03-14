// <Internal>
// This program contains snippets for the following members:
// 1) System.Net.Sockets.MulticastOption;
// </Internal>

// <Snippet1>

using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

// This sender example must be used in conjunction with the listener program.
// You must run this program as follows:
// Open a console window and run the listener from the command line. 
// In another console window run the sender. In both cases you must specify 
// the local IPAddress to use. To obtain this address,  run the ipconfig command 
// from the command line. 
//  
namespace Mssc.TransportProtocols.Utilities
{
  class TestMulticastOption
  {

    static IPAddress mcastAddress;
    static int mcastPort;
    static Socket mcastSocket;
   
    static void JoinMulticastGroup()
    {
      try
      {
        // Create a multicast socket.
        mcastSocket = new Socket(AddressFamily.InterNetwork, 
                                 SocketType.Dgram, 
                                 ProtocolType.Udp);
			  
        // Get the local IP address used by the listener and the sender to
        // exchange multicast messages. 
        Console.Write("\nEnter local IPAddress for sending multicast packets: ");
        IPAddress  localIPAddr = IPAddress.Parse(Console.ReadLine());

        // Create an IPEndPoint object. 
        IPEndPoint IPlocal = new IPEndPoint(localIPAddr, 0);
        
        // Bind this endpoint to the multicast socket.
        mcastSocket.Bind(IPlocal);

        // Define a MulticastOption object specifying the multicast group 
        // address and the local IP address.
        // The multicast group address is the same as the address used by the listener.
        MulticastOption mcastOption;
        mcastOption = new MulticastOption(mcastAddress, localIPAddr);
        
        mcastSocket.SetSocketOption(SocketOptionLevel.IP, 
                                    SocketOptionName.AddMembership, 
                                    mcastOption);
     
      }
      catch (Exception e)
      {
        Console.WriteLine("\n" + e.ToString());
      }
    }

    static void BroadcastMessage(string message)
    {
      IPEndPoint endPoint;

      try
      {
        //Send multicast packets to the listener.
        endPoint = new IPEndPoint(mcastAddress,mcastPort);
        mcastSocket.SendTo(ASCIIEncoding.ASCII.GetBytes(message), endPoint);			
        Console.WriteLine("Multicast data sent.....");
      }
      catch (Exception e)
      {
        Console.WriteLine("\n" + e.ToString());
      }

      mcastSocket.Close();
    }
   
    
    static void Main(string[] args)
    {
      // Initialize the multicast address group and multicast port.
      // Both address and port are selected from the allowed sets as
      // defined in the related RFC documents. These are the same 
      // as the values used by the sender.
      mcastAddress = IPAddress.Parse("224.168.100.2");
      mcastPort = 11000;

      // Join the listener multicast group.
      JoinMulticastGroup();

      // Broadcast the message to the listener.
      BroadcastMessage("Hello multicast listener.");
    }
  }
}
// </Snippet1>