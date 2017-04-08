using System;
using System.Text;
using System.Net; 
using System.Net.Sockets;

public class MyUdpClientExample{

    //  MyUdpClientConstructor is just used to illustrate the different constructors available in in the UdpClient class.
    public static void MyUdpClientConstructor(string myConstructorType){

    if (myConstructorType == "PortNumberExample"){
           // <Snippet1>
           //Creates an instance of the UdpClient class to listen on
           // the default interface using a particular port.
           try{
                    UdpClient udpClient = new UdpClient(11000);
           }  
           catch (Exception e ) {
                     Console.WriteLine(e.ToString());
             }
           // </Snippet1> 
          
        }
    else if (myConstructorType == "LocalEndPointExample"){
           // <Snippet2>

           //Creates an instance of the UdpClient class using a local endpoint.
            IPAddress ipAddress = Dns.Resolve(Dns.GetHostName()).AddressList[0];
            IPEndPoint ipLocalEndPoint = new IPEndPoint(ipAddress, 11000);
           
           try{
                UdpClient udpClient = new UdpClient(ipLocalEndPoint);
           }
           catch (Exception e ) {
                      Console.WriteLine(e.ToString());
           }
          // </Snippet2>
       }
    else if (myConstructorType == "HostNameAndPortNumExample"){
           // <Snippet3>

           //Creates an instance of the UdpClient class with a remote host name and a port number.
           try{
                UdpClient udpClient = new UdpClient("www.contoso.com",11000);
           }
           catch (Exception e ) {
                      Console.WriteLine(e.ToString());
           }
          // </Snippet3>
    }
    else if (myConstructorType == "DefaultExample"){
           // <Snippet4>
           //Creates an instance of the UdpClient class using the default constructor.
           UdpClient udpClient = new UdpClient();
           // </Snippet4>  
    }
    else{
     // Do nothing.
    }
     }

