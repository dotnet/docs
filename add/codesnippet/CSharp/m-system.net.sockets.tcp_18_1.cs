        //Creates an instance of the TcpListener class by providing a local port number.  
		IPAddress ipAddress = Dns.Resolve("localhost").AddressList[0];
        try{
            TcpListener tcpListener =  new TcpListener(ipAddress, 13);    
        }
        catch ( Exception e ){
            Console.WriteLine( e.ToString());
        }
