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