
Namespace LightSwitchApplication

    Public Class Order


        Private Sub OrderDate_Validate _
            (results As EntityValidationResultsBuilder)
            If Me.RequiredDate <= DateTime.Today Then
                results.AddPropertyError _
                    ("Due date must be later than the order date")
            End If
        End Sub

        '<Snippet2>
        Private Sub ShippedDate_Validate(results As EntityValidationResultsBuilder)
            If Me.ShippedDate > DateTime.Today Then
                results.AddPropertyError _
                    ("Shipped date cannot be later than today")
            End If

        End Sub
        '</Snippet2>
        '<Snippet19>
        Private Sub RequiredDate_Validate(results As EntityValidationResultsBuilder)
            If Me.RequiredDate < Me.OrderDate Then
                results.AddEntityError _
                    ("Required data cannot be earlier than the order date")
            End If

        End Sub
        '</Snippet19>
    End Class


End Namespace
