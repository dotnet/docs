Private Sub RemoveConstraint _
    (constraints As ConstraintCollection, constraint As Constraint)

    If constraints.Contains(constraint.ConstraintName) Then
        If constraints.CanRemove(constraint) Then
            constraints.Remove(constraint.ConstraintName)
        End If
    End If
End Sub