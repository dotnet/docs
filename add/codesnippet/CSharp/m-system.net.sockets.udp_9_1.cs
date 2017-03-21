
           //Creates an instance of the UdpClient class using a local endpoint.
            IPAddress ipAddress = Dns.Resolve(Dns.GetHostName()).AddressList[0];
            IPEndPoint ipLocalEndPoint = new IPEndPoint(ipAddress, 11000);
           
           try{
                UdpClient udpClient = new UdpClient(ipLocalEndPoint);
           }
           catch (Exception e ) {
                      Console.WriteLine(e.ToString());
           }