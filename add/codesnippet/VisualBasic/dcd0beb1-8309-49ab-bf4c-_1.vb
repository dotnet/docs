        Structure Pet
            Public Name As String
            Public Age As Integer
        End Structure

        Sub OrderByEx1()
            ' Create an array of Pet objects.
            Dim pets() As Pet = {New Pet With {.Name = "Barley", .Age = 8},
                             New Pet With {.Name = "Boots", .Age = 4},
                             New Pet With {.Name = "Whiskers", .Age = 1}}

            ' Order the Pet objects by their Age property.
            Dim query As IEnumerable(Of Pet) =
            pets.OrderBy(Function(pet) pet.Age)

            Dim output As New System.Text.StringBuilder
            For Each pt As Pet In query
                output.AppendLine(pt.Name & " - " & pt.Age)
            Next

            ' Display the output.
            MsgBox(output.ToString())
        End Sub

        ' This code produces the following output:
        '
        ' Whiskers - 1
        ' Boots - 4
        ' Barley - 8
