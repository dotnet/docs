Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples
    ' <Snippet5>
    ' Define a duplex service contract.
    ' A duplex contract consists of two interfaces.
    ' The primary interface is used to send messages from client to service.
    ' The callback interface is used to send messages from service back to client.
    ' ICalculatorDuplex allows one to perform multiple operations on a running result.
    ' The result is sent back after each operation on the ICalculatorCallback interface.
    ' <Snippet3>
    <ServiceContract(Namespace:="http://Microsoft.ServiceModel.Samples", SessionMode:=SessionMode.Required, _
                    CallbackContract:=GetType(ICalculatorDuplexCallback))> _
    Public Interface ICalculatorDuplex

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
    End Interface

    ' </Snippet3>
    ' The callback interface is used to send messages from service back to client.
    ' The Equals operation will return the current result after each operation.
    ' The Equation operation will return the complete equation after Clear() is called.
    ' <Snippet4>
    Public Interface ICalculatorDuplexCallback
        <OperationContract(IsOneWay:=True)> _
        Sub Equals(ByVal result As Double)
        <OperationContract(IsOneWay:=True)> _
        Sub Equation(ByVal eqn As String)
    end interface

    ' </Snippet4>
    ' Service class which implements a duplex service contract.
    ' Use an InstanceContextMode of PerSession to store the result
    ' An instance of the service will be bound to each duplex session
    <ServiceBehavior(InstanceContextMode:=InstanceContextMode.PerSession)> _
    Public Class CalculatorService
        Implements ICalculatorDuplex
        Dim result As Double
        Dim equation As String
        ' <Snippet1>
        Dim callback As ICalculatorDuplexCallback
        ' </Snippet1>

        Public Sub New()
            result = 0D
            equation = result.ToString()
            ' <Snippet2>
            callback = OperationContext.Current.GetCallbackChannel(Of ICalculatorDuplexCallback)()
            ' </Snippet2>

        End Sub
        Public Sub AddTo(ByVal n As Double) Implements ICalculatorDuplex.AddTo
            result += n
            equation += " + " + n.ToString()
            callback.Equals(result)
        End Sub

        Public Sub Clear() Implements ICalculatorDuplex.Clear
            callback.Equation(equation + " = " + result.ToString())
            result = 0D
            equation = result.ToString()
        End Sub

        Public Sub DivideBy(ByVal n As Double) Implements ICalculatorDuplex.DivideBy
            result /= n
            equation += " / " + n.ToString()
            callback.Equals(result)
        End Sub

        Public Sub MultiplyBy(ByVal n As Double) Implements ICalculatorDuplex.MultiplyBy
            result *= n
            equation += " * " + n.ToString()
            callback.Equals(result)
        End Sub

        Public Sub SubtractFrom(ByVal n As Double) Implements ICalculatorDuplex.SubtractFrom
            result -= n
            equation += " - " + n.ToString()
            callback.Equals(result)
        End Sub
    End Class
    ' </Snippet5>
End Namespace

