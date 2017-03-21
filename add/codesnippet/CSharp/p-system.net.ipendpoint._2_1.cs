    private static void displayEndpointInfo(IPEndPoint endpoint)
    {
      Console.WriteLine("Endpoint.Address : " + endpoint.Address);
      Console.WriteLine("Endpoint.AddressFamily : " + endpoint.AddressFamily);
      Console.WriteLine("Endpoint.Port : " + endpoint.Port);
      Console.WriteLine("Endpoint.ToString() : " + endpoint.ToString());

      Console.WriteLine("Press any key to continue.");
      Console.ReadLine();
    }