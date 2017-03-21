            Dim myServiceHost As New ServiceHost(GetType(CalculatorService))
            ' Create a binding to use.
            Dim binding As New WSHttpBinding()
            binding.Security.Mode = SecurityMode.Message
            binding.Security.Message.ClientCredentialType = _
            MessageCredentialType.Certificate

            ' Set the client certificate.
            myServiceHost.Credentials.ClientCertificate.SetCertificate( _
                    StoreLocation.CurrentUser, _
                    StoreName.My, _
                    X509FindType.FindBySubjectName, _
                    "client.com")