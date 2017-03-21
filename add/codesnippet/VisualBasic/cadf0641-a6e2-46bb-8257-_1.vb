			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)
			Dim binding As New WSHttpBinding()

			serviceHost.AddServiceEndpoint(GetType(ICalculator), binding, "CalculatorServiceObject")

			serviceHost.Open()

			Dim icl As IChannelListener = serviceHost.ChannelDispatchers(0).Listener
			Dim dispatcher As New ChannelDispatcher(icl, "MyTestBinding", binding)