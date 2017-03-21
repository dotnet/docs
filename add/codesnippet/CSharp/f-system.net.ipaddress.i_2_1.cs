  // This method displays the value of the current host's Any address in  
  // standard compressed format. The Any address is used by the host to enable
  // listening to client activities on all the interfaces for a given port.
  private static void displayIPv6AnyAddress()
  {
    try
    {
      // Get the Any address.
      IPAddress any = IPAddress.IPv6Any;

      // Transform the Any address to a string using the overloaded
      // ToString() method. Note that the resulting string is in the compact 
      // form: "::".
      string ipv6Any = any.ToString();
      
      // Display the Any address.
      Console.WriteLine("The IPv6 Any address is: " + ipv6Any);
    }
    catch (Exception e) 
    {
      Console.WriteLine("[displayIPv6AnyAddress] Exception: " + e.ToString());
    }
  }