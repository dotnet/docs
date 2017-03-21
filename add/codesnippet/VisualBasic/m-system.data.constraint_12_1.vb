Private Sub TryRemove(dataSet As DataSet)
    Try
        Dim customersTable As DataTable = dataSet.Tables("Customers")
        Dim constraint As Constraint = customersTable.Constraints(0)
        Console.WriteLine("Can remove? " & _
            customersTable.Constraints.CanRemove(constraint).ToString())

    Catch ex As Exception
        ' Process exception and return.
        Console.WriteLine("Exception of type {0} occurred.", _
            ex.GetType().ToString())
    End Try
End Sub