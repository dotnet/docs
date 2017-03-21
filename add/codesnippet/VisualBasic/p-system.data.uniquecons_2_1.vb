Private Sub GetTableFromConstraint()
    Dim dataTable As DataTable
    Dim uniqueConstraint As UniqueConstraint

    ' Get a UniqueConstraint.
    uniqueConstraint = _
        CType(DataSet1.Tables("Suppliers").Constraints(0), _
        UniqueConstraint)

    ' Get the DataTable.
    dataTable = uniqueConstraint.Table
End Sub