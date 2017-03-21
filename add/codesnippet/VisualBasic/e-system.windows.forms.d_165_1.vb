    Private Sub dataGridView1_CancelRowEdit(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.QuestionEventArgs) _
        Handles dataGridView1.CancelRowEdit

        If Me.rowInEdit = Me.dataGridView1.Rows.Count - 2 AndAlso _
            Me.rowInEdit = Me.customers.Count Then

            ' If the user has canceled the edit of a newly created row, 
            ' replace the corresponding Customer object with a new, empty one.
            Me.customerInEdit = New Customer()

        Else

            ' If the user has canceled the edit of an existing row, 
            ' release the corresponding Customer object.
            Me.customerInEdit = Nothing
            Me.rowInEdit = -1

        End If

    End Sub