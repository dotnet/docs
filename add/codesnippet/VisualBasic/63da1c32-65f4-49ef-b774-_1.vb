    Sub AllEx()
        ' Create an array of Pets.
        Dim pets() As Pet = _
            {New Pet With {.Name = "Barley", .Age = 10}, _
             New Pet With {.Name = "Boots", .Age = 4}, _
             New Pet With {.Name = "Whiskers", .Age = 6}}

        ' Determine whether all pet names in the array start with 'B'.
        Dim allStartWithB As Boolean = _
            pets.AsQueryable().All(Function(ByVal pet) pet.Name.StartsWith("B"))

        MsgBox(String.Format( _
            "{0} pet names start with 'B'.", _
            IIf(allStartWithB, "All", "Not all")))
    End Sub

    Public Structure Pet
        Dim Name As String
        Dim Age As Integer
    End Structure

    ' This code produces the following output:
    '
    '  Not all pet names start with 'B'. 
