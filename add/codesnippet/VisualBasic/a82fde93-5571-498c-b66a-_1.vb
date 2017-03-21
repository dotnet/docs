            Structure Pet
                Public Name As String
                Public Age As Integer
            End Structure

            Sub AllEx()
                ' Create an array of Pets.
                Dim pets() As Pet =
            {New Pet With {.Name = "Barley", .Age = 2},
             New Pet With {.Name = "Boots", .Age = 4},
             New Pet With {.Name = "Whiskers", .Age = 7}}

                ' Determine whether all pet names in the array start with "B".
                Dim allNames As Boolean =
            pets.All(Function(ByVal pet) pet.Name.StartsWith("B"))

                ' Display the output.
                Dim text As String = IIf(allNames, "All", "Not all")
                MsgBox(text & " pet names start with 'B'.")
            End Sub

            ' This code produces the following output:
            '
            ' Not all pet names start with 'B'.
