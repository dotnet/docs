  static void SendMessage3(string server, string message)
  {
    // create the udp socket
    UdpClient u = new UdpClient();

    Byte [] sendBytes = Encoding.ASCII.GetBytes(message);

    // send the message
    // the destination is defined by the server name and port
    u.BeginSend(sendBytes, sendBytes.Length, server, listenPort,
                new AsyncCallback(SendCallback), u);

    // Do some work while we wait for the send to complete. For 
    // this example, we'll just sleep
    while (!messageSent)
    {
      Thread.Sleep(100);
    }
  }