        Dim employee As Object = New ExpandoObject()
        employee.Name = "John Smith"
        CType(employee, IDictionary(Of String, Object)).Remove("Name")