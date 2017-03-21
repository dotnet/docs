			' Iterate through the endpoints contained in the ServiceDescription
			Dim sec As ServiceEndpointCollection = svcDesc.Endpoints
			For Each se As ServiceEndpoint In sec
				Console.WriteLine("Endpoint:")
				Console.WriteLine(Constants.vbTab & "Address: {0}", se.Address.ToString())
				Console.WriteLine(Constants.vbTab & "Binding: {0}", se.Binding.ToString())
				Console.WriteLine(Constants.vbTab & "Contract: {0}", se.Contract.ToString())
				Dim behaviors As KeyedByTypeCollection(Of IEndpointBehavior) = se.Behaviors
				For Each behavior As IEndpointBehavior In behaviors
					Console.WriteLine("Behavior: {0}", CType(behavior, Object).ToString())
				Next behavior
			Next se