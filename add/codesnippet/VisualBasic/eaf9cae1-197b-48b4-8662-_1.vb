    Private Sub SizeFirstRowHeaderToAllHeaders(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button8.Click

        DataGridView1.AutoResizeRowHeadersWidth( _
            DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders)

    End Sub