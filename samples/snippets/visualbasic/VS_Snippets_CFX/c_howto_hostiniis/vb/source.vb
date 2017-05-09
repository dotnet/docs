'Code for con topic: HowTo: Host a WCF Service in IIS

'<snippet1>

Imports System
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples

    '<snippet11>
    <ServiceContract()> _
    Public Interface ICalculator

        <OperationContract()> _
          Function Add(ByVal n1 As Double, _
                       ByVal n2 As Double) As Double

        <OperationContract()> _
        Function Subtract(ByVal n1 As Double, _
                          ByVal n2 As Double) As Double

        <OperationContract()> _
        Function Multiply(ByVal n1 As Double, _
                          ByVal n2 As Double) As Double

        <OperationContract()> _
        Function Divide(ByVal n1 As Double, _
                        ByVal n2 As Double) As Double
    End Interface

    '</snippet11>

    '<snippet12>
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

    '</snippet12>
    '</snippet1>

    Public Class Test
        Public Shared Sub Main()
        End Sub

    End Class
End Namespace
