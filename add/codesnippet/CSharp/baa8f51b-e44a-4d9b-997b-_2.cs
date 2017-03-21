  static void SendMessage2(string server, string message)
  {
    // create the udp socket
    UdpClient u = new UdpClient();
    Byte [] sendBytes = Encoding.ASCII.GetBytes(message);

    // resolve the server name
    IPHostEntry heserver = Dns.GetHostEntry(server);

    IPEndPoint e = new IPEndPoint(heserver.AddressList[0], listenPort);

    // send the message
    // the destination is defined by the IPEndPoint
    u.BeginSend(sendBytes, sendBytes.Length, e,
                new AsyncCallback(SendCallback), u);

    // Do some work while we wait for the send to complete. For 
    // this example, we'll just sleep
    while (!messageSent)
    {
      Thread.Sleep(100);
    }
  }