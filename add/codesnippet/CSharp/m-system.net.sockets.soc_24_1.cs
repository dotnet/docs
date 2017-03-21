	IPHostEntry lipa = Dns.Resolve("host.contoso.com");
	IPEndPoint lep = new IPEndPoint(lipa.AddressList[0], 11000);

       Socket s = new Socket(lep.Address.AddressFamily,
       	                           SocketType.Stream,
                                         ProtocolType.Tcp);
       try{
            s.Bind(lep);
            s.Listen(1000);

            while(true){
                 allDone.Reset();

                 Console.WriteLine("Waiting for a connection...");
                 s.BeginAccept(new AsyncCallback(Async_Send_Receive.Listen_Callback), s);

                 allDone.WaitOne();
            }
       }
       catch (Exception e){
            Console.WriteLine(e.ToString());
       }