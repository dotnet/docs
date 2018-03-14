
'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples

    ' <snippet1>
    <ServiceContract(Namespace:="http://Microsoft.ServiceModel.Samples", SessionMode:=SessionMode.Required)> _
    Public Interface ICalculatorSession

        <OperationContract(IsOneWay:=True)> _
        Sub Clear()
        <OperationContract(IsOneWay:=True)> _
        Sub AddTo(ByVal n As Double)
        <OperationContract(IsOneWay:=True)> _
        Sub SubtractFrom(ByVal n As Double)
        <OperationContract(IsOneWay:=True)> _
        Sub MultiplyBy(ByVal n As Double)
        <OperationContract(IsOneWay:=True)> _
        Sub DivideBy(ByVal n As Double)
        <OperationContract()> _
        Function Equal() As Double
    End Interface
    ' </snippet1>

        ' Service class which implements the service contract.
        ' Use an InstanceContextMode of PrivateSession to store the result
        ' An instance of the service will be bound to each session
    <ServiceBehavior(InstanceContextMode:=InstanceContextMode.PerSession)> _
    Public Class CalculatorService
        Implements ICalculatorSession

        Dim result As Double = 0D

        Public Sub Clear() _
 Implements ICalculatorSession.Clear
            result = 0D
        End Sub

        Public Sub AddTo(ByVal n As Double) _
Implements ICalculatorSession.AddTo
            result += n
        End Sub

        Public Sub SubtractFrom(ByVal n As Double) _
Implements ICalculatorSession.SubtractFrom

            result -= n
        End Sub

        Public Sub MultiplyBy(ByVal n As Double) _
Implements ICalculatorSession.MultiplyBy

            result *= n
        End Sub

        Public Sub DivideBy(ByVal n As Double) _
Implements ICalculatorSession.DivideBy

            result /= n
        End Sub

        Public Function Equal() As Double _
Implements ICalculatorSession.Equal

            Return result
        End Function
    End Class

End Namespace
