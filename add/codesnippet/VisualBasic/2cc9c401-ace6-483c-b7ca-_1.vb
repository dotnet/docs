    Structure Pet
        Public Name As String
        Public Age As Double
    End Structure

    Shared Sub GroupByEx4()
        ' Create a list of pets.
        Dim petsList As New List(Of Pet)(New Pet() { _
                           New Pet With {.Name = "Barley", .Age = 8.3}, _
                           New Pet With {.Name = "Boots", .Age = 4.9}, _
                           New Pet With {.Name = "Whiskers", .Age = 1.5}, _
                           New Pet With {.Name = "Daisy", .Age = 4.3}})

        ' Group Pet.Age valuesby the Math.Floor of the age.
        ' Then project an anonymous type from each group
        ' that consists of the key, the count of the group's
        ' elements, and the minimum and maximum age in the group.
        Dim query = petsList.AsQueryable().GroupBy( _
            Function(pet) Math.Floor(pet.Age), _
            Function(pet) pet.Age, _
            Function(baseAge, ages) New With { _
                .Key = baseAge, _
                .Count = ages.Count(), _
                .Min = ages.Min(), _
                .Max = ages.Max() _
            })

        Dim output As New System.Text.StringBuilder
        ' Iterate over each anonymous type.
        For Each result In query
            output.AppendLine(vbCrLf & "Age group: " & result.Key)
            output.AppendLine("Number of pets with this age: " & result.Count)
            output.AppendLine("Minimum age: " & result.Min)
            output.AppendLine("Maximum age: " & result.Max)
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:

        '  Age group: 8
        '  Number of pets with this age: 1
        '  Minimum age: 8.3
        '  Maximum age: 8.3

        '  Age group: 4
        '  Number of pets with this age: 2
        '  Minimum age: 4.3
        '  Maximum age: 4.9

        '  Age group: 1
        '  Number of pets with this age: 1
        '  Minimum age: 1.5
        '  Maximum age: 1.5
    End Sub