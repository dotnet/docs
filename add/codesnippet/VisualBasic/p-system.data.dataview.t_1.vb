    Private Sub DemonstrateDataViewTable()
        Dim table As DataTable = New DataTable()

        ' add columns
        Dim column As DataColumn = table.Columns.Add("ProductID", GetType(Integer))
        column.AutoIncrement = True
        column = table.Columns.Add("ProductName", GetType(String))

        ' populate DataTable.
        Dim id As Integer
        For id = 1 To 5
            table.Rows.Add(New Object() {id, String.Format("product{0}", id)})
        Next id

        Dim view As DataView = New DataView(table)

        PrintTable(view.Table, "DataTable")
    End Sub

    Private Sub PrintTable(ByVal table As DataTable, ByVal label As String)
        ' This function prints values in the table or DataView.
        Console.WriteLine("\n" + label)
        Dim row As DataRow
        Dim column As DataColumn
        For Each row In table.Rows
            For Each column In table.Columns
                Console.Write("\table{0}", row(column))
            Next column
        Next row
        Console.WriteLine()
    End Sub