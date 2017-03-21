    Private Sub GetDataGridTextBox()
        ' Gets the DataGridTextBoxColumn from the DataGrid control.
        Dim myTextBoxColumn As DataGridTextBoxColumn
        ' Assumes the CompanyName column is a DataGridTextBoxColumn.
        myTextBoxColumn = CType(dataGrid1.TableStyles(0). _
            GridColumnStyles("CompanyName"), DataGridTextBoxColumn)
        ' Gets the DataGridTextBox for the column.
        Dim myGridTextBox As DataGridTextBox
        myGridTextBox = CType(myTextBoxColumn.TextBox, DataGridTextBox)
    End Sub