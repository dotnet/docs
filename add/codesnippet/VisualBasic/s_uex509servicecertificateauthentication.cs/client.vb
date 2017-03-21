'  Snippet for
'  System.ServiceModel.Security.X509ServiceCertificateAuthentication
'  Snippet0,1,2,3,4
'
'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel.Description
Imports System.ServiceModel.Channels
Imports System.ServiceModel
Imports System.ServiceModel.Security
Imports System.Security.Principal
Imports System.Security.Cryptography.X509Certificates
Imports System.ServiceModel.Security.Tokens
Imports System.IdentityModel.Selectors

Namespace Microsoft.ServiceModel.Samples
    'The service contract is defined in generatedProxy.vb, generated from the service by the svcutil tool.
	Friend Class MyCertificateValidator
		Inherits X509CertificateValidator
		Public Overrides Sub Validate(ByVal certificate As X509Certificate2)
			 Throw New Exception("The method or operation is not implemented.")
		End Sub
	End Class

	'Client implementation code.
	Friend Class Client
		Shared Sub Main()
				' <Snippet1>
				' Configure custom certificate validation.
				Dim creds As New ClientCredentials()
				creds.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.Custom
				creds.ServiceCertificate.Authentication.CustomCertificateValidator = New MyCertificateValidator()
				' </Snippet1>
				' <Snippet2>
				Dim creds As New ClientCredentials()

				' Configure chain trust.

				creds.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.ChainTrust

				creds.ServiceCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck
				' </Snippet2>
				' <Snippet3>
				Dim creds As New ClientCredentials()

				' Configure chain trust.
				creds.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.ChainTrust
				creds.ServiceCertificate.Authentication.TrustedStoreLocation = StoreLocation.LocalMachine
				' </Snippet3>

				' <Snippet4>
				Dim clientCreds As New ClientCredentials()
				Console.WriteLine(clientCreds.ServiceCertificate.Authentication)
				' </Snippet4>

            ' Create a client with given client endpoint configuration.
			Dim wcfClient As New CalculatorClient()
			Try
				' set new credentials
				wcfClient.ChannelFactory.Endpoint.Behaviors.Remove(GetType(ClientCredentials))
				wcfClient.ChannelFactory.Endpoint.Behaviors.Add(New MyUserNameClientCredentials())
'                
'                Setting the CertificateValidationMode to PeerOrChainTrust means that if the certificate 
'                is in the Trusted People store, then it will be trusted without performing a
'                validation of the certificate's issuer chain. This setting is used here for convenience so that the 
'                sample can be run without having to have certificates issued by a certificate authority (CA).
'                This setting is less secure than the default, ChainTrust. The security implications of this 
'                setting should be carefully considered before using PeerOrChainTrust in production code. 
'                
				wcfClient.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.PeerOrChainTrust
				' <Snippet0>
				Dim creds As New ClientCredentials()
				' Configure peer trust.
				creds.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.PeerTrust

				' Configure chain trust.
				creds.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.ChainTrust

				' Configure custom certificate validation.
				creds.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.Custom
				creds.ServiceCertificate.Authentication.CustomCertificateValidator = New MyCertificateValidator()
				' </Snippet0>
				' Call the Add service operation.
                Dim value1 = 100.0R
                Dim value2 = 15.99R
                Dim result = wcfClient.Add(value1, value2)
				Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result)

				' Call the Subtract service operation.
				value1 = 145.00R
				value2 = 76.54R
				result = wcfClient.Subtract(value1, value2)
				Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result)

				' Call the Multiply service operation.
				value1 = 9.00R
				value2 = 81.25R
				result = wcfClient.Multiply(value1, value2)
				Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result)

				' Call the Divide service operation.
				value1 = 22.00R
				value2 = 7.00R
				result = wcfClient.Divide(value1, value2)
				Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result)
				wcfClient.Close()
			Catch timeProblem As TimeoutException
				Console.WriteLine("The service operation timed out. " & timeProblem.Message)
				Console.ReadLine()
				wcfClient.Abort()
			Catch commProblem As CommunicationException
				Console.WriteLine("There was a communication problem. " & commProblem.Message + commProblem.StackTrace)
				Console.ReadLine()
				wcfClient.Abort()
			End Try

			Console.WriteLine()
			Console.WriteLine("Press <ENTER> to terminate client.")
			Console.ReadLine()
		End Sub
	End Class
End Namespace
