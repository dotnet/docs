            Dim binding As BasicHttpBinding = New BasicHttpBinding("BasicBinding")
            binding.Name = "binding1"
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard
            binding.Security.Mode = BasicHttpSecurityMode.None

            Dim baseAddress As Uri = New Uri("http://localhost:8000/servicemodelsamples/service")
            Dim address As Uri = New Uri("http://localhost:8000/servicemodelsamples/service/calc")

            ' Create a ServiceHost for the CalculatorService type and provide the base address.
            Using serviceHost As ServiceHost = New ServiceHost(GetType(CalculatorService), baseAddress)

                serviceHost.AddServiceEndpoint(GetType(ICalculator), binding, address)

                ' Open the ServiceHost to create listeners and start listening for messages.
                serviceHost.Open()

                ' The service can now be accessed.
                Console.WriteLine("The service is ready.")
                Console.WriteLine("Press <ENTER> to terminate service.")
                Console.WriteLine()
                Console.ReadLine()

                ' Close the ServiceHost to shutdown the service.
                serviceHost.Close()
            End Using