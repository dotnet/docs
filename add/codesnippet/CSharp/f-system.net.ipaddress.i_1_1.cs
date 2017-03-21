  // This method displays the value of the current host loopback address in  
  // standard compressed format. 
  private static void displayIPv6LoopBackAddress()
  {
    try
    { 
      // Get the loopback address.
      IPAddress loopBack = IPAddress.IPv6Loopback;

      // Transform the loop-back address to a string using the overladed
      // ToString() method. Note that the resulting string is in the compact 
      // form: "::1".
      string ipv6LoopBack = loopBack.ToString();
      Console.WriteLine("The IPv6 Loopback address is: " + ipv6LoopBack);
    }
    catch (Exception e) 
    {
      Console.WriteLine("[displayIPv6LoopBackAddress] Exception: " + e.ToString());
    }
  }