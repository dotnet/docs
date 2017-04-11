// File name:multicastOperations.cs
// This example shows how to join a multicast group and perform a muticast 
// data exchange. The OriginatorClient object starts the conversation while 
// the TargetClient responds. The two helper objects Receive and Send 
// perform the actual data exchange. 
// Note. This program cannot be build with the current VS build version.
// Build it via command line. Rubuild it in VS when a suitable version is 
// available.

// <Snippet1>

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Threading;


namespace Mssc.TransportProtocols.Utilities
{

            
  // The following Receive class is used by both the ClientOriginator and 
  // the ClientTarget class to receive data from one another..
  public class Receive
  {
    // The following static method performs the actual data
    // exchange. In particular, it performs the following tasks:
    // 1)Establishes a communication endpoint.
    // 2)Receive data through this end point on behalf of the
    // caller.
    // 3) Returns the received data in ASCII format.
    public static string ReceiveUntilStop(UdpClient c)
    {
        String strData = "";
        String Ret = "";
        ASCIIEncoding ASCII = new ASCIIEncoding();

        // Establish the communication endpoint.
        IPEndPoint endpoint = new IPEndPoint(IPAddress.IPv6Any, 50);

        while (!strData.Equals("Over")) 
        {            
          Byte[] data = c.Receive(ref endpoint);
          strData = ASCII.GetString(data);
          Ret += strData  + "\n"; 
        }
        return Ret;
    }
  }

  // The following Send class is used by both the ClientOriginator and 
  // ClientTarget classes to send data to one another.
  public class Send
  {
    private static char[] greetings = { 'H', 'e', 'l', 'l', 'o', ' ', 
                                      'T', 'a', 'r', 'g', 'e', 't', '.' };
    private static char[] nice      = { 'H', 'a', 'v', 'e', ' ', 'a', ' ', 'n', 'i', 
                                      'c', 'e', ' ', 'd', 'a', 'y', '.' };
    private static char [] eom      = { 'O', 'v', 'e', 'r'};

    private static char[] tGreetings = { 'H', 'e', 'l', 'l', 'o', ' ', 
                                       'O', 'r', 'i', 'g', 'i', 'n', 'a', 't', 'o', 'r', '!' };
    private static char[] tNice  = { 'Y', 'o', 'u', ' ', 't', 'o', 'o', '.'};

    // The following static method sends data to the ClientTarget on 
    // behalf of the ClientOriginator.
    public static void OriginatorSendData(UdpClient c, IPEndPoint ep)
    {
      Console.WriteLine(new string(greetings));
      c.Send(GetByteArray(greetings), greetings.Length, ep);        
      Thread.Sleep(1000);

      Console.WriteLine(new String(nice));
      c.Send(GetByteArray(nice), nice.Length, ep);        
       
      Thread.Sleep(1000);
      Console.WriteLine(new String(eom));
      c.Send(GetByteArray(eom), eom.Length, ep);      
    }

    // The following static method sends data to the ClientOriginator on 
    // behalf of the ClientTarget.
    public static void TargetSendData(UdpClient c, IPEndPoint ep)
    {
      Console.WriteLine(new string(tGreetings));
      c.Send(GetByteArray(tGreetings), tGreetings.Length, ep);        
      Thread.Sleep(1000);

      Console.WriteLine(new String(tNice));
      c.Send(GetByteArray(tNice), tNice.Length, ep);        
       
      Thread.Sleep(1000);
      Console.WriteLine(new String(eom));
      c.Send(GetByteArray(eom), eom.Length, ep);        
    }
    // Internal utility 
    private static Byte[] GetByteArray(Char[] ChArray) 
    {
      Byte[] Ret = new Byte[ChArray.Length];
      for (int i = 0; i < ChArray.Length; i++) 
        Ret[i] = (Byte) ChArray[i];
      return Ret;
    }
  }


