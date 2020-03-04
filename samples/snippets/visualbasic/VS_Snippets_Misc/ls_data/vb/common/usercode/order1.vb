
Namespace LightSwitchApplication

    Public Class Order1

        '<Snippet17>
        Private Sub OrderDate_Validate(results As EntityValidationResultsBuilder)
            If Me.RequiredDate <= Me.OrderDate Then
                results.AddEntityError("Due date must be later than the order date")
            End If
        End Sub
        '</Snippet17>
    End Class

End Namespace
