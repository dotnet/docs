    Sub LeftOuterJoinExample()
        ' Create two lists.
        Dim people = GetPeople()
        Dim pets = GetPets(people)

        ' Grouped results.
        Dim petOwnersGrouped = From pers In people
                               Group Join pet In pets
                                 On pers Equals pet.Owner
                               Into PetList = Group
                               Select pers.FirstName, pers.LastName,
                                      PetList

        ' Display grouped results.
        Dim output As New System.Text.StringBuilder
        For Each pers In petOwnersGrouped
            output.AppendFormat(pers.FirstName & ":" & vbCrLf)
            For Each pt In pers.PetList
                output.AppendFormat(vbTab & pt.Name & vbCrLf)
            Next
        Next

        Console.WriteLine(output)
        ' This code produces the following output:
        '
        ' Magnus:
        '     Daisy
        ' Terry:
        '     Barley
        '     Boots
        '     Blue Moon
        ' Charlotte:
        '     Whiskers
        ' Arlene:

        ' "Flat" results.
        Dim petOwners = From pers In people
                        Group Join pet In pets On pers Equals pet.Owner
                        Into PetList = Group
                        From pet In PetList.DefaultIfEmpty()
                        Select pers.FirstName, pers.LastName,
                               PetName =
                                 If(pet Is Nothing, String.Empty, pet.Name)


        ' Display "flat" results.
        output = New System.Text.StringBuilder()
        For Each pers In petOwners
            output.AppendFormat( 
              pers.FirstName & ":" & vbTab & pers.PetName & vbCrLf)
        Next

        Console.WriteLine(output.ToString())
        ' This code produces the following output:
        '
        ' Magnus:	    Daisy
        ' Terry:	    Barley
        ' Terry:	    Boots
        ' Terry:	    Blue Moon
        ' Charlotte:	Whiskers
        ' Arlene:	  
    End Sub