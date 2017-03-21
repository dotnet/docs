            Structure Pet
                Public Name As String
                Public Age As Integer
            End Structure

            Sub GroupByEx1()
                'Create a list of Pet objects.
                Dim pets As New List(Of Pet)(New Pet() _
                                     {New Pet With {.Name = "Barley", .Age = 8},
                                      New Pet With {.Name = "Boots", .Age = 4},
                                      New Pet With {.Name = "Whiskers", .Age = 1},
                                      New Pet With {.Name = "Daisy", .Age = 4}})

                ' Group the pets using Age as the key 
                ' and selecting only the pet's Name for each value.
                Dim query As IEnumerable(Of IGrouping(Of Integer, String)) =
            pets.GroupBy(Function(pet) pet.Age,
                         Function(pet) pet.Name)

                Dim output As New System.Text.StringBuilder
                ' Iterate over each IGrouping in the collection.
                For Each petGroup As IGrouping(Of Integer, String) In query
                    ' Print the key value of the IGrouping.
                    output.AppendLine(petGroup.Key)
                    ' Iterate over each value in the IGrouping and print the value.
                    For Each name As String In petGroup
                        output.AppendLine("  " & name)
                    Next
                Next

                ' Display the output.
                MsgBox(output.ToString)
            End Sub

            ' This code produces the following output:
            '
            ' 8
            '   Barley
            ' 4
            '   Boots
            '   Daisy
            ' 1
            '   Whiskers
