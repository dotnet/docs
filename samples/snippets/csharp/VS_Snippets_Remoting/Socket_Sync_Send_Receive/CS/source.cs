using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class Sync_Send_Receive
{
    //<Snippet1>
    // Displays sending with a connected socket
    // using the overload that takes a buffer.
    public static int SendReceiveTest1(Socket server)
    {
        byte[] msg = Encoding.UTF8.GetBytes("This is a test");
        byte[] bytes = new byte[256];
        try 
        {
            // Blocks until send returns.
            int i = server.Send(msg);
            Console.WriteLine("Sent {0} bytes.", i);
            
            // Get reply from the server.
            i = server.Receive(bytes);
            Console.WriteLine(Encoding.UTF8.GetString(bytes));
        }
        catch (SocketException e)
        {
            Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode);
            return (e.ErrorCode);
        }
        return 0;
    }
    //</Snippet1>
 

    // Displays receiving from a connected tcp socket
    // using the overload that takes a buffer.
    public static int ReceiveTest1(Socket client)
    {
        
        byte[] bytes = new byte[256];
        try 
        {
            // It is usually preferable to use the overload
            // that allows you to specify the maximum bytes returned.
            if (client.Available > 256)
            {
                throw new ApplicationException("This test socket only takes messages < 256 bytes.");
            }
            // Blocks until read returns.
            int byteCount = client.Receive(bytes);
            if (byteCount > 0)
                Console.WriteLine(Encoding.UTF8.GetString(bytes));
            
            // Send reply to the client.
            client.Send(Encoding.UTF8.GetBytes("Bye."));
        }
        catch (SocketException e)
        {
            Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode);
            return (e.ErrorCode);
        }
        return 0;
    }
   
    
    //<Snippet2>
    // Displays sending with a connected socket
    // using the overload that takes a buffer and socket flags.
    public static int SendReceiveTest2(Socket server)
    {
        byte[] msg = Encoding.UTF8.GetBytes("This is a test");
        byte[] bytes = new byte[256];
        try 
        {
            // Blocks until send returns.
            int byteCount = server.Send(msg, SocketFlags.None);
            Console.WriteLine("Sent {0} bytes.", byteCount);
            
            // Get reply from the server.
            byteCount = server.Receive(bytes, SocketFlags.None);
            if (byteCount > 0)
                Console.WriteLine(Encoding.UTF8.GetString(bytes));
        }
        catch (SocketException e)
        {
            Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode);
            return (e.ErrorCode);
        }
        return 0;
    }
    //</Snippet2>

    //<Snippet3>
    // Displays sending with a connected socket
    // using the overload that takes a buffer, message size, and socket flags.
    public static int SendReceiveTest3(Socket server)
    {
        byte[] msg = Encoding.UTF8.GetBytes("This is a test");
        byte[] bytes = new byte[256];
        try 
        {
            // Blocks until send returns.
            int i = server.Send(msg, msg.Length, SocketFlags.None);
            Console.WriteLine("Sent {0} bytes.", i);
            
            // Get reply from the server.
            int byteCount = server.Receive(bytes, server.Available, 
                                               SocketFlags.None);
            if (byteCount > 0)
                Console.WriteLine(Encoding.UTF8.GetString(bytes));
        }
        catch (SocketException e)
        {
            Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode);
            return (e.ErrorCode);
        }
        return 0;
    }
    //</Snippet3>

    //<Snippet4>
    // Displays sending with a connected socket
    // using the overload that takes a buffer, offset, message size, and socket flags.
    public static int SendReceiveTest4(Socket server)
    {
        byte[] msg = Encoding.UTF8.GetBytes("This is a test");
        byte[] bytes = new byte[256];
        try 
        {
            // Blocks until send returns.
            int byteCount = server.Send(msg, 0, msg.Length, SocketFlags.None);
            Console.WriteLine("Sent {0} bytes.", byteCount);
            
            // Get reply from the server.
            byteCount = server.Receive(bytes, 0, server.Available, 
                                       SocketFlags.None);

            if (byteCount > 0)
                Console.WriteLine(Encoding.UTF8.GetString(bytes));
        }
        catch (SocketException e)
        {
            Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode);
            return (e.ErrorCode);
        }
        return 0;
    }
    //</Snippet4>

    //<Snippet5>
    public static void SendTo1()
    {
        IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
        IPEndPoint endPoint = new IPEndPoint(hostEntry.AddressList[0], 11000);

        Socket s = new Socket(endPoint.Address.AddressFamily,
            SocketType.Dgram,
            ProtocolType.Udp);
      
        byte[] msg = Encoding.ASCII.GetBytes("This is a test");
        Console.WriteLine("Sending data.");
        // This call blocks. 
        s.SendTo(msg, endPoint);
        s.Close();
    }
    //</Snippet5>
        
    //<Snippet6>  
    public static void SendTo2()
    {
        IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
        IPEndPoint endPoint = new IPEndPoint(hostEntry.AddressList[0], 11000);

        Socket s = new Socket(endPoint.Address.AddressFamily,
            SocketType.Dgram,
            ProtocolType.Udp);
      
        byte[] msg = Encoding.ASCII.GetBytes("This is a test");
        Console.WriteLine("Sending data.");
        // This call blocks. 
        s.SendTo(msg, SocketFlags.None, endPoint);
        s.Close();
    }
    //</Snippet6>
    //<Snippet7>	
    public static void SendTo3()
    {
        IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
        IPEndPoint endPoint = new IPEndPoint(hostEntry.AddressList[0], 11000);

        Socket s = new Socket(endPoint.Address.AddressFamily,
            SocketType.Dgram,
            ProtocolType.Udp);
      
        byte[] msg = Encoding.ASCII.GetBytes("This is a test");
        Console.WriteLine("Sending data.");
        // This call blocks. 
        s.SendTo(msg, msg.Length, SocketFlags.None, endPoint);
        s.Close();
    }
    //</Snippet7>
    //<Snippet8>
    public static void SendTo4()
    {
        IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
        IPEndPoint endPoint = new IPEndPoint(hostEntry.AddressList[0], 11000);

        Socket s = new Socket(endPoint.Address.AddressFamily,
            SocketType.Dgram,
            ProtocolType.Udp);
      
        byte[] msg = Encoding.ASCII.GetBytes("This is a test");
        Console.WriteLine("Sending data.");
        // This call blocks. 
        s.SendTo(msg, 0, msg.Length, SocketFlags.None, endPoint);
        s.Close();
    }

    //</Snippet8>

    // The ReceiveFroms

    //<Snippet9>
    public static void ReceiveFrom1()
    {
        IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
        IPEndPoint endPoint = new IPEndPoint(hostEntry.AddressList[0], 11000);

        Socket s = new Socket(endPoint.Address.AddressFamily,
            SocketType.Dgram,
            ProtocolType.Udp);
      
        // Creates an IPEndPoint to capture the identity of the sending host.
        IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
        EndPoint senderRemote = (EndPoint)sender;
        
        // Binding is required with ReceiveFrom calls.
        s.Bind(endPoint);
        
        byte[] msg = new Byte[256];
        Console.WriteLine ("Waiting to receive datagrams from client...");
        
        // This call blocks. 
        s.ReceiveFrom(msg, ref senderRemote);
        s.Close();
    }
    //</Snippet9>
        
    //<Snippet10>  
    public static void ReceiveFrom2()
    {
        IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
        IPEndPoint endPoint = new IPEndPoint(hostEntry.AddressList[0], 11000);

        Socket s = new Socket(endPoint.Address.AddressFamily,
            SocketType.Dgram,
            ProtocolType.Udp);
        
        // Creates an IpEndPoint to capture the identity of the sending host.
        IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
        EndPoint senderRemote = (EndPoint)sender;
        
        // Binding is required with ReceiveFrom calls.
        s.Bind(endPoint);
        
        byte[] msg = new Byte[256];
        Console.WriteLine ("Waiting to receive datagrams from client...");
        // This call blocks. 
        s.ReceiveFrom(msg, SocketFlags.None, ref senderRemote);
        s.Close();
    }
    //</Snippet10>
    //<Snippet11>	
    public static void ReceiveFrom3()
    {
        IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
        IPEndPoint endPoint = new IPEndPoint(hostEntry.AddressList[0], 11000);

        Socket s = new Socket(endPoint.Address.AddressFamily,
            SocketType.Dgram,
            ProtocolType.Udp);
      
        // Creates an IPEndPoint to capture the identity of the sending host.
        IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
        EndPoint senderRemote = (EndPoint)sender;
        
        // Binding is required with ReceiveFrom calls.
        s.Bind(endPoint);
        
        byte[] msg = new Byte[256];
        Console.WriteLine ("Waiting to receive datagrams from client...");
        // This call blocks. 
        s.ReceiveFrom(msg, msg.Length, SocketFlags.None, ref senderRemote);
        s.Close();
    }
    //</Snippet11>
    //<Snippet12>
    public static void ReceiveFrom4()
    {
        IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
        IPEndPoint endPoint = new IPEndPoint(hostEntry.AddressList[0], 11000);

        Socket s = new Socket(endPoint.Address.AddressFamily,
            SocketType.Dgram,
            ProtocolType.Udp);
            
        // Creates an IpEndPoint to capture the identity of the sending host.
        IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
        EndPoint senderRemote = (EndPoint)sender;
        
        // Binding is required with ReceiveFrom calls.
        s.Bind(endPoint);
        byte[] msg = new Byte[256];
        Console.WriteLine ("Waiting to receive datagrams from client...");
        // This call blocks.  
        s.ReceiveFrom(msg, 0, msg.Length, SocketFlags.None, ref senderRemote);
        s.Close();
    }
    //</Snippet12>


    public static void RunUdpTests()
    {
        // Test the upd versions.
      
        ThreadStart myThreadDelegate = new ThreadStart(Sync_Send_Receive.ReceiveFrom1);
        Thread myThread1 = new Thread(myThreadDelegate);
        myThread1.Start();
        
        while (myThread1.IsAlive == true)
        {
            SendTo1();
        }
        myThread1.Join();
        
        Console.WriteLine("UDP test2");
        Thread myThread2 = new Thread(new ThreadStart(Sync_Send_Receive.ReceiveFrom2));
        myThread2.Start();
        while (myThread2.IsAlive == true)
        {
            SendTo2();
        }
        myThread2.Join();
        
        Console.WriteLine("UDP test3");
        Thread myThread3 = new Thread(new ThreadStart(Sync_Send_Receive.ReceiveFrom3));
        myThread3.Start();
        while (myThread3.IsAlive == true)
        {
            SendTo3();
        }
        myThread3.Join();
     
        Console.WriteLine("UDP test4");
        Thread myThread4 = new Thread(new ThreadStart(Sync_Send_Receive.ReceiveFrom4));
        myThread4.Start();
        while (myThread4.IsAlive == true)
        {
            SendTo4();
        }
        myThread4.Join();
     
    }
    //Main tests the snippets.
    // To test tcp - run 2 instances source /s runs server, source /c runs client.
    // To test Upd run source /u.
    
    public static int  Main(string[] args)
    {
        string host;
        bool isServer;
           
        char c = args[0].ToLower()[1];
        if ( c == 'c')
        {
            isServer = false;
            host = "127.0.0.1";
        }
        else if (c == 'u')
        {
            RunUdpTests();
            return 0;
        } 
        else
        {
            host = "localhost";
            isServer = true;
        
        }
        // Set up the endpoint and create the socket.
        IPHostEntry hostEntry = Dns.GetHostEntry(host);
        IPEndPoint endPoint = new IPEndPoint(hostEntry.AddressList[0], 11000);
        
        // Test the TCPIP snippets (Socket.Send and Socket.Receive)

        Socket s = new Socket(endPoint.Address.AddressFamily,
            SocketType.Stream,
            ProtocolType.Tcp);
       
        // Send or receive the test messages.
        if (isServer)
        {
            Socket sender = null;  
            s.Bind(endPoint);
            s.Listen(1);
            while (true) 
            {
                sender = s.Accept();
                // exchange messages with all clients tests 
                for (int i = 0; i< 4; i++)
                {
                    ReceiveTest1(sender);
                }
                sender.Close();
                s.Close();
                Environment.Exit(0);
            }
        }
        else  // Its the client tcp tests.
        {
            try
            {
                s.Connect(endPoint);
                SendReceiveTest1(s);
                SendReceiveTest2(s);
                SendReceiveTest3(s);
                SendReceiveTest4(s);
            }
            finally 
            {
                s.Close();
            }
        }
 
       
        return 0;
        
    }
 
}

