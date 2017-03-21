Private Sub GetColsFromConstraint()
    Dim dataColumns() As DataColumn

    ' Get a named relation from a DataSet.
    Dim dataRelation As DataRelation
    dataRelation = DataSet1.Relations("CustomerOrders")

    ' Get the ParentKeyConstraint
    Dim uniqueConstraint As UniqueConstraint
    uniqueConstraint= dataRelation.ParentKeyConstraint

    ' Get the DataColumn objects being constrained.
    dataColumns = uniqueConstraint.Columns

    ' Print the column name of each column.
    Dim i As Integer
    For i = 0 to dataColumns.GetUpperBound(0)
       Console.Write(dataColumns(i).ColumnName)
    Next i
 End Sub