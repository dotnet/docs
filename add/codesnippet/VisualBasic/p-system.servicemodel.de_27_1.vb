			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			Dim endpoint As ServiceEndpoint = serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			endpoint.Behaviors.Add(New MyEndpointBehavior())

			Console.WriteLine("List all behaviors:")
			For Each behavior As IEndpointBehavior In endpoint.Behaviors
				Console.WriteLine("Behavior: {0}", CType(behavior, Object).ToString())
			Next behavior