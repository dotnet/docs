    Structure Pet
        Public Name As String
        Public Age As Integer
    End Structure

    Shared Sub GroupByEx1()
        ' Create a list of Pet objects.
        Dim pets As New List(Of Pet)(New Pet() { _
                        New Pet With {.Name = "Barley", .Age = 8}, _
                        New Pet With {.Name = "Boots", .Age = 4}, _
                        New Pet With {.Name = "Whiskers", .Age = 1}, _
                        New Pet With {.Name = "Daisy", .Age = 4}})

        ' Group the pets using Pet.Age as the key.
        ' Use Pet.Name as the value for each entry.
        Dim query = pets.AsQueryable().GroupBy(Function(pet) pet.Age)

        Dim output As New System.Text.StringBuilder
        ' Iterate over each IGrouping in the collection.
        For Each ageGroup In query
            output.AppendFormat("Age group: {0}   Number of pets: {1}{2}", ageGroup.Key, ageGroup.Count(), vbCrLf)
        Next

        ' Display the output.
        MsgBox(output.ToString())
    End Sub

    ' This code produces the following output:
    '
    ' Age group: 8   Number of pets: 1
    ' Age group: 4   Number of pets: 2
    ' Age group: 1   Number of pets: 1