  // The ClientTarget class is the receiver of the ClientOriginator 
  // messages. The StartMulticastConversation method contains the 
  // logic for exchanging data between the ClientTarget and its 
  // counterpart ClientOriginator in a multicast operation.
  public class ClientTarget
  {
    private static UdpClient m_ClientTarget;
    private static IPAddress m_GrpAddr;

    // The following StartMulticastConversation method connects the UDP 
    // ClientTarget with the ClientOriginator. 
    // It performs the following main tasks:
    // 1)Creates a UDP client to receive data on a specific port and using 
    // IPv6 addresses. The port is the same one used by the ClientOriginator 
    // to define its communication endpoint.
    // 2)Joins or creates a multicast group at the specified address.  
    // 3)Defines the endpoint port to send data to the ClientOriginator.
    // 4)Receives data from the ClientOriginator until the end of the 
    // communication.
    // 5)Sends data to the ClientOriginator.
    // Note this method is the counterpart of the 
    // ClientOriginator.ConnectOriginatorAndTarget().
    public static void StartMulticastConversation() 
    {
      string Ret;

      // Bind and listen on port 1000. Specify the IPv6 address family type.
      m_ClientTarget = new UdpClient(1000, AddressFamily.InterNetworkV6);
      
      // Join or create a multicast group
      m_GrpAddr = IPAddress.Parse("FF01::1");
      
      // Use the overloaded JoinMulticastGroup method.  
      // Refer to the ClientOriginator method to see how to use the other 
      // methods.
      m_ClientTarget.JoinMulticastGroup(m_GrpAddr);
      
      // Define the endpoint data port. Note that this port number
      // must match the ClientOriginator UDP port number which is the
      // port on which the ClientOriginator is receiving data.
      IPEndPoint ClientOriginatordest = new IPEndPoint(m_GrpAddr, 2000);

      // Receive data from the ClientOriginator.
      Ret = Receive.ReceiveUntilStop(m_ClientTarget);
      Console.WriteLine("\nThe ClientTarget received: " + "\n\n" + Ret + "\n");        

      // Done receiving, now respond to the ClientOriginator.

      // Wait to make sure the ClientOriginator is ready to receive.
      Thread.Sleep(2000); 

      Console.WriteLine("\nThe ClientTarget sent:\n");

      Send.TargetSendData(m_ClientTarget, ClientOriginatordest);
    
      // Exit the multicast conversation. 
      m_ClientTarget.DropMulticastGroup(m_GrpAddr);
    }
  } 


  // The following ClientOriginator class starts the multicast conversation
  // with the ClientTarget class.. 
  // It performs the following main tasks:
  // 1)Creates a socket and binds it to the port on which to communicate.
  // 2)Specifies that the connection must use an IPv6 address.
  // 3)Joins or create a multicast group. 
  //   Note that the multicast address ranges to use are specified 
  //   in the RFC#2375. 
  // 4)Defines the endpoint to send the data to and starts the 
  // client target (ClientTarget) thread.
  public class ClientOriginator
  {
    private static UdpClient clientOriginator;
    private static IPAddress m_GrpAddr;
    private static IPEndPoint m_ClientTargetdest;
    private static Thread m_t;

