  public void PrintAddress(String IpAddressString)
  {
    // Creates an instance of the IPAddress for the specified IP string in 
    // dotted-quad notation. 
    IPAddress hostIPAddress = IPAddress.Parse(IpAddressString);
    Console.WriteLine("\nThe IP address '" + IpAddressString + "' is {0}", hostIPAddress.ToString()); 
  }