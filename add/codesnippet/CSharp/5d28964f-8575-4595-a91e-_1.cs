       UdpClient udpClient = new UdpClient();

       Byte[] sendBytes = Encoding.ASCII.GetBytes("Is anybody there");
       try{
           udpClient.Send(sendBytes, sendBytes.Length, "www.contoso.com", 11000);
       }
       catch ( Exception e ){
           Console.WriteLine(e.ToString());	
       }