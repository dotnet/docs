'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples
	'<snippet0>
	<ServiceContract(Namespace := "http://Microsoft.ServiceModel.Samples", SessionMode:=SessionMode.Required, CallbackContract:=GetType(ICalculatorDuplexCallback))> _
	Public Interface ICalculatorDuplex
		<OperationContract(IsOneWay := True)> _
		Sub Clear()
		<OperationContract(IsOneWay := True)> _
		Sub AddTo(ByVal n As Double)
		<OperationContract(IsOneWay := True)> _
		Sub SubtractFrom(ByVal n As Double)
		<OperationContract(IsOneWay := True)> _
		Sub MultiplyBy(ByVal n As Double)
		<OperationContract(IsOneWay := True)> _
		Sub DivideBy(ByVal n As Double)
	End Interface


	Public Interface ICalculatorDuplexCallback
		<OperationContract(IsOneWay := True)> _
		Sub Equals(ByVal result As Double)
		<OperationContract(IsOneWay := True)> _
		Sub Equation(ByVal eqn As String)
	End Interface
	'</snippet0>
	'<snippet1>

	<ServiceBehavior(InstanceContextMode := InstanceContextMode.PerSession)> _
	Public Class CalculatorService
		Implements ICalculatorDuplex
        Private result As Double = 0.0R
		Private equation As String

		Public Sub New()
			equation = result.ToString()
		End Sub

		Public Sub Clear() Implements ICalculatorDuplex.Clear
			Callback.Equation(equation & " = " & result.ToString())
			equation = result.ToString()
		End Sub

		Public Sub AddTo(ByVal n As Double) Implements ICalculatorDuplex.AddTo
			result += n
			equation &= " + " & n.ToString()
			CType(Callback, Object).Equals(result)
		End Sub

		Public Sub SubtractFrom(ByVal n As Double) Implements ICalculatorDuplex.SubtractFrom
			result -= n
			equation &= " - " & n.ToString()
			CType(Callback, Object).Equals(result)
		End Sub

		Public Sub MultiplyBy(ByVal n As Double) Implements ICalculatorDuplex.MultiplyBy
			result *= n
			equation &= " * " & n.ToString()
			CType(Callback, Object).Equals(result)
		End Sub

		Public Sub DivideBy(ByVal n As Double) Implements ICalculatorDuplex.DivideBy
			result /= n
			equation &= " / " & n.ToString()
			CType(Callback, Object).Equals(result)
		End Sub

		Private ReadOnly Property Callback() As ICalculatorDuplexCallback
			Get
				Return OperationContext.Current.GetCallbackChannel(Of ICalculatorDuplexCallback)()
			End Get
		End Property
	End Class
	'</snippet1>
End Namespace
