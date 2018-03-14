'<Snippet1>
Imports System.AddIn.Contract
Imports System.AddIn.Pipeline

Namespace CalculatorContracts

    ' <Snippet2>
    ' The AddInContractAttribute identifes this pipeline segment as a
    ' contract.
    <AddInContract()> _
    Public Interface ICalc1Contract
        Inherits IContract
    ' </Snippet2>

        Function Add(ByVal a As Double, ByVal b As Double) As Double
        Function Subtract(ByVal a As Double, ByVal b As Double) As Double
        Function Multiply(ByVal a As Double, ByVal b As Double) As Double
        Function Divide(ByVal a As Double, ByVal b As Double) As Double
    End Interface

End Namespace
'</Snippet1>

