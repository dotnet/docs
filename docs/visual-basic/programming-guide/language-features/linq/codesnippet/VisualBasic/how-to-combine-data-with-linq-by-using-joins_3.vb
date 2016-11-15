    Sub InnerJoinExample()
        ' Create two lists.
        Dim people = GetPeople()
        Dim pets = GetPets(people)

        ' Implicit Join.
        Dim petOwners = From pers In people, pet In pets
                        Where pet.Owner Is pers
                        Select pers.FirstName, PetName = pet.Name

        ' Display grouped results.
        Dim output As New System.Text.StringBuilder
        For Each pers In petOwners
            output.AppendFormat(
              pers.FirstName & ":" & vbTab & pers.PetName & vbCrLf)
        Next

        Console.WriteLine(output)

        ' Explicit Join.
        Dim petOwnersJoin = From pers In people
                            Join pet In pets
                            On pet.Owner Equals pers
                            Select pers.FirstName, PetName = pet.Name

        ' Display grouped results.
        output = New System.Text.StringBuilder()
        For Each pers In petOwnersJoin
            output.AppendFormat(
              pers.FirstName & ":" & vbTab & pers.PetName & vbCrLf)
        Next

        Console.WriteLine(output)

        ' Both queries produce the following output:
        '
        ' Magnus:    Daisy
        ' Terry:     Barley
        ' Terry:     Boots
        ' Terry:     Blue Moon
        ' Charlotte: Whiskers
    End Sub