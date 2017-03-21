            Dim binding As New WSHttpBinding()
            binding.Security.Mode = SecurityMode.Message
            binding.Security.Message.ClientCredentialType = _
            MessageCredentialType.UserName
            binding.Security.Message.NegotiateServiceCredential = False

            Dim CalculatorClient As New CalculatorClient("myBinding")
            CalculatorClient.ClientCredentials.ServiceCertificate. _
                SetDefaultCertificate("Al", StoreLocation.CurrentUser, StoreName.My)