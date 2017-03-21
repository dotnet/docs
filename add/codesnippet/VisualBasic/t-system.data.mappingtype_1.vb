    Private Sub GetColumnMapping(ByVal dataTable As DataTable)
        Dim dataColumn As DataColumn
        For Each dataColumn In dataTable.Columns
            Console.WriteLine(dataColumn.ColumnMapping.ToString())
        Next dataColumn
    End Sub