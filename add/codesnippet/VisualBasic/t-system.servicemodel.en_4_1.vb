			' Create an EndpointAddress with a specified address.
			Dim epa1 As New EndpointAddress("http://localhost/ServiceModelSamples")
			Console.WriteLine("The URI of the EndpointAddress is {0}:", epa1.Uri)
			Console.WriteLine()

			'Initialize an EndpointAddress10 from the endpointAddress.
			Dim epa10 As EndpointAddress10 = EndpointAddress10.FromEndpointAddress(epa1)

			'Serialize and then deserializde the Endpoint10 type.

			'Convert the EndpointAddress10 back into an EndpointAddress.
			Dim epa2 As EndpointAddress = epa10.ToEndpointAddress()

			Console.WriteLine("The URI of the EndpointAddress is still {0}:", epa2.Uri)
			Console.WriteLine()