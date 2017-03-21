			Dim baseAddress As New Uri("http://localhost:8000/servicemodelsamples/service")

			' Create a ServiceHost for the CalculatorService type and provide the base address.
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			' Create a custom binding that contains two binding elements.
			Dim reliableSession As New ReliableSessionBindingElement()
			reliableSession.Ordered = True

			Dim httpTransport As New HttpTransportBindingElement()
			httpTransport.AuthenticationScheme = System.Net.AuthenticationSchemes.Anonymous
			httpTransport.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard

			Dim coll As New SynchronizedCollection(Of BindingElement)()
			coll.Add(reliableSession)
			coll.Add(httpTransport)

			Dim binding As New CustomBinding(coll)