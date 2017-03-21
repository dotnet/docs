            //Uses a host name and port number to establish a socket connection.
            TcpClient tcpClient = new TcpClient ();
            tcpClient.Connect ("www.contoso.com", 11002);
