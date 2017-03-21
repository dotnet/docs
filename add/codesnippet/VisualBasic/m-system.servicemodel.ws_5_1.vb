        Dim binding As New WSHttpBinding()
        With binding
            .Name = "binding1"
            .HostNameComparisonMode = HostNameComparisonMode.StrongWildcard
            .Security.Mode = SecurityMode.Message
            .ReliableSession.Enabled = False
            .TransactionFlow = False
        End With
		