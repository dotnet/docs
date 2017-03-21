        ' Create a WSHttpBinding and set its security properties. The
        ' security mode is Message, and the client is authenticated with 
        ' a certificate.
        Dim ea As New EndpointAddress("http://contoso.com/")
        Dim b As New WSHttpBinding()
        b.Security.Mode = SecurityMode.Message
        b.Security.Message.ClientCredentialType = MessageCredentialType.Certificate
        
        ' Create the client with the binding and EndpointAddress.
        Dim cc As New CalculatorClient(b, ea)
        
        ' Set the client credential value to a valid certificate.
        cc.ClientCredentials.ClientCertificate.SetCertificate( _
           StoreLocation.CurrentUser, _
           StoreName.TrustedPeople, _
           X509FindType.FindBySubjectName, _
           "client.com")