			Dim baseAddress As New Uri("http://localhost:8000/servicemodelsamples/service")

			' Create a ServiceHost for the CalculatorService type and provide the base address.
			Using serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)
				' Create a custom binding that contains two binding elements.
				Dim reliableSession As New ReliableSessionBindingElement()
				reliableSession.Ordered = True

				Dim httpTransport As New HttpTransportBindingElement()
				httpTransport.AuthenticationScheme = System.Net.AuthenticationSchemes.Anonymous
				httpTransport.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard

				Dim binding As New CustomBinding(reliableSession, httpTransport)

				' Add an endpoint using that binding.
				serviceHost.AddServiceEndpoint(GetType(ICalculator), binding, "")

				' Add a MEX endpoint.
				Dim smb As New ServiceMetadataBehavior()
				smb.HttpGetEnabled = True
				smb.HttpGetUrl = New Uri("http://localhost:8001/servicemodelsamples")
				serviceHost.Description.Behaviors.Add(smb)

				' Open the ServiceHostBase to create listeners and start listening for messages.
				serviceHost.Open()

				' The service can now be accessed.
				Console.WriteLine("The service is ready.")
				Console.WriteLine("Press <ENTER> to terminate service.")
				Console.WriteLine()
				Console.ReadLine()

				' Close the ServiceHostBase to shutdown the service.
				serviceHost.Close()
			End Using