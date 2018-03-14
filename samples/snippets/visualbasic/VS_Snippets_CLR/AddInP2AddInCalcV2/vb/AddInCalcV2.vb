' <Snippet1>

Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.AddIn
Imports System.AddIn.Pipeline
Imports Calc2AddInView.CalcAddInViews

Namespace CalculatorAddIns
' <Snippet2>
' This pipeline segment has
' two attributes:
' 1 - An AddInAttribute to identify
'     this segment as an add-in.
'
' 2 - A QualificationDataAttribute to
'     indicate that the add-in should
'     be loaded into a new application domain.

<AddIn("Calculator Add-in", Version:="2.0.0.0")> _
<QualificationData("Isolation", "NewAppDomain")> _
    Public Class SampleV2AddIn
' </Snippet2>
    Inherits Calculator2
Public Overrides ReadOnly Property Operations() As String
    Get
        Return "+, -, *, /, **"
    End Get
End Property

Public Overrides Function Operate(ByVal operation As String, _
        ByVal a As Double, ByVal b As Double) As Double
    Select Case operation
        Case "+"
            Return a + b
        Case "-"
            Return a - b
        Case "*"
            Return a * b
        Case "/"
            Return a / b
        Case "**"
            Return Math.Pow(a, b)
        Case Else
            Throw New InvalidOperationException("This add-in does not support: " & operation)
    End Select
End Function

End Class
End Namespace
' </Snippet1>