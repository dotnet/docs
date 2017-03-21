Private Sub GetParentKeyConstraint()
    ' Get a DataRelation from a DataSet.
    Dim relation As DataRelation = _
        DataSet1.Relations("CustomerOrders")

    ' Get the relations parent key constraint.
    Dim constraint As UniqueConstraint = _
        relation.ParentKeyConstraint

    ' Get the constraint's DataColumns
    Dim constraintColumns() As DataColumn
    constraintColumns = constraint.Columns

    ' Print the column names.
    Dim i As Integer
    For i = 0 to constraintColumns.GetUpperBound(0)
       Console.WriteLine(constraintColumns(i).ColumnName.ToString())
    Next i
End Sub