'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples
	'The service contract is defined in generatedProxy.cs, generated from the service by the svcutil tool.

	'Client implementation code.
	Friend Class Client
		Shared Sub Main()
			' Create a wcfClient with the given client endpoint configuration.
			Dim wcfClient As New CalculatorClient()
			Try
				' Call the Add service operation.
				Dim value1 As Double = 100.00R
				Dim value2 As Double = 15.99R
				Dim result As Double = wcfClient.Add(value1, value2)
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
