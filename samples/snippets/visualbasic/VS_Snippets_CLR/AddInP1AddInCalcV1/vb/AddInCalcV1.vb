' <Snippet1>
Imports System.AddIn
Imports Calc1AddInView.CalcAddInViews

Namespace CalcAddIns

    ' The AddInAttribute identifies this pipeline segment as an add-in.
    <AddIn("Calculator AddIn", Version:="1.0.0.0")> _
    Public Class AddInCalcV1
        Implements ICalculator

        Public Function Add(ByVal a As Double, ByVal b As Double) As Double _
                Implements ICalculator.Add
            Return (a + b)
        End Function

        Public Function Subtract(ByVal a As Double, ByVal b As Double) As Double _
                Implements ICalculator.Subtract
            Return (a - b)
        End Function

        Public Function Multiply(ByVal a As Double, ByVal b As Double) As Double _
                Implements ICalculator.Multiply
            Return (a * b)
        End Function

        Public Function Divide(ByVal a As Double, ByVal b As Double) As Double _
                Implements ICalculator.Divide
            Return (a / b)
        End Function
    End Class

End Namespace
' </Snippet1>
