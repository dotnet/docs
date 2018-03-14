' <Snippet8>
' This is the service code.
'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel.Channels
Imports System.Configuration
Imports System.Messaging
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples
	' <Snippet1>
	' Define a service contract. 
	<ServiceContract(Namespace:="http://Microsoft.ServiceModel.Samples")> _
	Public Interface IQueueCalculator
		<OperationContract(IsOneWay:=True)> _
		Sub Add(ByVal n1 As Double, ByVal n2 As Double)
		<OperationContract(IsOneWay := True)> _
		Sub Subtract(ByVal n1 As Double, ByVal n2 As Double)
		<OperationContract(IsOneWay := True)> _
		Sub Multiply(ByVal n1 As Double, ByVal n2 As Double)
		<OperationContract(IsOneWay := True)> _
		Sub Divide(ByVal n1 As Double, ByVal n2 As Double)
	End Interface
	' </Snippet1>

	' <Snippet2>
	' Service class that implements the service contract.
	' Added code to write output to the console window
	Public Class CalculatorService
		Implements IQueueCalculator
		<OperationBehavior> _
		Public Sub Add(ByVal n1 As Double, ByVal n2 As Double) Implements IQueueCalculator.Add
			Dim result As Double = n1 + n2
			Console.WriteLine("Received Add({0},{1}) - result: {2}", n1, n2, result)
		End Sub

		<OperationBehavior> _
		Public Sub Subtract(ByVal n1 As Double, ByVal n2 As Double) Implements IQueueCalculator.Subtract
			Dim result As Double = n1 - n2
			Console.WriteLine("Received Subtract({0},{1}) - result: {2}", n1, n2, result)
		End Sub

		<OperationBehavior> _
		Public Sub Multiply(ByVal n1 As Double, ByVal n2 As Double) Implements IQueueCalculator.Multiply
			Dim result As Double = n1 * n2
			Console.WriteLine("Received Multiply({0},{1}) - result: {2}", n1, n2, result)
		End Sub

		<OperationBehavior> _
		Public Sub Divide(ByVal n1 As Double, ByVal n2 As Double) Implements IQueueCalculator.Divide
			Dim result As Double = n1 / n2
			Console.WriteLine("Received Divide({0},{1}) - result: {2}", n1, n2, result)
		End Sub
	End Class
	' </Snippet2>
End Namespace
' </Snippet8>