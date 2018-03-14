// System.Net.IPEndPoint.MaxPort; System.Net.IPEndPoint.MinPort;
// System.Net.IPEndPoint.AddressFamily; System.Net.IPEndPoint.IPEndPoint(long,int)
// System.Net.IPEndPoint.Address; System.Net.IPEndPoint.Port;

/*This program demonstrates the properties 'MaxPort', 'MinPort','Address','Port'
  and 'AddressFamily' and a constructor 'IPEndPoint(long,int)' of class 'IPEndPoint'.
  
  A procedure DoSocketGet is created which internally uses a socket to transmit http "Get" requests to a Web resource.
  The program accepts a resource Url, Resolves it to obtain 'IPAddress',Constructs 'IPEndPoint' instance using this 
  'IPAddress' and port 80.Invokes DoSocketGet procedure to obtain a response and displays the response to a console.
   
  It then accepts another Url, Resolves it to obtain 'IPAddress'. Assigns this IPAddress and port to the 'IPEndPoint'
  and again invokes DoSocketGet to obtain a response and display.
 */

using System;
using System.Net;
using System.Text;
using System.Net.Sockets; 
using System.Runtime.InteropServices;

class IPEndPointSnippet 
{
	public static void Main() 
	{

		
		try
		{
			Console.Write("\nPlease enter an INTRANET Url as shown: [e.g. www.microsoft.com]:");
			string hostString1 = Console.ReadLine();
// <Snippet1>
// <Snippet2>
// <Snippet3>
// <Snippet4>

		

			IPAddress hostIPAddress1 = (Dns.Resolve(hostString1)).AddressList[0];
			Console.WriteLine(hostIPAddress1.ToString());
			IPEndPoint hostIPEndPoint = new IPEndPoint(hostIPAddress1,80);
			Console.WriteLine("\nIPEndPoint information:" + hostIPEndPoint.ToString());
			Console.WriteLine("\n\tMaximum allowed Port Address :" + IPEndPoint.MaxPort);
			Console.WriteLine("\n\tMinimum allowed Port Address :" + IPEndPoint.MinPort);
			Console.WriteLine("\n\tAddress Family :" + hostIPEndPoint.AddressFamily);
// </Snippet4>
			Console.Write("\nPress Enter to continue");Console.ReadLine();
			string getString = "GET / HTTP/1.1\r\nHost: " + hostString1 + "\r\nConnection: Close\r\n\r\n";
			string pageContent = DoSocketGet(hostIPEndPoint,getString);
			if (pageContent != null)
			{
				Console.WriteLine("Default HTML page on " + hostString1 + " is:\r\n" + pageContent);
			}
// </Snippet3>
// </Snippet2>
// </Snippet1>
			Console.Write("\n\n\nPlease enter another INTRANET Url as shown[e.g. www.microsoft.com]: ");
			string hostString2 = Console.ReadLine();
// <Snippet5>
// <Snippet6>		
			IPAddress hostIPAddress2 = (Dns.Resolve(hostString2)).AddressList[0];
			hostIPEndPoint.Address = hostIPAddress2;
			hostIPEndPoint.Port = 80;
		
			getString = "GET / HTTP/1.1\r\nHost: " + hostString2 + "\r\nConnection: Close\r\n\r\n";
			pageContent = DoSocketGet(hostIPEndPoint,getString);
			if (pageContent != null)
			{
				Console.WriteLine("Default HTML page on " + hostString2 + " is:\r\n" + pageContent);
			}
// </Snippet6>
// </Snippet5>		
		}
		catch(SocketException e) 
		{
			Console.WriteLine("SocketException caught!!!");
			Console.WriteLine("Source : " + e.Source);
			Console.WriteLine("Message : " + e.Message);
		}
		catch(Exception e)
		{
			Console.WriteLine("Exception caught!!!");
			Console.WriteLine("Message : " + e.Message);
		}
		
	}
	
	public static string DoSocketGet(IPEndPoint hostIPEndPoint,string getString) 
	{
		try
		{
			// Set up variables and String to write to the server.
			Encoding ASCII = Encoding.ASCII;
			
			Byte[] byteGet = ASCII.GetBytes(getString);
			Byte[] recvBytes = new Byte[256];
			String strRetPage = null;
    		// Create the Socket for sending data over TCP.
			Socket mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
				ProtocolType.Tcp);
			// Connect to host using IPEndPoint.
 			mySocket.Connect(hostIPEndPoint);
			// Send the GET text to the host.
			mySocket.Send(byteGet,byteGet.Length,0);
    		// Receive the page, loop until all bytes are received.
			Int32 byteCount = mySocket.Receive(recvBytes,recvBytes.Length,0);
			strRetPage = strRetPage + ASCII.GetString(recvBytes,0,byteCount);
    		while (byteCount > 0) 
			{
				byteCount = mySocket.Receive(recvBytes,recvBytes.Length,0);
				strRetPage = strRetPage + ASCII.GetString(recvBytes,0,byteCount);
			}
   			return strRetPage;

		}
		catch(Exception e)
		{
			Console.WriteLine("Exception : {0}", e.Message);
			Console.WriteLine("WinSock Error : " + Convert.ToString(Marshal.GetLastWin32Error()));
			return null;
		}
	}
}
