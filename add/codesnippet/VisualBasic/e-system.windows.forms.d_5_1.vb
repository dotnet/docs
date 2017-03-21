    Private Sub dataGridView1_DefaultValuesNeeded(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) _
        Handles dataGridView1.DefaultValuesNeeded

        With e.Row
            .Cells("Region").Value = "WA"
            .Cells("City").Value = "Redmond"
            .Cells("PostalCode").Value = "98052-6399"
            .Cells("Country").Value = "USA"
            .Cells("CustomerID").Value = NewCustomerId()
        End With

    End Sub