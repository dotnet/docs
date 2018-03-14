
'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples

    ' Define a service contract.
    <ServiceContract(Namespace:="http://Microsoft.ServiceModel.Samples")> _ 
    Public Interface ICalculator
        <OperationContract> _ 
        Function Add(n1 As Double, n2 As Double) As Double
        <OperationContract> _ 
        Function Subtract(n1 As Double, n2 As Double) As Double
        <OperationContract> _ 
        Function Multiply(n1 As Double, n2 As Double) As Double
        <OperationContract> _ 
        Function Divide(n1 As Double, n2 As Double) As Double
    End Interface

    ' <Snippet1>
    ' Service class which implements the service contract.
    Public Class CalculatorService
    Implements ICalculator

        Public Function Add(n1 As Double, n2 As Double) As Double Implements ICalculator.Add
            Return n1 + n2
        End Function

        Public Function Subtract(n1 As Double, n2 As Double) As Double Implements ICalculator.Subtract
            Return n1 - n2
        End Function

        Public Function Multiply(n1 As Double, n2 As Double) As Double Implements ICalculator.Multiply
            Return n1 * n2
        End Function

        Public Function Divide(n1 As Double, n2 As Double) As Double Implements ICalculator.Divide
            Return n1 / n2
        End Function

    End Class

    '</Snippet1>
End Namespace
