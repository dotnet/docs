  // This method displays the value of the current host's None address in  
  // standard compressed format. The None address is used by the host to disable
  // listening to client activities on all the interfaces.
  private static void displayIPv6NoneAddress()
  {
    try
    {
      
      // Get the None address.
      IPAddress none  = IPAddress.IPv6None;

      // Transform the None address to a string using the overloaded
      // ToString() method. Note that the resulting string is in the compact 
      // form: "::".
      string ipv6None = none.ToString();

      Console.WriteLine("The IPv6 None address is: " + ipv6None);
    }
    catch (Exception e) 
    {
      Console.WriteLine("[displayIPv6NoneAddress] Exception: " + e.ToString());
    }
  }