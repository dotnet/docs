				' Create a service host.
				Dim httpUri As New Uri("http://localhost/Calculator")
				Dim sh As New ServiceHost(GetType(Calculator), httpUri)

				' Create a binding that uses a WindowsServiceCredential.
				Dim b As New WSHttpBinding(SecurityMode.Message)
				b.Security.Message.ClientCredentialType = MessageCredentialType.Windows

				' Add an endpoint.
				sh.AddServiceEndpoint(GetType(ICalculator), b, "WindowsCalculator")

				' Get a reference to the WindowsServiceCredential object.
				Dim winCredential As WindowsServiceCredential = sh.Credentials.WindowsAuthentication
				' Print out values.
				Console.WriteLine("IncludeWindowsGroup: {0}", winCredential.IncludeWindowsGroups)
				Console.WriteLine("UserNamePasswordValidationMode: {0}", winCredential.AllowAnonymousLogons)

				Console.ReadLine()