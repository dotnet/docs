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
   