  // MyUdpClientConnection method is just used to illustrate the different connection methods of UdpClient class.
  public static void MyUdpClientConnection(string myConnectionType){
  	
  if (myConnectionType == "HostnameAndPortNumExample"){
      // <Snippet5>
     //Uses a host name and port number to establish a socket connection.
    UdpClient udpClient = new UdpClient();
    try{
        udpClient.Connect("www.contoso.com", 11002);
    }
    catch (Exception e ) {
               Console.WriteLine(e.ToString());
           }
    // </Snippet5>
  }

  else if (myConnectionType == "IPAddressAndPortNumExample"){
      // <Snippet6>
      //Uses the IP address and port number to establish a socket connection.
      UdpClient udpClient = new UdpClient();
      IPAddress ipAddress = Dns.Resolve("www.contoso.com").AddressList[0];
      try{
          udpClient.Connect(ipAddress, 11003);
      }
      catch (Exception e ) {
                 Console.WriteLine(e.ToString());
      }
      // </Snippet6>
  }
  else if (myConnectionType == "RemoteEndPointExample"){
   // <Snippet7>
   //Uses a remote endpoint to establish a socket connection.
   UdpClient udpClient = new UdpClient();
   IPAddress ipAddress = Dns.Resolve("www.contoso.com").AddressList[0];
   IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 11004);
   try{
   	udpClient.Connect(ipEndPoint);
   }
   catch (Exception e ) {
              Console.WriteLine(e.ToString());
          }
   // </Snippet7>
  }
 else{
 // Do nothing.
 }
  }

  // This class demonstrates sending and receiving using a Udp socket.
  public static void MyUdpClientCommunicator(string mySendType){

   
   if (mySendType == "EndPointExample"){

   	// <Snippet8>
       UdpClient udpClient = new UdpClient();
       IPAddress ipAddress = Dns.Resolve("www.contoso.com").AddressList[0];
       IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 11004);	
       
       Byte[] sendBytes = Encoding.ASCII.GetBytes("Is anybody there?");
       try{
           udpClient.Send(sendBytes, sendBytes.Length, ipEndPoint);
       }
       catch ( Exception e ){
           Console.WriteLine(e.ToString());	
       }
       //</Snippet8>
   }
   else if (mySendType == "HostNameAndPortNumberExample"){

       //<Snippet9>
       UdpClient udpClient = new UdpClient();

       Byte[] sendBytes = Encoding.ASCII.GetBytes("Is anybody there");
       try{
           udpClient.Send(sendBytes, sendBytes.Length, "www.contoso.com", 11000);
       }
       catch ( Exception e ){
           Console.WriteLine(e.ToString());	
       }
       //</Snippet9>
   } 
   else if (mySendType == "StraightSendExample"){
        //<Snippet10>
       UdpClient udpClient = new UdpClient("www.contoso.com", 11000);
       Byte[] sendBytes = Encoding.ASCII.GetBytes("Is anybody there");
       try{
           udpClient.Send(sendBytes, sendBytes.Length);
       }
       catch ( Exception e ){
           Console.WriteLine( e.ToString());
       }
        //</Snippet10>
   }

   else{
   // Do nothing.
   }
   
   //<Snippet11>
   //Creates a UdpClient for reading incoming data.
   UdpClient receivingUdpClient = new UdpClient(11000);

   //Creates an IPEndPoint to record the IP Address and port number of the sender. 
  // The IPEndPoint will allow you to read datagrams sent from any source.
   IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
   try{

       // Blocks until a message returns on this socket from a remote host.
       Byte[] receiveBytes = receivingUdpClient.Receive(ref RemoteIpEndPoint); 

       string returnData = Encoding.ASCII.GetString(receiveBytes);
   
       Console.WriteLine("This is the message you received " +
   	                             returnData.ToString());
       Console.WriteLine("This message was sent from " +
                                   RemoteIpEndPoint.Address.ToString() +
                                   " on their port number " +
                                   RemoteIpEndPoint.Port.ToString());
   }
   catch ( Exception e ){
       Console.WriteLine(e.ToString()); 
   }
   
   //</Snippet11>

  }

  // This example class demonstrates methods used to join and drop multicast groups.
  
  public static void MyUdpClientMulticastConfiguration(string myAction){
  	
      if (myAction == "JoinMultiCastExample"){
           //<Snippet12>
           UdpClient udpClient = new UdpClient();
           IPAddress multicastIpAddress = Dns.Resolve("MulticastGroupName").AddressList[0];  
           try{
               udpClient.JoinMulticastGroup(multicastIpAddress);
           }
           catch ( Exception e ){
               Console.WriteLine( e.ToString());	
           }
          //</Snippet12>
      }
      else if (myAction == "JoinMultiCastWithTimeToLiveExample"){
      	
           //<Snippet13>
           UdpClient udpClient = new UdpClient();
           // Creates an IPAddress to use to join and drop the multicast group.
           IPAddress multicastIpAddress = IPAddress.Parse("239.255.255.255");
           
           try{
                // The packet dies after 50 router hops.
                udpClient.JoinMulticastGroup(multicastIpAddress, 50);
           }
           catch ( Exception e ){
               Console.WriteLine( e.ToString());
           }
          //</Snippet13>
         //<Snippet14>
         // Informs the server that you want to remove yourself from the multicast client list.
         try{
             udpClient.DropMulticastGroup(multicastIpAddress);
         }
         catch ( Exception e ){
             Console.WriteLine( e.ToString());
         }
        //</Snippet14>
        //<Snippet15>
        // Closes the UDP client by calling the public method Close().
        udpClient.Close();
        //</Snippet15>
      }
      else{
      // Do nothing.
      }
  }

  public static void Main(){

  // For our example, we will use the default constructor.
  MyUdpClientConstructor("defaultExample");
  MyUdpClientConnection("HostNameAndPortNumExample");
  MyUdpClientCommunicator("EndPointExample");
  MyUdpClientMulticastConfiguration("JoinMultiCastExample");
  
     } 
  
 } //end class




