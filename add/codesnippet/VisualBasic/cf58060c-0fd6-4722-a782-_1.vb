    Structure Pet
        Public Name As String
        Public Age As Integer
    End Structure

    Shared Sub OrderByEx1()
        Dim pets() As Pet = {New Pet With {.Name = "Barley", .Age = 8}, _
                             New Pet With {.Name = "Boots", .Age = 4}, _
                             New Pet With {.Name = "Whiskers", .Age = 1}}

        ' Sort the Pet objects in the array by Pet.Age.
        Dim query As IEnumerable(Of Pet) = _
                    pets.AsQueryable().OrderBy(Function(pet) pet.Age)

        Dim output As New System.Text.StringBuilder
        For Each pet As Pet In query
            output.AppendLine(String.Format("{0} - {1}", pet.Name, pet.Age))
        Next

        ' Display the output.
        MsgBox(output.ToString())
    End Sub

    ' This code produces the following output:

    ' Whiskers - 1
    ' Boots - 4
    ' Barley - 8
