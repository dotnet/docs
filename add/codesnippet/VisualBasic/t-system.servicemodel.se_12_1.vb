			' Create a service host.
			Dim httpUri As New Uri("http://localhost/Calculator")
			Dim sh As New ServiceHost(GetType(Calculator), httpUri)

			' Create a binding that uses a username/password credential.
			Dim b As New WSHttpBinding(SecurityMode.Message)
			b.Security.Message.ClientCredentialType = MessageCredentialType.UserName

			' Add an endpoint.
			sh.AddServiceEndpoint(GetType(ICalculator), b, "UserNamePasswordCalculator")

			' Get a reference to the UserNamePasswordServiceCredential object.
			Dim unpCredential As UserNamePasswordServiceCredential = sh.Credentials.UserNameAuthentication
			' Print out values.
			Console.WriteLine("IncludeWindowsGroup: {0}", unpCredential.IncludeWindowsGroups)
			Console.WriteLine("UserNamePasswordValidationMode: {0}", unpCredential.UserNamePasswordValidationMode)
			Console.WriteLine("CachedLogonTokenLifetime.Minutes: {0}", unpCredential.CachedLogonTokenLifetime.Minutes)
			Console.WriteLine("CacheLogonTokens: {0}", unpCredential.CacheLogonTokens)
			Console.WriteLine("MaxCachedLogonTokens: {0}", unpCredential.MaxCachedLogonTokens)

			Console.ReadLine()