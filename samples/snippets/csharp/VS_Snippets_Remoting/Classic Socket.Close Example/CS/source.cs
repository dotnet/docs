using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

public class Sample
{
    public static void SocketClose()
    {
	    Socket aSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        // <Snippet1>
        try
        {
            aSocket.Shutdown(SocketShutdown.Both);
        }
        finally
        {
            aSocket.Close();
        }
// </Snippet1>
    }
    
        public static void Main()
        {
			SocketClose();
        } 
}
