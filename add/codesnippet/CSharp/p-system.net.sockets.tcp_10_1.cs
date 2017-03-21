    public static void listenerOption(string host, int port)
    {
        IPHostEntry server = Dns.Resolve(host);
        IPAddress ipAddress = server.AddressList[0];

        Console.WriteLine("listening on {0}, port {1}", ipAddress, port);
        TcpListener listener = new TcpListener(ipAddress, port);
        Socket listenerSocket = listener.Server;		

        LingerOption lingerOption = new LingerOption(true, 10);
        listenerSocket.SetSocketOption(SocketOptionLevel.Socket, 
                          SocketOptionName.Linger, 
                          lingerOption);

        // start listening and process connections here.
        listener.Start();

    }