      Private Shared Sub displayEndpointInfo(ByVal endpoint As IPEndPoint)
        Console.WriteLine("Endpoint Address : " + endpoint.Address.ToString())
        Console.WriteLine("Endpoint AddressFamily : " + endpoint.AddressFamily.ToString())
        Console.WriteLine("Endpoint Port : " + endpoint.Port.ToString())
        Console.WriteLine("Endpoint ToString() : " + endpoint.ToString())

        Console.WriteLine("Press any key to continue.")
        Console.ReadLine()
      End Sub 'displayEndpointInfo
