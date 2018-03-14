using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class MyTcpListenerExample{
    public static int Main(string [] args){

	if (args.Length == 0)
	{
		Console.WriteLine("Enter a selection");
		return 0;
	}
	
    if (args[0] == "endpointExample"){

        //<Snippet1>
        //Creates an instance of the TcpListener class by providing a local endpoint.

        IPAddress ipAddress = Dns.Resolve(Dns.GetHostName()).AddressList[0];
        IPEndPoint ipLocalEndPoint = new IPEndPoint(ipAddress, 11000); 

        try{
            TcpListener tcpListener = new TcpListener(ipLocalEndPoint);
        }
        catch ( Exception e ){
            Console.WriteLine( e.ToString());
        }
        //</Snippet1>
    }
    else if (args[0] == "ipAddressExample"){

        //<Snippet2>
        //Creates an instance of the TcpListener class by providing a local IP address and port number.

        IPAddress ipAddress = Dns.Resolve("localhost").AddressList[0];

        try{
            TcpListener tcpListener =  new TcpListener(ipAddress, 13);    
        }
        catch ( Exception e){
            Console.WriteLine( e.ToString());
        }
    
        //</Snippet2>
    }
    else if (args[0] == "portNumberExample"){

        //<Snippet3>
        //Creates an instance of the TcpListener class by providing a local port number.  
		IPAddress ipAddress = Dns.Resolve("localhost").AddressList[0];
        try{
            TcpListener tcpListener =  new TcpListener(ipAddress, 13);    
        }
        catch ( Exception e ){
            Console.WriteLine( e.ToString());
        }

        //</Snippet3>
    	}
      else { 
      				IPAddress ipAddress = Dns.Resolve("localhost").AddressList[0];

            		TcpListener tcpListener =  new TcpListener(ipAddress, 13);    

          			tcpListener.Start();

		          Console.WriteLine("Waiting for a connection....");
		                
          try{
              //<Snippet4>
	       
              // Accepts the pending client connection and returns a socket for communciation.
               Socket socket = tcpListener.AcceptSocket();
		 		Console.WriteLine("Connection accepted.");

               string responseString = "You have successfully connected to me";

               //Forms and sends a response string to the connected client.
               Byte[] sendBytes = Encoding.ASCII.GetBytes(responseString);
               int i = socket.Send(sendBytes);
               Console.WriteLine("Message Sent /> : " + responseString);
               //</Snippet4>    
               //Any communication with the remote client using the socket can go here.

               //Closes the tcpListener and the socket.
               socket.Shutdown(SocketShutdown.Both);
               socket.Close();
	        tcpListener.Stop();

               }
               catch (Exception e) {
			        Console.WriteLine(e.ToString());
	    	 }
      	   }
          return 0;
      }

    }


