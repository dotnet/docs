
Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.Security.Cryptography.X509Certificates

Namespace Microsoft.ServiceModel.Samples
	Friend Class Client
		Shared Sub Main(ByVal args() As String)
			Dim client As New CalculatorClient()

            'X509Certificate2 cert = new X509Certificate2("c:\\MyClientCert.pfx", "password", X509KeyStorageFlags.DefaultKeySet);
            'client.ClientCredentials.ClientCertificate.Certificate = cert;
            'client.ClientCredentials.UserName.UserName = "migree";
            'client.ClientCredentials.UserName.Password = "Wgth#123";

			Dim value1 As Double = 100.00R
			Dim value2 As Double = 15.99R
			Dim result As Double = client.Add(value1, value2)
			Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result)

			' Call the Subtract service operation.
			value1 = 145.00R
			value2 = 76.54R
			result = client.Subtract(value1, value2)
			Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result)

			' Call the Multiply service operation.
			value1 = 9.00R
			value2 = 81.25R
			result = client.Multiply(value1, value2)
			Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result)

			' Call the Divide service operation.
			value1 = 22.00R
			value2 = 7.00R
			result = client.Divide(value1, value2)
			Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result)

			'Closing the client gracefully closes the connection and cleans up resources
			client.Close()

			Console.WriteLine()
			Console.WriteLine("Press <ENTER> to terminate client.")
			Console.ReadLine()
		End Sub
	End Class
End Namespace
