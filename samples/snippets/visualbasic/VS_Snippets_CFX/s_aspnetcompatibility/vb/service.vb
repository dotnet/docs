
'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel.Activation
Imports System.ServiceModel
Imports System.Web

Namespace Microsoft.ServiceModel.Samples

    ' Define a service contract which requires a session.
    ' ICalculatorSession allows you to perform multiple operations on a running result.
    ' You can retrieve the current result by calling Equals().
    ' You can begin calculating a new result by calling Clear().
    '<Snippet1>
    <ServiceContract(Namespace:="http://Microsoft.ServiceModel.Samples")> _
    Public Interface ICalculatorSession

        <OperationContract()> _
        Sub Clear()
        <OperationContract()> _
        Sub AddTo(ByVal n As Double)
        <OperationContract()> _
        Sub SubtractFrom(ByVal n As Double)
        <OperationContract()> _
        Sub MultiplyBy(ByVal n As Double)
        <OperationContract()> _
        Sub DivideBy(ByVal n As Double)
        <OperationContract()> _
        Function Equal() As Double
    End Interface
    '</Snippet1>

    ' Service class that implements the service contract.
    ' Utilize AspSessionState to manage each calculator session.
    ' Requiring AspNetCompatibilityMode allows one access to the HttpContext and Session.
    '<Snippet2>
    <AspNetCompatibilityRequirements(RequirementsMode:=AspNetCompatibilityRequirementsMode.Required)> _
    Public Class CalculatorService
        Implements ICalculatorSession

        Property Result() As Double
            ' Store result in AspNet Session.
            Get
                If (HttpContext.Current.Session("Result") Is Nothing) Then
                    Return 0D
                End If
                Return HttpContext.Current.Session("Result")
            End Get
            Set(ByVal value As Double)
                HttpContext.Current.Session("Result") = value
            End Set
        End Property

        Public Sub Clear() _
 Implements ICalculatorSession.Clear
            Result = 0D
        End Sub

        Public Sub AddTo(ByVal n As Double) _
Implements ICalculatorSession.AddTo
            Result += n
        End Sub

        Public Sub SubtractFrom(ByVal n As Double) _
Implements ICalculatorSession.SubtractFrom

            Result -= n
        End Sub

        Public Sub MultiplyBy(ByVal n As Double) _
Implements ICalculatorSession.MultiplyBy

            Result *= n
        End Sub

        Public Sub DivideBy(ByVal n As Double) _
Implements ICalculatorSession.DivideBy

            Result /= n
        End Sub

        Public Function Equal() As Double _
Implements ICalculatorSession.Equal

            Return Result
        End Function
    End Class
    ' </Snippet2>
End Namespace
