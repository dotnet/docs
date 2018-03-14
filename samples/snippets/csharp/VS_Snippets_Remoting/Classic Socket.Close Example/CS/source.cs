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
        aSocket.Shutdown(SocketShutdown.Both);
        aSocket.Close();
// </Snippet1>
    }
    
        public static void Main()
        {
			SocketClose();
			
        } 
}
