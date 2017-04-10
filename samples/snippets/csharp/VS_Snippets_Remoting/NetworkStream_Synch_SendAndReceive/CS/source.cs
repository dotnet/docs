// The following sample is intended to demonstrate how to use a 
//NetworkStream for synchronous communcation with a remote host
//This class uses several NetworkStream members that would be useful
// in a synchronous communciation senario

using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class NetworkStream_Sync_Send_Receive{

public static void MySample(bool networkStreamOwnsSocket){
	
      //<Snippet1> 
      // This should be the classwide example.
  
       // Create a socket and connect with a remote host.
  IPHostEntry myIpHostEntry = Dns.GetHostEntry("www.contoso.com");
  IPEndPoint myIpEndPoint = new IPEndPoint(myIpHostEntry.AddressList[0], 1001);

       Socket mySocket = new Socket(myIpEndPoint.Address.AddressFamily,
                                  SocketType.Stream,
                                         ProtocolType.Tcp);
       try{
            mySocket.Connect(myIpEndPoint);
       
            //<Snippet2>  
            // Examples for constructors that do not specify file permission.
            
            // Create the NetworkStream for communicating with the remote host.
            NetworkStream myNetworkStream;
            
            if (networkStreamOwnsSocket){
                 myNetworkStream = new NetworkStream(mySocket, true);          
            }
            else{
                 myNetworkStream = new NetworkStream(mySocket);     
            }
            //</Snippet2>           

            //<Snippet3>  
            // Examples for CanWrite, and CanWrite  
           
            // Check to see if this NetworkStream is writable.
            if (myNetworkStream.CanWrite){
               
                 byte[] myWriteBuffer = Encoding.ASCII.GetBytes("Are you receiving this message?");
                 myNetworkStream.Write(myWriteBuffer, 0, myWriteBuffer.Length);
            }
            else{
                 Console.WriteLine("Sorry.  You cannot write to this NetworkStream.");  
            }

            //</Snippet3>

            //<Snippet4>   
            // Examples for CanRead, Read, and DataAvailable.
           
            // Check to see if this NetworkStream is readable.
            if(myNetworkStream.CanRead){
                byte[] myReadBuffer = new byte[1024];
                StringBuilder myCompleteMessage = new StringBuilder();
                int numberOfBytesRead = 0;

                // Incoming message may be larger than the buffer size.
                do{
                     numberOfBytesRead = myNetworkStream.Read(myReadBuffer, 0, myReadBuffer.Length);

					 myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));
				 					
                }
                while(myNetworkStream.DataAvailable);

                // Print out the received message to the console.
                Console.WriteLine("You received the following message : " +
                                             myCompleteMessage);
            }
            else{
                 Console.WriteLine("Sorry.  You cannot read from this NetworkStream.");
            }

            //</Snippet4>

            //<Snippet5>  
            // Example for closing the NetworkStream.

            // Close the NetworkStream
            myNetworkStream.Close();

            //</Snippet5>
       }
       catch (Exception exception){
            Console.WriteLine("Exception Thrown: " + exception.ToString());
       } 
}

//</Snippet1>

public static void Main(String[] args){
    if (args[0] == "yes"){
        NetworkStream_Sync_Send_Receive.MySample(true);
    }
    else if (args[0] == "no"){
    	 NetworkStream_Sync_Send_Receive.MySample(false);
    }
    else{
    	 Console.WriteLine("Must use 'yes' to allow the NetworkStream to own the Socket or " +
    	                            "\n 'no' to prohibit NetworkStream from owning the Socket. ");
    }

}


}

