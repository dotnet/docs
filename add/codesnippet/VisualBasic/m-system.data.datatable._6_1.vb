Private Sub GetRows()
    ' Get the DataTable of a DataSet.
    Dim table As DataTable = DataSet1.Tables("Suppliers")
    Dim rows() As DataRow = table.Select()

    Dim i As Integer
    ' Print the value one column of each DataRow.
    For i = 0 to rows.GetUpperBound(0)
       Console.WriteLine(rows(i)("CompanyName"))
    Next i
End Sub