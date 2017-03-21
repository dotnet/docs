			Dim endpnt As ServiceEndpoint = serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			Console.WriteLine("Address: {0}", endpnt.Address)