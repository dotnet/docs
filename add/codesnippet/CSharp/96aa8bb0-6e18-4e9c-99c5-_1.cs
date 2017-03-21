    public static void ReceiveFrom3()
    {
        IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
        IPEndPoint endPoint = new IPEndPoint(hostEntry.AddressList[0], 11000);

        Socket s = new Socket(endPoint.Address.AddressFamily,
            SocketType.Dgram,
            ProtocolType.Udp);
      
        // Creates an IPEndPoint to capture the identity of the sending host.
        IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
        EndPoint senderRemote = (EndPoint)sender;
        
        // Binding is required with ReceiveFrom calls.
        s.Bind(endPoint);
        
        byte[] msg = new Byte[256];
        Console.WriteLine ("Waiting to receive datagrams from client...");
        // This call blocks. 
        s.ReceiveFrom(msg, msg.Length, SocketFlags.None, ref senderRemote);
        s.Close();
    }