Private Sub GetChildColumns()
    ' Get the DataRelation of a DataSet.
    Dim relation As DataRelation = _
        DataSet1.Relations("CustomerOrders")

    ' Get the child columns.
    Dim childArray() As DataColumn = relation.ChildColumns

    ' Print the ColumnName of each column.
    Dim i As Integer
    For i = 0 to childArray.GetUpperBound(0)
       Debug.Write(childArray(i).ColumnName)
    Next i
End Sub