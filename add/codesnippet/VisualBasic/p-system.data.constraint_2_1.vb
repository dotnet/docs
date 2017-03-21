Private Sub GetConstraint(table As DataTable)
    Dim i As Integer
    For i = 0 To table.Constraints.Count - 1
        Console.WriteLine(table.Constraints(i).ConstraintName)
        Console.WriteLine(table.Constraints(i).GetType())
    Next i
 End Sub