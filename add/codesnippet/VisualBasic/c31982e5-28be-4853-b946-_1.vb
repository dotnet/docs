            Structure Pet
                Public Name As String
                Public Age As Integer
            End Structure

            Sub DefaultIfEmptyEx1()
                ' Create a List of Pet objects.
                Dim pets As New List(Of Pet)(New Pet() _
                                     {New Pet With {.Name = "Barley", .Age = 8},
                                      New Pet With {.Name = "Boots", .Age = 4},
                                      New Pet With {.Name = "Whiskers", .Age = 1}})

                Dim output As New System.Text.StringBuilder
                ' Iterate through the items in the List, calling DefaultIfEmpty().
                For Each pet As Pet In pets.DefaultIfEmpty()
                    output.AppendLine(pet.Name)
                Next

                ' Display the output.
                MsgBox(output.ToString())
            End Sub

            ' This code produces the following output:
            '
            ' Barley
            ' Boots
            ' Whiskers
