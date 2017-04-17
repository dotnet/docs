'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.Configuration
Imports System.Messaging
Imports System.ServiceModel
Imports System.Transactions

Namespace Microsoft.ServiceModel.Samples
	'The service contract is defined in generatedProxy.cs, generated from the service by the svcutil tool.
	' <Snippet11>
	'Client implementation code.
	Friend Class Client
		Shared Sub Main()
			' <Snippet7>
			' Create a client with given client endpoint configuration.
			Dim client As New QueueCalculatorClient()
			Try
				'Create a transaction scope.
				Using scope As New TransactionScope(TransactionScopeOption.Required)
					' Call the Add service operation.
					Dim value1 As Double = 100.00R
					Dim value2 As Double = 15.99R
					client.Add(value1, value2)
					Console.WriteLine("Add({0},{1})", value1, value2)

					' Call the Subtract service operation.
					value1 = 145.00R
					value2 = 76.54R
					client.Subtract(value1, value2)
					Console.WriteLine("Subtract({0},{1})", value1, value2)

					' Call the Multiply service operation.
					value1 = 9.00R
					value2 = 81.25R
					client.Multiply(value1, value2)
					Console.WriteLine("Multiply({0},{1})", value1, value2)

					' Call the Divide service operation.
					value1 = 22.00R
					value2 = 7.00R
					client.Divide(value1, value2)
					Console.WriteLine("Divide({0},{1})", value1, value2)

					' Complete the transaction.
					scope.Complete()
				End Using
				client.Close()
			Catch ex As CommunicationException
				client.Abort()
			End Try
			' </Snippet7>

			Console.WriteLine()
			Console.WriteLine("Press <ENTER> to terminate client.")
			Console.ReadLine()
		End Sub
	End Class
	' </Snippet11>
End Namespace
