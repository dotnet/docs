    Private Sub InvoiceButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles InvoiceButton.Click

        For Each row As DataGridViewRow In Me.DataGridView1.SelectedRows

            Dim cust As Customer = TryCast(row.DataBoundItem, Customer)
            If cust IsNot Nothing Then
                cust.SendInvoice()
            End If

        Next

    End Sub