        TcpClient client = new TcpClient();
        Socket s = client.Client;

        if (!s.Connected)
        {
            s.SetSocketOption(SocketOptionLevel.Socket, 
                         SocketOptionName.ReceiveBuffer, 16384);
            Console.WriteLine(
                "client is not connected, ReceiveBuffer set\n");
        }
        else
           Console.WriteLine("client is connected");