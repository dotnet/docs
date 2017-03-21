            Structure Pet
                Public Name As String
                Public Age As Integer
            End Structure

            Sub MaxEx4()
                ' Create an array of Pet objects.
                Dim pets() As Pet = {New Pet With {.Name = "Barley", .Age = 8},
                                 New Pet With {.Name = "Boots", .Age = 4},
                                 New Pet With {.Name = "Whiskers", .Age = 1}}

                ' Determine the "maximum" pet by passing a
                ' lambda expression to Max() that sums the pet's age
                ' and name length.
                Dim max As Integer = pets.Max(Function(pet) _
                                              pet.Age + pet.Name.Length)

                ' Display the result.
                MsgBox("The maximum pet age plus name length is " & max)
            End Sub

            ' This code produces the following output:
            '
            ' The maximum pet age plus name length is 14
