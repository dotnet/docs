        Dim employee01 = New With {Key .Name = "Bob", Key .Category = 3, .InOffice = False}

        ' employee02 has no InOffice property.
        Dim employee02 = New With {Key .Name = "Bob", Key .Category = 3}

        ' The first property has a different name.
        Dim employee03 = New With {Key .FirstName = "Bob", Key .Category = 3, .InOffice = False}

        ' Property Category has a different value.
        Dim employee04 = New With {Key .Name = "Bob", Key .Category = 2, .InOffice = False}

        ' Property Category has a different type.
        Dim employee05 = New With {Key .Name = "Bob", Key .Category = 3.2, .InOffice = False}

        ' The properties are declared in a different order.
        Dim employee06 = New With {Key .Category = 3, Key .Name = "Bob", .InOffice = False}

        ' Property Category is not a key property.
        Dim employee07 = New With {Key .Name = "Bob", .Category = 3, .InOffice = False}

        ' employee01 and employee 08 meet all conditions for equality. Note 
        ' that the values of the non-key field need not be the same.
        Dim employee08 = New With {Key .Name = "Bob", Key .Category = 2 + 1, .InOffice = True}

        ' Equals returns True only for employee01 and employee08.
        Console.WriteLine(employee01.Equals(employee08))