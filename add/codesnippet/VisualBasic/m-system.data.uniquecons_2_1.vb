    Private Sub CreateUniqueConstraint(ByVal dataSetSuppliers As DataSet)
        Dim uniqueConstraint As UniqueConstraint

        ' Get the DataColumn of a table in a DataSet.
        Dim dataColumn As DataColumn
        dataColumn = dataSetSuppliers.Tables("Suppliers").Columns("SupplierID")

        ' Create the constraint.
        uniqueConstraint = New UniqueConstraint("supplierIdConstraint", dataColumn)

        ' Add the constraint to the ConstraintCollection of the DataTable.
        dataSetSuppliers.Tables("Suppliers").Constraints.Add(uniqueConstraint)
    End Sub