    Private Sub SetReadOnly()
        Dim myColumn As DataGridColumnStyle
        Dim myDataColumns As DataColumnCollection
        ' Get the columns for a table bound to a DataGrid.
        myDataColumns = dataSet1.Tables("Suppliers").Columns
        Dim dataColumn As DataColumn
        For Each dataColumn In myDataColumns
            dataGrid1.TableStyles(0).GridColumnStyles(dataColumn.ColumnName).ReadOnly = dataColumn.ReadOnly
        Next dataColumn
    End Sub 'SetReadOnly