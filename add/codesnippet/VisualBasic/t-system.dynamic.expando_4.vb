    Sub Main()
        Dim employee, manager As Object

        employee = New ExpandoObject()
        employee.Name = "John Smith"
        employee.Age = 33

        manager = New ExpandoObject()
        manager.Name = "Allison Brown"
        manager.Age = 42
        manager.TeamSize = 10

        WritePerson(manager)
        WritePerson(employee)
    End Sub

    Private Sub WritePerson(ByVal person As Object)

        Console.WriteLine("{0} is {1} years old.",
                          person.Name, person.Age)
        ' The following statement causes an exception
        ' if you pass the employee object.
        ' Console.WriteLine("Manages {0} people", person.TeamSize)

    End Sub