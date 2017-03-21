    Structure PetOwner
        Public Name As String
        Public Pets() As String
    End Structure

    Shared Sub SelectManyEx2()
        Dim petOwners() As PetOwner = _
            {New PetOwner With _
             {.Name = "Higa, Sidney", .Pets = New String() {"Scruffy", "Sam"}}, _
             New PetOwner With _
             {.Name = "Ashkenazi, Ronen", .Pets = New String() {"Walker", "Sugar"}}, _
             New PetOwner With _
             {.Name = "Price, Vernette", .Pets = New String() {"Scratches", "Diesel"}}, _
             New PetOwner With _
             {.Name = "Hines, Patrick", .Pets = New String() {"Dusty"}}}

        ' For each PetOwner element in the source array,
        ' project a sequence of strings where each string
        ' consists of the index of the PetOwner element in the
        ' source array and the name of each pet in PetOwner.Pets.
        Dim query As IEnumerable(Of String) = _
            petOwners.AsQueryable() _
            .SelectMany(Function(petOwner, index) petOwner.Pets.Select(Function(pet) index.ToString() + pet))

        Dim output As New System.Text.StringBuilder
        For Each pet As String In query
            output.AppendLine(pet)
        Next

        ' Display the output.
        MsgBox(output.ToString())
    End Sub

    ' This code produces the following output:
    '
    ' 0Scruffy
    ' 0Sam
    ' 1Walker
    ' 1Sugar
    ' 2Scratches
    ' 2Diesel
    ' 3Dusty
