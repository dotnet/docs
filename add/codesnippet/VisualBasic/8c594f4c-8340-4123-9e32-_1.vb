    Private Sub SizeThirdRow(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button7.Click

        Dim thirdRow As Integer = 2
        DataGridView1.AutoResizeRow( _
            2, DataGridViewAutoSizeRowMode.AllCellsExceptHeader)

    End Sub