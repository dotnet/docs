			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			' Enable MEX.
			Dim smb As New ServiceMetadataBehavior()
			smb.HttpGetEnabled = True
			serviceHost.Description.Behaviors.Add(smb)

			serviceHost.Open()

			Dim icl As IChannelListener = serviceHost.ChannelDispatchers(0).Listener
			Dim dispatcher As New ChannelDispatcher(icl)
			Console.WriteLine("servicehost has {0} ChannelDispatchers", serviceHost.ChannelDispatchers.Count)
			Dim dispatchers As ChannelDispatcherCollection = serviceHost.ChannelDispatchers

			For Each disp As ChannelDispatcher In dispatchers
				Console.WriteLine("Binding name: " & disp.BindingName)
			Next disp

			Console.WriteLine("The service is ready.")
			Console.WriteLine("Press <ENTER> to terminate service.")
			Console.WriteLine()
			Console.ReadLine()

			' Close the ServiceHostBase to shutdown the service.
			serviceHost.Close()