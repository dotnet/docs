            //Creates a TCPClient using a local end point.
            IPAddress ipAddress = Dns.GetHostEntry (Dns.GetHostName ()).AddressList[0];
            IPEndPoint ipLocalEndPoint = new IPEndPoint(ipAddress, 0);
            TcpClient tcpClientA = new TcpClient (ipLocalEndPoint);