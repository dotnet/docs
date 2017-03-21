Private Sub PrintToString(dataSet As DataSet)
    Dim table As DataTable
    For Each table In dataSet.Tables
       Console.WriteLine(table.ToString())
    Next
End Sub