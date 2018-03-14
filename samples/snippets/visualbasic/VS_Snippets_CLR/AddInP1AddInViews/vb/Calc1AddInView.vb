' <Snippet1>
Imports System.AddIn.Pipeline

Namespace CalcAddInViews

    ' <Snippet2>
    ' The AddInBaseAttribute identifes this interface as the basis for the
    ' add-in view pipeline segment.
    <AddInBaseAttribute()> _
    Public Interface ICalculator
    ' </Snippet2>

        Function Add(ByVal a As Double, ByVal b As Double) As Double
        Function Subtract(ByVal a As Double, ByVal b As Double) As Double
        Function Multiply(ByVal a As Double, ByVal b As Double) As Double
        Function Divide(ByVal a As Double, ByVal b As Double) As Double
    End Interface

End Namespace
' </Snippet1>