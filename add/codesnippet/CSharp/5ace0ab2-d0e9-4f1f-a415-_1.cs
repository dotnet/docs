  public static bool messageReceived = false;

  public static void ReceiveCallback(IAsyncResult ar)
  {
    UdpClient u = (UdpClient)((UdpState)(ar.AsyncState)).u;
    IPEndPoint e = (IPEndPoint)((UdpState)(ar.AsyncState)).e;

    Byte[] receiveBytes = u.EndReceive(ar, ref e);
    string receiveString = Encoding.ASCII.GetString(receiveBytes);

    Console.WriteLine("Received: {0}", receiveString);
    messageReceived = true;
  }

  public static void ReceiveMessages()
  {
    // Receive a message and write it to the console.
    IPEndPoint e = new IPEndPoint(IPAddress.Any, listenPort);
    UdpClient u = new UdpClient(e);

    UdpState s = new UdpState();
    s.e = e;
    s.u = u;

    Console.WriteLine("listening for messages");
    u.BeginReceive(new AsyncCallback(ReceiveCallback), s);

    // Do some work while we wait for a message. For this example,
    // we'll just sleep
    while (!messageReceived)
    {
      Thread.Sleep(100);
    }
  }