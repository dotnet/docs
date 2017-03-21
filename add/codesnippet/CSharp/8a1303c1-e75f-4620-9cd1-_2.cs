  static void SendMessage1(string server, string message)
  {
    // create the udp socket
    UdpClient u = new UdpClient();

    u.Connect(server, listenPort);
    Byte [] sendBytes = Encoding.ASCII.GetBytes(message);

    // send the message
    // the destination is defined by the call to .Connect()
    u.BeginSend(sendBytes, sendBytes.Length, 
                new AsyncCallback(SendCallback), u);

    // Do some work while we wait for the send to complete. For 
    // this example, we'll just sleep
    while (!messageSent)
    {
      Thread.Sleep(100);
    }
  }