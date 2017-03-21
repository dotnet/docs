Private Sub GetRelDataSet(relation As DataRelation)
    ' Get the DataSet of the passed in DataRelation.
    Dim dataSet As DataSet = relation.DataSet

    ' Print the table names of each table in the DataSet.
    Dim table As DataTable
    For Each table In dataSet.Tables
        Console.WriteLine(table.TableName.ToString())
    Next
End Sub