           //Creates an instance of the UdpClient class to listen on
           // the default interface using a particular port.
           try{
                    UdpClient udpClient = new UdpClient(11000);
           }  
           catch (Exception e ) {
                     Console.WriteLine(e.ToString());
             }