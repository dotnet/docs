            //Uses a remote endpoint to establish a socket connection.
            TcpClient tcpClient = new TcpClient ();
            IPAddress ipAddress = Dns.GetHostEntry ("www.contoso.com").AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint (ipAddress, 11004);

            tcpClient.Connect (ipEndPoint);
