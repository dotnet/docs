'  Copyright (c) Microsoft Corporation.  All Rights Reserved.
' <Snippet3>

Imports System
Imports System.ServiceModel.Description
Imports System.Configuration
Imports System.Messaging
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Transactions

Namespace Microsoft.ServiceModel.Samples
	' Define a service contract. 
	<ServiceContract(Namespace := "http://Microsoft.ServiceModel.Samples")> _
	Public Interface IOrderProcessor
		<OperationContract(IsOneWay := True)> _
		Sub SubmitPurchaseOrder(ByVal po As PurchaseOrder)
	End Interface

	' Service class that implements the service contract.
	' Added code to write output to the console window
	<ServiceBehavior(InstanceContextMode := InstanceContextMode.Single, ConcurrencyMode := ConcurrencyMode.Single, AddressFilterMode := AddressFilterMode.Any)> _
	Public Class PurchaseOrderDLQService
		Implements IOrderProcessor
		Private orderProcessorService As OrderProcessorClient
		Public Sub New()
			orderProcessorService = New OrderProcessorClient("OrderProcessorEndpoint")
		End Sub

		' <Snippet0>
		<OperationBehavior(TransactionScopeRequired := True, TransactionAutoComplete := True)> _
		Public Sub SimpleSubmitPurchaseOrder(ByVal po As PurchaseOrder)
			Console.WriteLine("Submitting purchase order did not succeed ", po)
			Dim mqProp As MsmqMessageProperty = TryCast(OperationContext.Current.IncomingMessageProperties(MsmqMessageProperty.Name), MsmqMessageProperty)

			Console.WriteLine("Message Delivery Status: {0} ", mqProp.DeliveryStatus)
			Console.WriteLine("Message Delivery Failure: {0}", mqProp.DeliveryFailure)
			Console.WriteLine()
		End Sub
		' </Snippet0>

		<OperationBehavior(TransactionScopeRequired := True, TransactionAutoComplete := True)> _
		Public Sub SubmitPurchaseOrder(ByVal po As PurchaseOrder) Implements IOrderProcessor.SubmitPurchaseOrder
			Console.WriteLine("Submitting purchase order did not succeed ", po)
			Dim mqProp As MsmqMessageProperty = TryCast(OperationContext.Current.IncomingMessageProperties(MsmqMessageProperty.Name), MsmqMessageProperty)

			Console.WriteLine("Message Delivery Status: {0} ", mqProp.DeliveryStatus)
			Console.WriteLine("Message Delivery Failure: {0}", mqProp.DeliveryFailure)
			Console.WriteLine()

			' Resend the message if timed out.
			If mqProp.DeliveryFailure = DeliveryFailure.ReachQueueTimeout OrElse mqProp.DeliveryFailure = DeliveryFailure.ReceiveTimeout Then
				' Re-send.
				Console.WriteLine("Purchase order Time To Live expired")
				Console.WriteLine("Trying to resend the message")

				' Reuse the same transaction used to read the message from dlq to enqueue the message to the application queue.
				orderProcessorService.SubmitPurchaseOrder(po)
				Console.WriteLine("Purchase order resent")
			End If
		End Sub

		' Host the service within this EXE console application.
		Public Shared Sub Main()
			' Create a ServiceHost for the PurchaseOrderDLQService type.
			Using serviceHost As New ServiceHost(GetType(PurchaseOrderDLQService))
				' Open the ServiceHostBase to create listeners and start listening for messages.
				serviceHost.Open()

				' The service can now be accessed.
				Console.WriteLine("The dead letter service is ready.")
				Console.WriteLine("Press <ENTER> to terminate service.")
				Console.WriteLine()
				Console.ReadLine()

				' Close the ServiceHostBase to shutdown the service.
				serviceHost.Close()
			End Using
		End Sub
	End Class
End Namespace
' </Snippet3>
