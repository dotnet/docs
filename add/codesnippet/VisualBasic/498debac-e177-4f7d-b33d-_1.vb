			' Create ServiceDescription from a collection of service endpoints
			Dim endpoints As New List(Of ServiceEndpoint)()
			Dim conDescr As New ContractDescription("ICalculator")
			Dim endpointAddress As New EndpointAddress("http://localhost:8001/Basic")
			Dim ep As New ServiceEndpoint(conDescr, New BasicHttpBinding(), endpointAddress)
			endpoints.Add(ep)
			Dim sd2 As New ServiceDescription(endpoints)