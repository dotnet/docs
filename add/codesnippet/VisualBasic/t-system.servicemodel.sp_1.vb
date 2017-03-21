	   Private Shared Function CreateIdentity() As EndpointIdentity
			Dim self As WindowsIdentity = WindowsIdentity.GetCurrent()
			Dim sid As SecurityIdentifier = self.User

			Dim identity As EndpointIdentity = Nothing

			If sid.IsWellKnown(WellKnownSidType.LocalSystemSid) OrElse sid.IsWellKnown(WellKnownSidType.NetworkServiceSid) OrElse sid.IsWellKnown(WellKnownSidType.LocalServiceSid) Then
				identity = EndpointIdentity.CreateSpnIdentity(String.Format(CultureInfo.InvariantCulture, "host/{0}", GetMachineName()))
			Else
				' Need an UPN string here
				Dim domain As String = GetPrimaryDomain()
				If domain IsNot Nothing Then
					Dim split() As String = self.Name.Split("\"c)
					If split.Length = 2 Then
						identity = EndpointIdentity.CreateUpnIdentity(split(1) & "@" & domain)
					End If
				End If
			End If

			Return identity
	   End Function