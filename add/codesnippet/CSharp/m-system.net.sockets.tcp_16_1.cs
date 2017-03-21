            //Uses the IP address and port number to establish a socket connection.
            TcpClient tcpClient = new TcpClient ();
            IPAddress ipAddress = Dns.GetHostEntry ("www.contoso.com").AddressList[0];

            tcpClient.Connect (ipAddress, 11003);
