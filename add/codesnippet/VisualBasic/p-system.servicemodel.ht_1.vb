            ' The code uses a shortcut to specify the security mode to Transport.
            Dim b As WSHttpBinding = New WSHttpBinding(SecurityMode.Transport)
            b.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows