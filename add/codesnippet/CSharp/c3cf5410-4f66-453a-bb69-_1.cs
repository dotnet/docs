	IPHostEntry lipa = Dns.Resolve("host.contoso.com");
	IPEndPoint lep = new IPEndPoint(lipa.AddressList[0], 11000);

       Socket s = new Socket(lep.Address.AddressFamily,
       	                           SocketType.Stream,
                                         ProtocolType.Tcp);
       try{
          
                 while(true){
                 allDone.Reset();

                 Console.WriteLine("Establishing Connection");
                 s.BeginConnect(lep, new AsyncCallback(Async_Send_Receive.Connect_Callback), s);

                 allDone.WaitOne();
            }
       }
       catch (Exception e){
            Console.WriteLine(e.ToString());
       }