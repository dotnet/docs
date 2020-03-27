Imports System.Globalization
Imports System.Windows.Controls

    '<Snippet3>
    Public Class AgeRangeRule
        Inherits ValidationRule

        ' Properties
        Public Property Max As Integer
        Public Property Min As Integer
            
        ' Methods
        Public Overrides Function Validate(value As Object, cultureInfo As CultureInfo) As ValidationResult
            Dim num1 As Integer = 0
            Try 
                If (CStr(value).Length > 0) Then
                    num1 = Integer.Parse(CStr(value))
                End If
            Catch exception1 As Exception
                Return New ValidationResult(False, $"Illegal characters or {exception1.Message}")
            End Try
            If ((num1 < Min) OrElse (num1 > Max)) Then
                Return New ValidationResult(False, $"Please enter an age in the range: {Min}-{Max}.")
            End If
            Return ValidationResult.ValidResult
        End Function

    End Class
	'</Snippet3>


