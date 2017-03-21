  public void NetworkToHostOrder_Short(short networkByte)
  {
    short hostByte;
    // Converts a short value from network byte order to host byte order.
    hostByte = IPAddress.NetworkToHostOrder(networkByte);
    Console.WriteLine("Network byte order to Host byte order of {0} is {1}", networkByte, hostByte);
  }