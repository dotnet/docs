        ' Create a list of Pet objects.
        Dim pets As New List(Of Pet)(New Pet() { _
                           New Pet With {.Name = "Barley", .Age = 8}, _
                           New Pet With {.Name = "Boots", .Age = 4}, _
                           New Pet With {.Name = "Whiskers", .Age = 1}})

        ' This query returns pets that are 10 or older. In case there are no pets 
        ' that meet that criteria, call DefaultIfEmpty(). This code passes an (optional) 
        ' default value to DefaultIfEmpty().
        Dim oldPets() As String = pets.AsQueryable() _
            .Where(Function(Pet) Pet.Age >= 10) _
            .Select(Function(Pet) Pet.Name) _
            .DefaultIfEmpty("[EMPTY]") _
            .ToArray()
        Try
            MsgBox("First query: " + oldPets(0))
        Catch ex As Exception
            Console.WriteLine("First query: An exception was thrown: " + ex.Message)
        End Try

        ' This query selects only those pets that are 10 or older.
        ' This code does not call DefaultIfEmpty().
        Dim oldPets2() As String = _
            pets.AsQueryable() _
            .Where(Function(Pet) Pet.Age >= 10) _
            .Select(Function(Pet) Pet.Name) _
            .ToArray()

        ' There may be no elements in the array, so directly
        ' accessing element 0 may throw an exception.
        Try
            MsgBox("Second query: " + oldPets2(0))
        Catch ex As Exception
            MsgBox("Second query: An exception was thrown: " + ex.Message)
        End Try

        ' This code produces the following output:
        '
        ' First(query) : [EMPTY]
        ' Second query: An exception was thrown: Index was outside the bounds of the array.
