Private Sub GetConstraint(table As DataTable)
    If table.Constraints.Contains("CustomersOrdersConstraint") Then
        Dim constraint As Constraint = _
            table.Constraints("CustomersOrdersConstraint")
    End If
End Sub