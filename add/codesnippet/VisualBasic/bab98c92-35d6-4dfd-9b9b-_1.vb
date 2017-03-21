            Structure Pet
                Public Name As String
                Public Age As Integer
            End Structure

            Sub DefaultIfEmptyEx2()
                ' Create a Pet object to use as the default value.
                Dim defaultPet As New Pet With {.Name = "Default Pet", .Age = 0}

                ' Create a List of Pet objects.
                Dim pets1 As New List(Of Pet)(New Pet() _
                                      {New Pet With {.Name = "Barley", .Age = 8},
                                       New Pet With {.Name = "Boots", .Age = 4},
                                       New Pet With {.Name = "Whiskers", .Age = 1}})

                Dim output1 As New System.Text.StringBuilder
                ' Enumerate the items in the list, calling DefaultIfEmpty() 
                ' with a default value.
                For Each pet As Pet In pets1.DefaultIfEmpty(defaultPet)
                    output1.AppendLine("Name: " & pet.Name)
                Next

                ' Display the output.
                MsgBox(output1.ToString())

                ' Create an empty List.
                Dim pets2 As New List(Of Pet)

                Dim output2 As New System.Text.StringBuilder
                ' Enumerate the items in the list, calling DefaultIfEmpty() 
                ' with a default value.
                For Each pet As Pet In pets2.DefaultIfEmpty(defaultPet)
                    output2.AppendLine("Name: " & pet.Name)
                Next

                ' Display the output.
                MsgBox(output2.ToString())
            End Sub

            ' This code produces the following output:
            '
            ' Name: Barley
            ' Name: Boots
            ' Name: Whiskers
            '
            ' Name: Default Pet
