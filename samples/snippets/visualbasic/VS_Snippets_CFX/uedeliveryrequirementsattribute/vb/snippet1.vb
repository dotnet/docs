' <Snippet1>
Imports System
Imports System.ServiceModel

<ServiceContract()> _
Public Interface ICalculatorService

    <OperationBehavior()> _
    Function Add(ByVal a As Integer, ByVal b As Integer) As Integer

    <OperationContract()> _
    Function Subtract(ByVal a As Integer, ByVal b As Integer) As Integer
End Interface

<DeliveryRequirements( _
    QueuedDeliveryRequirements:=QueuedDeliveryRequirementsMode.NotAllowed, _
    RequireOrderedDelivery:=True _
)> _
Class CalculatorService
    Public Function add(ByVal a As Integer, ByVal b As Integer) As Integer
        Console.WriteLine("Add called")
        Return a + b
    End Function

    Public Function Subtract(ByVal a As Integer, ByVal b As Integer) As Integer
        Console.WriteLine("Subtract called.")
        Return a - b
    End Function

    Public Function Multiply(ByVal a As Integer, ByVal b As Integer) As Integer
        Return a * b
    End Function
End Class
' </Snippet1>