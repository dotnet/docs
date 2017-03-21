 Private Sub PrintConstraintNames(myTable As DataTable)
     Dim cs As Constraint
     For Each cs In  myTable.Constraints
         Console.WriteLine(cs.ConstraintName)
     Next cs
 End Sub