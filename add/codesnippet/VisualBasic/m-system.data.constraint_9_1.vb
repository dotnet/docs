Private Sub RemoveConstraint(table As DataTable, _
    constraint As Constraint)

    If table.Constraints.Contains(constraint.ConstraintName) Then
        If table.Constraints.CanRemove(constraint) Then
            table.Constraints.Remove(constraint)
        End If
    End If
End Sub