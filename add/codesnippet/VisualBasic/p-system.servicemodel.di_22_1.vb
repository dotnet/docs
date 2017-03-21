			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			serviceHost.Open()

			Dim dispatcher As ChannelDispatcher = CType(serviceHost.ChannelDispatchers(0), ChannelDispatcher)
			Dim col As SynchronizedCollection(Of EndpointDispatcher) = dispatcher.Endpoints