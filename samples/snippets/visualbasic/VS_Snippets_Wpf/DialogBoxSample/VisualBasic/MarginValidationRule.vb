'<SnippetMarginValidationRuleCODE>
Imports System.Globalization
Imports System.Windows.Controls

Namespace SDKSample

Public Class MarginValidationRule
    Inherits ValidationRule

    Private _maxMargin As Double
    Private _minMargin As Double

    Public Property MaxMargin() As Double
        Get
            Return Me._maxMargin
        End Get
        Set(ByVal value As Double)
            Me._maxMargin = value
        End Set
    End Property

    Public Property MinMargin() As Double
        Get
            Return Me._minMargin
        End Get
        Set(ByVal value As Double)
            Me._minMargin = value
        End Set
    End Property

    Public Overrides Function Validate(ByVal value As Object, ByVal cultureInfo As CultureInfo) As ValidationResult

        Dim margin As Double

        ' Is a number?
        If Not Double.TryParse(CStr(value), margin) Then
            Return New ValidationResult(False, "Not a number.")
        End If

        ' Is in range?
        If ((margin < Me.MinMargin) OrElse (margin > Me.MaxMargin)) Then
            Dim msg As String = String.Format("Margin must be between {0} and {1}.", Me.MinMargin, Me.MaxMargin)
            Return New ValidationResult(False, msg)
        End If

        ' Number is valid
        Return New ValidationResult(True, Nothing)

    End Function

End Class

End Namespace
'</SnippetMarginValidationRuleCODE>