    Structure Pet
        Public Name As String
        Public Vaccinated As Boolean
    End Structure

    Shared Sub CountEx2()
        ' Create an array of Pet objects.
        Dim pets() As Pet = {New Pet With {.Name = "Barley", .Vaccinated = True}, _
                       New Pet With {.Name = "Boots", .Vaccinated = False}, _
                       New Pet With {.Name = "Whiskers", .Vaccinated = False}}

        ' Count the number of unvaccinated pets in the array.
        Dim numberUnvaccinated As Integer = pets.AsQueryable().Count(Function(p) p.Vaccinated = False)

        MsgBox(String.Format("There are {0} unvaccinated animals.", numberUnvaccinated))
    End Sub

    ' This code produces the following output:
    '
    ' There are 2 unvaccinated animals.
