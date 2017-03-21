	IPHostEntry lipa = Dns.Resolve("host.contoso.com");
	IPEndPoint lep = new IPEndPoint(lipa.AddressList[0], 11000);

       Socket s = new Socket(lep.Address.AddressFamily,
       	                           SocketType.Dgram,
                                         ProtocolType.Udp);
       
       IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
       EndPoint tempRemoteEP = (EndPoint)sender;
       s.Connect(sender);
       
       try{
            while(true){
                 allDone.Reset();
                 StateObject so2 = new StateObject();
                 so2.workSocket = s;
                 Console.WriteLine("Attempting to Receive data from host.contoso.com");
             
                 s.BeginReceiveFrom(so2.buffer, 0, StateObject.BUFFER_SIZE,0, ref tempRemoteEP,
	                                   new AsyncCallback(Async_Send_Receive.ReceiveFrom_Callback), so2);	
                 allDone.WaitOne();
            }
       }
       catch (Exception e){
            Console.WriteLine(e.ToString());
       }