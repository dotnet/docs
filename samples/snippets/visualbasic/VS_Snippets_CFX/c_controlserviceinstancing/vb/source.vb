Imports System.ServiceModel
Imports System.Security.Permissions



'<snippet2>
' Define a service contract.
<ServiceContract([Namespace]:="http://Microsoft.ServiceModel.Samples")> _
Public Interface ICalculator
    <OperationContract()> _
    Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
    <OperationContract()> _
    Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double
    <OperationContract()> _
    Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double
    <OperationContract()> _
    Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double
End Interface

' Service class which implements the service contract.
'<snippet1>
<ServiceBehaviorAttribute(InstanceContextMode:=InstanceContextMode.PerCall)> _
Public Class CalculatorService
    '</snippet1>
    Implements ICalculator

    Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double _
    Implements ICalculator.Add
        Return n1 + n2

    End Function


    Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double _
    Implements ICalculator.Subtract
        Return n1 - n2
    End Function

    Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double _
    Implements ICalculator.Multiply
        Return n1 * n2
    End Function

    Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double _
    Implements ICalculator.Divide
        Return n1 / n2
    End Function
End Class
'</snippet2>

Public Class Class3
End Class
' for FXCOp.

Public Class Class4
End Class

Public Class Class5
End Class
