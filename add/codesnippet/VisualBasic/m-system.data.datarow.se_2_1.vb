Private Sub SetParent()
    ' Get a ParentRow and a ChildRow from a DataSet.
    Dim childRow As DataRow = _
        DataSet1.Tables("Orders").Rows(1)
    Dim parentRow As DataRow = _
        DataSet1.Tables("Customers").Rows(20)

    ' Set the parent row of a DataRelation.
    childRow.SetParentRow(parentRow, _
        DataSet1.Relations("CustomerOrders"))
End Sub