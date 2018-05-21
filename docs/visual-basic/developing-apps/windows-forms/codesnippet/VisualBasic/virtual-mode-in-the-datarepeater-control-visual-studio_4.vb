    Private Sub DataRepeater1_NewItemNeeded(
      ) Handles DataRepeater1.NewItemNeeded

        Dim newEmployee As New Employee
        Employees.Add(newEmployee)
        blnNewItemNeedEventFired = True
    End Sub