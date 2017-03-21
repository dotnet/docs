Private Sub AddRow(ByVal table As DataTable)
    ' Create an array with three elements.
    Dim rowVals(2) As Object
    Dim rowCollection As DataRowCollection = table.Rows
    rowVals(0) = "hello"
    rowVals(1) = "world"
    rowVals(2) = "two"

    ' Add and return the new row.
    Dim row As DataRow = rowCollection.Add(rowVals) 
End Sub