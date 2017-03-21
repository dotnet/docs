        Dim employee As Object = New ExpandoObject()
        employee.Name = "John Smith"
        employee.Age = 33
        For Each member In CType(employee, IDictionary(Of String, Object))
            Console.WriteLine(member.Key & ": " & member.Value)
        Next
        ' This code example produces the following output:
        ' Name: John Smith
        ' Age: 33