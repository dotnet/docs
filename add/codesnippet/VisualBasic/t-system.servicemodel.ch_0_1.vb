			' Create an instance of the binding to use.
			Dim b As New WSHttpBinding()

			' Get the binding element collection.
			Dim bec As BindingElementCollection = b.CreateBindingElements()

			' Find the SymmetricSecurityBindingElement in the collection.
			' Important: Cast to the SymmetricSecurityBindingElement when using the Find
			' method.
			Dim sbe As SymmetricSecurityBindingElement = CType(bec.Find(Of SecurityBindingElement)(), SymmetricSecurityBindingElement)

			' Get the LocalSecuritySettings from the binding element.
			Dim lc As LocalClientSecuritySettings = sbe.LocalClientSettings

			' Print out values.
			Console.WriteLine("Maximum cookie caching time: {0} days", lc.MaxCookieCachingTime.Days)
			Console.WriteLine("Replay Cache Size: {0}", lc.ReplayCacheSize)
			Console.WriteLine("ReplayWindow: {0} minutes", lc.ReplayWindow.Minutes)
			Console.WriteLine("MaxClockSkew: {0} minutes", lc.MaxClockSkew.Minutes)
			Console.ReadLine()

			' Change the MaxClockSkew to 3 minutes.
			lc.MaxClockSkew = New TimeSpan(0, 0, 3, 0)

			' Print the new value.
			Console.WriteLine("New MaxClockSkew: {0} minutes", lc.MaxClockSkew.Minutes)
			Console.ReadLine()

			' Create an EndpointAddress for the service.
			Dim ea As New EndpointAddress("http://localhost/calculator")

			' Create a client. The binding has the changed MaxClockSkew.
			' CalculatorClient cc = new CalculatorClient(b, ea);
			' Use the new client. (Not shown.)
			' cc.Close();