using System;
using System.Text;
using System.Net; 
using System.Net.Sockets;

public class MyUdpClientExample{

public static void Main(){
	
//<Snippet1>
// This constructor arbitrarily assigns the local port number.
UdpClient udpClient = new UdpClient(11000);
    try{
         udpClient.Connect("www.contoso.com", 11000);

         // Sends a message to the host to which you have connected.
         Byte[] sendBytes = Encoding.ASCII.GetBytes("Is anybody there?");
      
         udpClient.Send(sendBytes, sendBytes.Length);

         // Sends a message to a different host using optional hostname and port parameters.
         UdpClient udpClientB = new UdpClient();
         udpClientB.Send(sendBytes, sendBytes.Length, "AlternateHostMachineName", 11000);

         //IPEndPoint object will allow us to read datagrams sent from any source.
         IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

         // Blocks until a message returns on this socket from a remote host.
         Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint); 
         string returnData = Encoding.ASCII.GetString(receiveBytes);
   
         // Uses the IPEndPoint object to determine which of these two hosts responded.
         Console.WriteLine("This is the message you received " +
    	                              returnData.ToString());
         Console.WriteLine("This message was sent from " +
                                     RemoteIpEndPoint.Address.ToString() +
                                     " on their port number " +
                                     RemoteIpEndPoint.Port.ToString());

          udpClient.Close();
          udpClientB.Close();
          
          }  
       catch (Exception e ) {
                  Console.WriteLine(e.ToString());
        }
//</Snippet1>
   }

 }
