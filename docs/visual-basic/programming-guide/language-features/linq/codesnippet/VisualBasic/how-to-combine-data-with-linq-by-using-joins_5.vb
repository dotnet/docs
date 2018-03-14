    Sub CompositeKeyJoinExample()
        ' Create two lists.
        Dim people = GetPeople()
        Dim pets = GetPets(people)

        ' Implicit Join.
        Dim petOwners = From pers In people
                        Join pet In pets On
                          pet.Owner.FirstName Equals pers.FirstName And
                          pet.Owner.LastName Equals pers.LastName
                    Select pers.FirstName, PetName = pet.Name

        ' Display grouped results.
        Dim output As New System.Text.StringBuilder
        For Each pers In petOwners
            output.AppendFormat(
              pers.FirstName & ":" & vbTab & pers.PetName & vbCrLf)
        Next

        Console.WriteLine(output)
        ' This code produces the following output:
        '
        ' Magnus:    Daisy
        ' Terry:     Barley
        ' Terry:     Boots
        ' Terry:     Blue Moon
        ' Charlotte: Whiskers
    End Sub