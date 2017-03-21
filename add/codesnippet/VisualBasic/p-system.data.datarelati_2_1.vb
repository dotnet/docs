 Private Sub SetChildKeyConstraint(dataSet As DataSet)
    ' Set child and parent columns.
    Dim parentColumn As DataColumn = dataSet.Tables( _
        "Suppliers").Columns("SupplierID")
    Dim childColumn As DataColumn = dataSet.Tables( _
        "Products").Columns("SupplierID")
    Dim relation As DataRelation = New DataRelation( _
        "SuppliersConstraint", parentColumn, childColumn)
    dataSet.Relations.Add(relation)

    Dim foreignKey As ForeignKeyConstraint = _
        relation.ChildKeyConstraint
    foreignKey.DeleteRule = Rule.SetNull
    foreignKey.UpdateRule = Rule.Cascade
    foreignKey.AcceptRejectRule = AcceptRejectRule.Cascade
 End Sub