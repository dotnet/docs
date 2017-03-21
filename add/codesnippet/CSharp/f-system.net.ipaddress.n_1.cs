   public static void Main()
   {
      // Gets the IP address indicating that no network interface should be used 
      // and converts it to a string.
      string address = IPAddress.None.ToString();
      Console.WriteLine("IP address : " + address);
   }