			 Dim baseAddress As New Uri("http://localhost:8000/servicemodelsamples/service")

			' Create a ServiceHost for the CalculatorService type and provide the base address.
			 Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			' Create a custom binding that contains two binding elements.
			Dim reliableSession As New ReliableSessionBindingElement()
			reliableSession.Ordered = True

			Dim httpTransport As New HttpTransportBindingElement()
			httpTransport.AuthenticationScheme = System.Net.AuthenticationSchemes.Anonymous
			httpTransport.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard

			Dim elements(1) As BindingElement
			elements(0) = reliableSession
			elements(1) = httpTransport

			Dim binding As New CustomBinding(elements)