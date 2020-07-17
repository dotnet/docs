Imports System.Globalization

' <FutureDateRule>
Public Class FutureDateRule
    Inherits ValidationRule

    Public Overrides Function Validate(value As Object, cultureInfo As CultureInfo) As ValidationResult

        Dim inputDate As Date

        ' Test if date is valid
        If Date.TryParse(value.ToString, inputDate) Then

            ' Date is not in the future, fail
            If Date.Now > inputDate Then
                Return New ValidationResult(False, "Please enter a date in the future.")
            End If

        Else
            ' // Date Is Not a valid date, fail
            Return New ValidationResult(False, "Value is not a valid date.")
        End If

        ' Date is valid and in the future, pass
        Return ValidationResult.ValidResult

    End Function

End Class
' </FutureDateRule>
