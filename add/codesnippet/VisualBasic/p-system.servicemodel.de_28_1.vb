			' Create the client with the binding and EndpointAddress.
			Dim calcClient As New CalculatorClient(b, ea)

			' Set the client credential value to a valid certificate.
			calcClient.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.TrustedPeople, X509FindType.FindBySubjectName, "client.com")