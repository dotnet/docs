			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			serviceHost.Open()

			Dim icl As IChannelListener = serviceHost.ChannelDispatchers(0).Listener
			Dim dispatcher As New ChannelDispatcher(icl)
			dispatcher.TransactionTimeout = New TimeSpan(100)