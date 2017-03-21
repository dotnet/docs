  public void PrintLoopbackAddress()
  {
    // Gets the IP loopback address and converts it to a string.
    String IpAddressString = IPAddress.Loopback.ToString();
    Console.WriteLine("Loopback IP address : " + IpAddressString);
  }