    // The ConnectOriginatorAndTarget method connects the 
    // ClientOriginator with the ClientTarget.
    // It performs the following main tasks:
    // 1)Creates a UDP client to receive data on a specific port 
    //   using IPv6 addresses. 
    // 2)Joins or create a multicast group at the specified address.  
    // 3)Defines the endpoint port to send data to on the ClientTarget.
    // 4)Starts the ClientTarget thread that also creates the ClientTarget object.
    // Note this method is the counterpart of the 
    // ClientTarget.StartMulticastConversation().
    public static bool ConnectOriginatorAndTarget()
    {        
      try 
      {
// <Snippet3>

        // Bind and listen on port 2000. This constructor creates a socket 
        // and binds it to the port on which to receive data. The family 
        // parameter specifies that this connection uses an IPv6 address.
        clientOriginator = new UdpClient(2000, AddressFamily.InterNetworkV6);

        // Join or create a multicast group. The multicast address ranges 
        // to use are specified in RFC#2375. You are free to use 
        // different addresses.
      
        // Transform the string address into the internal format.
        m_GrpAddr = IPAddress.Parse("FF01::1");

        // Display the multicast address used.
        Console.WriteLine("Multicast Address: [" + m_GrpAddr.ToString() + "]");

// <Snippet4>
        // Exercise the use of the IPv6MulticastOption.
        Console.WriteLine("Instantiate IPv6MulticastOption(IPAddress)");
    
        // Instantiate IPv6MulticastOption using one of the 
        // overloaded constructors.
        IPv6MulticastOption ipv6MulticastOption = new IPv6MulticastOption(m_GrpAddr);

        // Store the IPAdress multicast options.
        IPAddress group =  ipv6MulticastOption.Group;
        long interfaceIndex = ipv6MulticastOption.InterfaceIndex;

        // Display IPv6MulticastOption properties.
        Console.WriteLine("IPv6MulticastOption.Group: [" + group  + "]");
        Console.WriteLine("IPv6MulticastOption.InterfaceIndex: [" + interfaceIndex + "]");

// </Snippet4>

// <Snippet5>

        // Instantiate IPv6MulticastOption using another 
        // overloaded constructor.
        IPv6MulticastOption ipv6MulticastOption2 = new IPv6MulticastOption(group, interfaceIndex);

        // Store the IPAdress multicast options.
        group =  ipv6MulticastOption2.Group;
        interfaceIndex = ipv6MulticastOption2.InterfaceIndex;

        // Display the IPv6MulticastOption2 properties.
        Console.WriteLine("IPv6MulticastOption.Group: [" + group  + "]");
        Console.WriteLine("IPv6MulticastOption.InterfaceIndex: [" + interfaceIndex + "]");

        // Join the specified multicast group using one of the 
        // JoinMulticastGroup overloaded methods.
        clientOriginator.JoinMulticastGroup((int)interfaceIndex, group);
      
// </Snippet5>

        // Define the endpoint data port. Note that this port number
        // must match the ClientTarget UDP port number which is the
        // port on which the ClientTarget is receiving data.
        m_ClientTargetdest = new IPEndPoint(m_GrpAddr, 1000);

// </Snippet3>

        // Start the ClientTarget thread so it is ready to receive.
        m_t = new Thread(new ThreadStart(ClientTarget.StartMulticastConversation));
        m_t.Start();
        
        // Make sure that the thread has started.
        Thread.Sleep(2000); 
      
        return true;
      }
      catch (Exception e) 
      {
        Console.WriteLine("[ClientOriginator.ConnectClients] Exception: " + e.ToString());
        return false;
      }
    }
  
    // The SendAndReceive performs the data exchange  
    // between the ClientOriginator and the ClientTarget classes.
    public static string SendAndReceive()
    {
      string Ret = "";

// <Snippet2>

      // Send data to ClientTarget.
      Console.WriteLine("\nThe ClientOriginator sent:\n");
      Send.OriginatorSendData(clientOriginator, m_ClientTargetdest);
    
      // Receive data from ClientTarget
      Ret = Receive.ReceiveUntilStop(clientOriginator);

      // Stop the ClientTarget thread
      m_t.Abort();

      // Abandon the multicast group.
      clientOriginator.DropMulticastGroup(m_GrpAddr);

// </Snippet2>

      return Ret;
    }
    
    //This is the console application entry point.
    public static void Main()
    {
      // Join the multicast group.
      if (ConnectOriginatorAndTarget())  
      {
        // Perform a multicast conversation with the ClientTarget.
        string Ret = SendAndReceive();
        Console.WriteLine("\nThe ClientOriginator received: " + "\n\n" + Ret);  
      }
      else 
      {
        Console.WriteLine("Unable to Join the multicast group");
      }
    }
}
}
// </Snippet1>
