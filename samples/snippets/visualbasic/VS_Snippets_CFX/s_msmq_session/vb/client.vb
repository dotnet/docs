'  Copyright (c) Microsoft Corporation.  All Rights Reserved.
' <Snippet3>

Imports System
Imports System.Configuration
Imports System.Messaging
Imports System.ServiceModel
Imports System.Transactions

Namespace Microsoft.ServiceModel.Samples
	'The service contract is defined in generatedProxy.cs, generated from the service by the svcutil tool.

	'Client implementation code.
	Friend Class Client
		Shared Sub Main()
			'Create a transaction scope.
			Using scope As New TransactionScope(TransactionScopeOption.Required)
				' Create a proxy with given client endpoint configuration
				Dim client As New OrderTakerClient("OrderTakerEndpoint")
				Try
					' Open a purchase order
					client.OpenPurchaseOrder("somecustomer.com")
					Console.WriteLine("Purchase Order created")

					' Add product line items
					Console.WriteLine("Adding 10 quantities of blue widget")
					client.AddProductLineItem("Blue Widget", 10)

					Console.WriteLine("Adding 23 quantities of red widget")
					client.AddProductLineItem("Red Widget", 23)

					' Close the purchase order
					Console.WriteLine("Closing the purchase order")
					client.EndPurchaseOrder()
					client.Close()
				Catch ex As CommunicationException
					client.Abort()
				End Try
				' Complete the transaction.
				scope.Complete()
			End Using
			Console.WriteLine()
			Console.WriteLine("Press <ENTER> to terminate client.")
			Console.ReadLine()
		End Sub
	End Class
End Namespace
' </Snippet3>
