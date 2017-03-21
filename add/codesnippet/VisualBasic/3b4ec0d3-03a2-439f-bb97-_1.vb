            Structure Pet
                Public Name As String
                Public Age As Integer
            End Structure

            Sub MinEx4()
                ' Create an array of Pet objects.
                Dim pets() As Pet = {New Pet With {.Name = "Barley", .Age = 8},
                                 New Pet With {.Name = "Boots", .Age = 4},
                                 New Pet With {.Name = "Whiskers", .Age = 1}}

                ' Find the youngest pet by passing a 
                ' lambda expression to the Min() method.
                Dim min As Integer = pets.Min(Function(pet) pet.Age)

                ' Display the result.
                MsgBox("The youngest pet is age " & min)
            End Sub

            ' This code produces the following output:
            '
            ' The youngest pet is age 1
