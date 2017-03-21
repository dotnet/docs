            Structure Pet
                Public Name As String
                Public Age As Integer
            End Structure

            Sub LongCountEx2()
                ' Create a list of Pet objects.
                Dim pets As New List(Of Pet)(New Pet() _
                             {New Pet With {.Name = "Barley", .Age = 8},
                              New Pet With {.Name = "Boots", .Age = 4},
                              New Pet With {.Name = "Whiskers", .Age = 1}})

                ' Determine the number of elements in the list
                ' where the pet's age is greater than a constant value (3).
                Const Age As Integer = 3
                Dim count As Long =
            pets.LongCount(Function(pet) pet.Age > Age)

                ' Display the result.
                MsgBox("There are " & count & " animals over age " & Age)
            End Sub

            ' This code produces the following output:
            '
            ' There are 2 animals over age 3
