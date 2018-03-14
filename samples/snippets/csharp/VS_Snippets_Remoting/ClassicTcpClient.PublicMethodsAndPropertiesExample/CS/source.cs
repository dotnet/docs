using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

public class MyTcpClientExample
{
// <Snippet1>
    //  MyTcpClientConstructor is just used to illustrate the different constructors available in the TcpClient class
    public static void MyTcpClientConstructor (string myConstructorType)
    {
        if (myConstructorType == "IPAddressExample")
        {
            // <Snippet2>
            //Creates a TCPClient using a local end point.
            IPAddress ipAddress = Dns.GetHostEntry (Dns.GetHostName ()).AddressList[0];
            IPEndPoint ipLocalEndPoint = new IPEndPoint(ipAddress, 0);
            TcpClient tcpClientA = new TcpClient (ipLocalEndPoint);
            // </Snippet2> 
        }
        else if (myConstructorType == "HostNameExample")
        {
            // <Snippet3>
            //Creates a TCPClient using host name and port.
            TcpClient tcpClientB = new TcpClient ("www.contoso.com", 11000);
            // </Snippet3>
        }
        else if (myConstructorType == "DefaultExample")
        {
            // <Snippet4>
            //Creates a TCPClient using the default constructor.
            TcpClient tcpClientC = new TcpClient ();
            // </Snippet4>  
        }
        else
        {
            // <Snippet15>
            TcpClient tcpClientD = new TcpClient (AddressFamily.InterNetwork);
            // </Snippet15>
        }
    }

    // MyTcpClientConnection class is just used to illustrate the different connection methods of the TcpClient class.
    public static void MyTcpClientConnection (string myConnectionType)
    {
        if (myConnectionType == "HostnameExample")
        {
            // <Snippet5>
            //Uses a host name and port number to establish a socket connection.
            TcpClient tcpClient = new TcpClient ();
            tcpClient.Connect ("www.contoso.com", 11002);

            // </Snippet5>
            tcpClient.Close ();
        }
        else if (myConnectionType == "IPAddressExample")
        {
            // <Snippet6>
            //Uses the IP address and port number to establish a socket connection.
            TcpClient tcpClient = new TcpClient ();
            IPAddress ipAddress = Dns.GetHostEntry ("www.contoso.com").AddressList[0];

            tcpClient.Connect (ipAddress, 11003);

            // </Snippet6>
            tcpClient.Close ();
        }
        else if (myConnectionType == "RemoteEndPointExample")
        {
            // <Snippet7>
            //Uses a remote endpoint to establish a socket connection.
            TcpClient tcpClient = new TcpClient ();
            IPAddress ipAddress = Dns.GetHostEntry ("www.contoso.com").AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint (ipAddress, 11004);

            tcpClient.Connect (ipEndPoint);

            // </Snippet7>
            tcpClient.Close ();
        }
        else
        {
            // Do nothing.
        }
    }

    // MyTcpClientPropertySetter is just used to illustrate setting and getting various properties of the TcpClient class.
    public static void MyTcpClientPropertySetter ()
    {
        TcpClient tcpClient = new TcpClient ();

        // <Snippet8>
        // Sets the receive buffer size using the ReceiveBufferSize public property.
        tcpClient.ReceiveBufferSize = 1024;

        // Gets the receive buffer size using the ReceiveBufferSize public property.
        if (tcpClient.ReceiveBufferSize == 1024)
            Console.WriteLine ("The receive buffer was successfully set to " + tcpClient.ReceiveBufferSize.ToString ());

        // </Snippet8>
        // <Snippet9>
        // Sets the send buffer size using the SendBufferSize public property.
        tcpClient.SendBufferSize = 1024;

        // Gets the send buffer size using the SendBufferSize public property.
        if (tcpClient.SendBufferSize == 1024)
            Console.WriteLine ("The send buffer was successfully set to " + tcpClient.SendBufferSize.ToString ());

        // </Snippet9>
        // <Snippet10>
        // Sets the receive time out using the ReceiveTimeout public property.
        tcpClient.ReceiveTimeout = 5000;

        // Gets the receive time out using the ReceiveTimeout public property.
        if (tcpClient.ReceiveTimeout == 5000)
            Console.WriteLine ("The receive time out limit was successfully set " + tcpClient.ReceiveTimeout.ToString ());

        // </Snippet10>
        // <Snippet11>
        // sets the send time out using the SendTimeout public property.
        tcpClient.SendTimeout = 5;

        // gets the send time out using the SendTimeout public property.
        if (tcpClient.SendTimeout == 5)
            Console.WriteLine ("The send time out limit was successfully set " + tcpClient.SendTimeout.ToString ());

        // </Snippet11>
        // <Snippet12>
        // sets the amount of time to linger after closing, using the LingerOption public property.
        LingerOption lingerOption = new LingerOption (true, 10);

        tcpClient.LingerState = lingerOption;

        // gets the amount of linger time set, using the LingerOption public property.
        if (tcpClient.LingerState.LingerTime == 10)
            Console.WriteLine ("The linger state setting was successfully set to " + tcpClient.LingerState.LingerTime.ToString ());

        // </Snippet12>
        // <Snippet13>
        // Sends data immediately upon calling NetworkStream.Write.
        tcpClient.NoDelay = true;

        // Determines if the delay is enabled by using the NoDelay property.
        if (tcpClient.NoDelay == true)
            Console.WriteLine ("The delay was set successfully to " + tcpClient.NoDelay.ToString ());

        // </Snippet13>
        tcpClient.Close ();
    }

    public static void MyTcpClientCommunicator ()
    {
        // <Snippet14>
        TcpClient tcpClient = new TcpClient ();

        // Uses the GetStream public method to return the NetworkStream.
        NetworkStream netStream = tcpClient.GetStream ();

        if (netStream.CanWrite)
        {
            Byte[] sendBytes = Encoding.UTF8.GetBytes ("Is anybody there?");
            netStream.Write (sendBytes, 0, sendBytes.Length);
        }
        else
        {
            Console.WriteLine ("You cannot write data to this stream.");
            tcpClient.Close ();

            // Closing the tcpClient instance does not close the network stream.
            netStream.Close ();
            return;
        }

        if (netStream.CanRead)
        {
            // Reads NetworkStream into a byte buffer.
            byte[] bytes = new byte[tcpClient.ReceiveBufferSize];

            // Read can return anything from 0 to numBytesToRead. 
            // This method blocks until at least one byte is read.
            netStream.Read (bytes, 0, (int)tcpClient.ReceiveBufferSize);

            // Returns the data received from the host to the console.
            string returndata = Encoding.UTF8.GetString (bytes);

            Console.WriteLine ("This is what the host returned to you: " + returndata);
            
        }
        else
        {
            Console.WriteLine ("You cannot read data from this stream.");
            tcpClient.Close ();

            // Closing the tcpClient instance does not close the network stream.
            netStream.Close ();
            return;
        }
        netStream.Close();

        // </Snippet14>
        
    }

    public static void Main ()
    {
        // Using the default constructor.
        MyTcpClientConstructor ("DefaultExample");

        // Establish a connection by using the hostname and port number.
        MyTcpClientConnection ("HostnameExample");

        // Set and verify all communication parameters before attempting communication.
        MyTcpClientPropertySetter ();

        // Send and receive data using tcpClient class.
        MyTcpClientCommunicator ();
// </Snippet1>
    }
} //end class




