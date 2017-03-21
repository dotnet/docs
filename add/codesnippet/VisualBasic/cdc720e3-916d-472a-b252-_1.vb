            Structure Pet
                Public Name As String
                Public Age As Integer
                Public Vaccinated As Boolean
            End Structure

            Shared Sub AnyEx3()
                ' Create a list of Pets
                Dim pets As New List(Of Pet)(New Pet() _
                                     {New Pet With {.Name = "Barley", .Age = 8, .Vaccinated = True},
                                      New Pet With {.Name = "Boots", .Age = 4, .Vaccinated = False},
                                      New Pet With {.Name = "Whiskers", .Age = 1, .Vaccinated = False}})

                ' Determine whether any pets over age 1 are also unvaccinated.
                Dim unvaccinated As Boolean =
            pets.Any(Function(pet) pet.Age > 1 And pet.Vaccinated = False)

                ' Display the output.
                Dim text As String = IIf(unvaccinated, "are", "are not")
                MsgBox("There " & text & " unvaccinated animals over age 1.")
            End Sub

            ' This code produces the following output:
            '
            ' There are unvaccinated animals over age 1.
