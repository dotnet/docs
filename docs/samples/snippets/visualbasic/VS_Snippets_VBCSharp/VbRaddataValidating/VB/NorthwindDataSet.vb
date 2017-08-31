Partial Class NorthwindDataSet
    Partial Class Order_DetailsDataTable

        '<Snippet2>
        Private Sub Order_DetailsDataTable_ColumnChanging(
            ByVal sender As System.Object, 
            ByVal e As System.Data.DataColumnChangeEventArgs
          ) Handles Me.ColumnChanging

            If (e.Column.ColumnName = Me.QuantityColumn.ColumnName) Then

                '<Snippet1>
                If CType(e.ProposedValue, Short) <= 0 Then
                        e.Row.SetColumnError(e.Column, "Quantity must be greater than 0")
                    Else
                        e.Row.SetColumnError(e.Column, "")
                End If
                '</Snippet1>
            End If
        End Sub
        '</Snippet2>


        '<Snippet3>
        Private Sub Order_DetailsDataTable_Order_DetailsRowChanging(
            ByVal sender As System.Object, 
            ByVal e As Order_DetailsRowChangeEvent
          ) Handles Me.Order_DetailsRowChanging

            If CType(e.Row.Quantity, Short) <= 0 Then
                e.Row.SetColumnError("Quantity", "Quantity must be greater than 0")
            Else
                e.Row.SetColumnError("Quantity", "")
            End If
        End Sub
        '</Snippet3>

    End Class
End Class
