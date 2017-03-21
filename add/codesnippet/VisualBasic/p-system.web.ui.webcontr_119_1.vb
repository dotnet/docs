    Private Sub Page_Init(sender As Object, e As EventArgs)
        
        ' Create dynamic column to add to Columns collection.
        Dim AddColumn As New ButtonColumn()
        AddColumn.HeaderText = "Add Item"
        AddColumn.Text = "Add"
        AddColumn.CommandName = "Add"
        AddColumn.ButtonType = ButtonColumnType.PushButton

        
        ' Add column to Columns collection.
        ItemsGrid.Columns.AddAt(2, AddColumn)
    End Sub 'Page_Init 