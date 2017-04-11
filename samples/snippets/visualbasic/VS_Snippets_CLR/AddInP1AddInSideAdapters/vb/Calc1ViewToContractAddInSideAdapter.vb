' <Snippet1>
Imports System.AddIn.Pipeline
Imports Calc1AddInView.CalcAddInViews
Imports Calc1Contract.CalculatorContracts

Namespace CalcAddInSideAdapters

    ' <Snippet2>
    ' The AddInAdapterAttribute identifes this class as the add-in-side 
    ' adapter pipeline segment.
    <AddInAdapter()> _
    Public Class CalculatorViewToContractAddInSideAdapter
        Inherits ContractBase
        Implements ICalc1Contract
    ' </Snippet2>

        Private _view As ICalculator

        Public Sub New(ByVal view As ICalculator)
            MyBase.New()
            _view = view
        End Sub

        Public Function Add(ByVal a As Double, ByVal b As Double) As Double Implements ICalc1Contract.Add
            Return _view.Add(a, b)
        End Function

        Public Function Subtract(ByVal a As Double, ByVal b As Double) As Double Implements ICalc1Contract.Subtract
            Return _view.Subtract(a, b)
        End Function

        Public Function Multiply(ByVal a As Double, ByVal b As Double) As Double Implements ICalc1Contract.Multiply
            Return _view.Multiply(a, b)
        End Function

        Public Function Divide(ByVal a As Double, ByVal b As Double) As Double Implements ICalc1Contract.Divide
            Return _view.Divide(a, b)
        End Function

    End Class
End Namespace
' </Snippet1>

