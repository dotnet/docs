    Private Sub dataGridView1_DataError(ByVal sender As Object, _
        ByVal e As DataGridViewDataErrorEventArgs) _
        Handles dataGridView1.DataError

        ' If the data source raises an exception when a cell value is 
        ' commited, display an error message.
        If e.Exception IsNot Nothing AndAlso _
            e.Context = DataGridViewDataErrorContexts.Commit Then

            MessageBox.Show("CustomerID value must be unique.")

        End If

    End Sub