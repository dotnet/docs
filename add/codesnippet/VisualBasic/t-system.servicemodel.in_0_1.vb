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
