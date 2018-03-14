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

public class NetworkStream_ASync_Send_Receive{

public static ManualResetEvent allDone = new ManualResetEvent(false);

public static void MySample(bool networkStreamOwnsSocket){
	
	
       // Create a socket and connect with a remote host.
	IPHostEntry myIpHostEntry = Dns.GetHostEntry("www.contoso.com");
	IPEndPoint myIpEndPoint = new IPEndPoint(myIpHostEntry.AddressList[0], 1001);

       Socket mySocket = new Socket(myIpEndPoint.Address.AddressFamily,
       	                           SocketType.Stream,
                                         ProtocolType.Tcp);
       try{

            //<Snippet1>
            // Example for creating a NetworkStreams
            
            mySocket.Connect(myIpEndPoint);
                     
            // Create the NetworkStream for communicating with the remote host.
            NetworkStream myNetworkStream;
            
            if (networkStreamOwnsSocket){
                 myNetworkStream = new NetworkStream(mySocket, FileAccess.ReadWrite, true);          
            }
            else{
                 myNetworkStream = new NetworkStream(mySocket, FileAccess.ReadWrite);     
            }
    
           //</Snippet1>

           //<Snippet2>
           //Example of CanWrite, and BeginWrite.
           
            // Check to see if this NetworkStream is writable.
            if (myNetworkStream.CanWrite){
               
                 byte[] myWriteBuffer = Encoding.ASCII.GetBytes("Are you receiving this message?");
                 myNetworkStream.BeginWrite(myWriteBuffer, 0, myWriteBuffer.Length, 
                                                              new AsyncCallback(NetworkStream_ASync_Send_Receive.myWriteCallBack), 
                                                              myNetworkStream);
                 allDone.WaitOne();
            }
            else{
                 Console.WriteLine("Sorry.  You cannot write to this NetworkStream.");  
            }
           
            //</Snippet2>

            //<Snippet3>
            // Example of CanRead, and BeginRead.

            // Check to see if this NetworkStream is readable.
            if(myNetworkStream.CanRead){
            	
                byte[] myReadBuffer = new byte[1024];
                myNetworkStream.BeginRead(myReadBuffer, 0, myReadBuffer.Length, 
                                                             new AsyncCallback(NetworkStream_ASync_Send_Receive.myReadCallBack), 
                                                             myNetworkStream);  

                allDone.WaitOne();
            }
            else{
                 Console.WriteLine("Sorry.  You cannot read from this NetworkStream.");
            }

            //</Snippet3>

            // Close the NetworkStream
            myNetworkStream.Close();

       }
       catch (Exception exception){
            Console.WriteLine("Exception Thrown: " + exception.ToString());
       } 
}

//<Snippet4>
// Example of EndWrite
public static void myWriteCallBack(IAsyncResult ar){

     NetworkStream myNetworkStream = (NetworkStream)ar.AsyncState;
     myNetworkStream.EndWrite(ar);
}

//</Snippet4>

//<Snippet5>
// Example of EndRead, DataAvailable and BeginRead.

public static void myReadCallBack(IAsyncResult ar ){

    NetworkStream myNetworkStream = (NetworkStream)ar.AsyncState;
    byte[] myReadBuffer = new byte[1024];
    String myCompleteMessage = "";
    int numberOfBytesRead;

    numberOfBytesRead = myNetworkStream.EndRead(ar);
    myCompleteMessage = 
        String.Concat(myCompleteMessage, Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));    
    
    // message received may be larger than buffer size so loop through until you have it all.
    while(myNetworkStream.DataAvailable){
    	
        myNetworkStream.BeginRead(myReadBuffer, 0, myReadBuffer.Length, 
        	                                       new AsyncCallback(NetworkStream_ASync_Send_Receive.myReadCallBack), 
        	                                       myNetworkStream);  

    }

    // Print out the received message to the console.
    Console.WriteLine("You received the following message : " +
                                myCompleteMessage);
}

//</Snippet5>
public static void Main(String[] args){
    if (args[0] == "yes"){
        NetworkStream_ASync_Send_Receive.MySample(true);
    }
    else if (args[0] == "no"){
    	 NetworkStream_ASync_Send_Receive.MySample(false);
    }
    else{
    	 Console.WriteLine("Must use 'yes' to allow the NetworkStream to own the Socket or " +
    	                            "\n 'no' to prohibit NetworkStream from owning the Socket. ");
    }

}


}

