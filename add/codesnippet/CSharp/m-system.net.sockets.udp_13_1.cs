     //Uses a host name and port number to establish a socket connection.
    UdpClient udpClient = new UdpClient();
    try{
        udpClient.Connect("www.contoso.com", 11002);
    }
    catch (Exception e ) {
               Console.WriteLine(e.ToString());
           }