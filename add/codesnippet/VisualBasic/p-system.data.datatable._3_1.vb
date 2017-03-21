Private Sub CreateConstraint(dataSet As DataSet, _
    table1 As String, table2 As String, _
    column1 As String, column2 As String)

    Dim idKeyRestraint As ForeignKeyConstraint = _
        New ForeignKeyConstraint _
        (dataSet.Tables(table1).Columns(column1), _
        dataSet.Tables(table2).Columns(column2))

    ' Set null values when a value is deleted.
    idKeyRestraint.DeleteRule = Rule.SetNull
    idKeyRestraint.UpdateRule = Rule.Cascade

    ' Set AcceptRejectRule to cascade changes.
    idKeyRestraint.AcceptRejectRule = AcceptRejectRule.Cascade
    
    dataSet.Tables(table1).Constraints.Add(idKeyRestraint)
    dataSet.EnforceConstraints = True
End Sub