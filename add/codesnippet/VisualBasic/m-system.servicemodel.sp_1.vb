		Private Shared Function CreateSpnIdentity() As EndpointIdentity
			Dim self As WindowsIdentity = WindowsIdentity.GetCurrent()
			Dim sid As SecurityIdentifier = self.User

			Dim identity As SpnEndpointIdentity = Nothing

			identity = New SpnEndpointIdentity(String.Format(CultureInfo.InvariantCulture, "host/{0}", GetMachineName()))

			Return identity
		End Function
		Private Shared Function GetMachineName() As String
			Return Dns.GetHostEntry(String.Empty).HostName
		End Function