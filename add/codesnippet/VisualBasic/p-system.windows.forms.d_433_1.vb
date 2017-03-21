        ' Get the width of row header.
        Private Sub button9_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button9.Click
            Dim myRowHeaderWidth As Int32 = myDataGrid.RowHeaderWidth
            MessageBox.Show("Width of row headers is: " + myRowHeaderWidth.ToString(), "Message", MessageBoxButtons.OK, 	    MessageBoxIcon.Exclamation)
        End Sub 'button9_Click