    Structure Pet
        Dim Name As String
        Dim Age As Integer
        Dim Vaccinated As Boolean
    End Structure

    Shared Sub AnyEx3()
        ' Create an array of Pet objects.
        Dim pets() As Pet = _
            {New Pet With {.Name = "Barley", .Age = 8, .Vaccinated = True}, _
             New Pet With {.Name = "Boots", .Age = 4, .Vaccinated = False}, _
             New Pet With {.Name = "Whiskers", .Age = 1, .Vaccinated = False}}

        ' Determine whether any pets over age 1 are also unvaccinated.
        Dim unvaccinated As Boolean = _
        pets.AsQueryable().Any(Function(p) p.Age > 1 And p.Vaccinated = False)

        MsgBox(String.Format( _
            "There {0} unvaccinated animals over age one.", _
            IIf(unvaccinated, "are", "are not any") _
        ))
    End Sub

    ' This code produces the following output:
    '
    '  There are unvaccinated animals over age one. 
