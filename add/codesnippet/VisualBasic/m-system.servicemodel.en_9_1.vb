			' Create an EndpointAddress with a specified address.
			Dim epa1 As New EndpointAddress("http://localhost/ServiceModelSamples")
			Console.WriteLine("The URI of the EndpointAddress is {0}:", epa1.Uri)
			Console.WriteLine()

			'Initialize an EndpointAddressAugust2004 from the endpointAddress.
			Dim epaA4 As EndpointAddressAugust2004 = EndpointAddressAugust2004.FromEndpointAddress(epa1)

			'Serialize and then deserializde the EndpointAugust2004 type.

			'Convert the EndpointAugust2004 back into an EndpointAddress.
			Dim epa2 As EndpointAddress = epaA4.ToEndpointAddress()

			Console.WriteLine("The URI of the EndpointAddress is still {0}:", epa2.Uri)
			Console.WriteLine()