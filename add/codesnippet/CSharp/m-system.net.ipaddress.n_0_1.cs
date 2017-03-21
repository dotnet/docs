  public void NetworkToHostOrder_Integer(int networkByte)
  {
    int hostByte;
    // Converts an integer value from network byte order to host byte order.
    hostByte = IPAddress.NetworkToHostOrder(networkByte);
    Console.WriteLine("Network byte order to Host byte order of {0} is {1}", networkByte, hostByte);
  }