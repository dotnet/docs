' <Snippet1>

Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.AddIn.Pipeline
Imports Calc2HVA.CalcHVAs
Imports Calc2Contract.CalculatorContracts

Namespace CalculatorContractsHostAdapers
    <HostAdapter()> _
    Public Class CalculatorContractToViewHostAdapter
        Inherits Calculator

'<Snippet2>
    Private _contract As ICalc2Contract
    Private _handle As ContractHandle

    Public Sub New(ByVal contract As ICalc2Contract)
        _contract = contract
        _handle = New ContractHandle(contract)
    End Sub
'</Snippet2>

    Public Overrides ReadOnly Property Operations() As String
        Get
            Return _contract.GetAvailableOperations()
        End Get
    End Property

    Public Overrides Function Operate(ByVal operation As String, ByVal a As Double, ByVal b As Double) As Double
        Return _contract.Operate(operation, a, b)
    End Function
End Class
End Namespace
' </Snippet1>

