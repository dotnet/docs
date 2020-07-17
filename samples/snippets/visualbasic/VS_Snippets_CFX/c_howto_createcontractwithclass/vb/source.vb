Imports System.ServiceModel

Namespace Samples

    '<snippet1>
    <ServiceContract()> _
    Public Class CalculatorService
        <OperationContract()> _
        Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
            Return n1 + n2
        End Function

        <OperationContract()> _
        Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double
            Return n1 - n2
        End Function

        <OperationContract()> _
        Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double
            Return n1 * n2
        End Function

        <OperationContract()> _
        Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double
            Return n1 / n2
        End Function
    End Class

    '</snippet1>

    Public Class Test
        Public Shared Sub Main()
        End Sub

    End Class
End Namespace
