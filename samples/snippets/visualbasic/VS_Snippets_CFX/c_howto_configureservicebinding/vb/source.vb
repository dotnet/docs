Imports System.ServiceModel

Namespace Samples

    '<snippet1>
    <ServiceContract()> _
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

    '</snippet1>

    '<snippet2>
    Public Class CalculatorService
        Implements ICalculator
        Public Function Add(ByVal n1 As Double, _
                            ByVal n2 As Double) As Double Implements ICalculator.Add
            Return n1 + n2
        End Function
        Public Function Subtract(ByVal n1 As Double, _
                                 ByVal n2 As Double) As Double Implements ICalculator.Subtract
            Return n1 - n2
        End Function
        Public Function Multiply(ByVal n1 As Double, _
                                 ByVal n2 As Double) As Double Implements ICalculator.Multiply
            Return n1 * n2
        End Function
        Public Function Divide(ByVal n1 As Double, _
                               ByVal n2 As Double) As Double Implements ICalculator.Divide
            Return n1 / n2
        End Function
    End Class

    '</snippet2>

    Public Class Test
        Public Shared Sub Main()
        End Sub
    End Class
End Namespace
