' <Snippet1>
Imports System.AddIn.Pipeline
Imports Calc1Contract.CalculatorContracts
Imports Calc1HVA.CalcHVAs

Namespace CalcHostSideAdapters

    ' <Snippet2>
    ' The HostAdapterAttribute identifes this class as the host-side adapter
    ' pipeline segment.
    <HostAdapterAttribute()> _
    Public Class CalculatorContractToViewHostSideAdapter
        Implements ICalculator
        ' </Snippet2>

        Private _contract As ICalc1Contract
        Private _handle As System.AddIn.Pipeline.ContractHandle

        Public Sub New(ByVal contract As ICalc1Contract)
                MyBase.New()
            _contract = contract
            _handle = New ContractHandle(contract)
        End Sub

        Public Function Add(ByVal a As Double, ByVal b As Double) As Double _
                Implements ICalculator.Add
            Return _contract.Add(a, b)
        End Function

        Public Function Subtract(ByVal a As Double, ByVal b As Double) As Double _
                Implements ICalculator.Subtract
            Return _contract.Subtract(a, b)
        End Function

        Public Function Multiply(ByVal a As Double, ByVal b As Double) As Double _
                Implements ICalculator.Multiply
            Return _contract.Multiply(a, b)
        End Function

        Public Function Divide(ByVal a As Double, ByVal b As Double) As Double _
                Implements ICalculator.Divide
            Return _contract.Divide(a, b)
        End Function

    End Class

End Namespace
' </Snippet1>