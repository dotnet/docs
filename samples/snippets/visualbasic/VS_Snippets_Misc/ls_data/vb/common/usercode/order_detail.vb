
Namespace LightSwitchApplication

    Public Class Order_Detail

        '<Snippet1>
        Private Sub Subtotal_Compute(ByRef result As Decimal)
            result = Me.Quantity * Me.UnitPrice
            '</Snippet1>
        End Sub
    End Class

End Namespace
