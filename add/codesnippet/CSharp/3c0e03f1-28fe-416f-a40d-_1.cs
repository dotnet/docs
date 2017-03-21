	IPHostEntry lipa = Dns.Resolve("host.contoso.com");
	IPEndPoint lep = new IPEndPoint(lipa.AddressList[0], 11000);

       Socket s = new Socket(lep.Address.AddressFamily,
       	                           SocketType.Stream,
                                         ProtocolType.Tcp);
       try{
          
                 while(true){
                 allDone.Reset();

                 byte[] buff = Encoding.ASCII.GetBytes("This is a test");
                 
                 Console.WriteLine("Sending Message Now..");
                 s.BeginSendTo(buff, 0, buff.Length, 0, lep, new AsyncCallback(Async_Send_Receive.SendTo_Callback), s);

                 allDone.WaitOne();
            }
       }
       catch (Exception e){
            Console.WriteLine(e.ToString());
       }