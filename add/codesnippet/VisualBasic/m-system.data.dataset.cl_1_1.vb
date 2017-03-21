Private Sub ClearDataSet(ByVal dataSet As DataSet)
    ' To test, print the number rows in each table.
    Dim table As DataTable
    For Each table In dataSet.Tables
        Console.WriteLine(table.TableName & "Rows.Count = " _
            & table.Rows.Count.ToString())
    Next

    ' Clear all rows of each table.
    dataSet.Clear()

    ' Print the number of rows again.
    For Each table In dataSet.Tables
        Console.WriteLine(table.TableName & "Rows.Count = " _
            & table.Rows.Count.ToString())
    Next 
End Sub