  public void PrintBroadcastAddress()
  {
    // Get the IP Broadcast address and convert it to string.
    string ipAddressString = IPAddress.Broadcast.ToString();
    Console.WriteLine("Broadcast IP address: {0}", ipAddressString);
  }