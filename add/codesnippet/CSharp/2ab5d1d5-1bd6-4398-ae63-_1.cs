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