            Structure Pet
                Public Name As String
                Public Vaccinated As Boolean
            End Structure

            Public Shared Sub CountEx2()
                ' Create an array of Pet objects.
                Dim pets() As Pet = {New Pet With {.Name = "Barley", .Vaccinated = True},
                             New Pet With {.Name = "Boots", .Vaccinated = False},
                             New Pet With {.Name = "Whiskers", .Vaccinated = False}}

                Try
                    ' Count the number of Pets in the array where the Vaccinated property is False.
                    Dim numberUnvaccinated As Integer =
                pets.Count(Function(p) p.Vaccinated = False)
                    ' Display the output.
                    MsgBox("There are " & numberUnvaccinated & " unvaccinated animals.")
                Catch e As OverflowException
                    MsgBox("The count is too large to store as an Int32. Try using LongCount() instead.")
                End Try

            End Sub

            ' This code produces the following output:
            '
            ' There are 2 unvaccinated animals.
