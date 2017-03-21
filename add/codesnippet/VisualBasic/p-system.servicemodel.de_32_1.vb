			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			Dim endpoint As ServiceEndpoint = serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			Console.WriteLine("Service endpoint {0} contains the following:", endpoint.Name)
			Console.WriteLine("Binding: {0}", endpoint.Binding.ToString())
			Console.WriteLine("Contract: {0}", endpoint.Contract.ToString())
			Console.WriteLine("ListenUri: {0}", endpoint.ListenUri.ToString())
			Console.WriteLine("ListenUriMode: {0}", endpoint.ListenUriMode.ToString())