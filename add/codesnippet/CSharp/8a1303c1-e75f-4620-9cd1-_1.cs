  public static bool messageSent = false;

  public static void SendCallback(IAsyncResult ar)
  {
    UdpClient u = (UdpClient)ar.AsyncState;

    Console.WriteLine("number of bytes sent: {0}", u.EndSend(ar));
    messageSent = true;
  }