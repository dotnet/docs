Module Module1

    '<Snippet6>
    Sub Main()
        InnerJoinExample()
        LeftOuterJoinExample()
        CompositeKeyJoinExample()

        Console.ReadLine()
    End Sub
    '</Snippet6>

    '<Snippet1>
    Private _people As List(Of Person)
    Private _pets As List(Of Pet)

    Function GetPeople() As List(Of Person)
        If _people Is Nothing Then CreateLists()
        Return _people
    End Function

    Function GetPets(ByVal people As List(Of Person)) As List(Of Pet)
        If _pets Is Nothing Then CreateLists()
        Return _pets
    End Function

    Private Sub CreateLists()
        Dim pers As Person

        _people = New List(Of Person)
        _pets = New List(Of Pet)

        pers = New Person With {.FirstName = "Magnus", .LastName = "Hedlund"}
        _people.Add(pers)
        _pets.Add(New Pet With {.Name = "Daisy", .Owner = pers})

        pers = New Person With {.FirstName = "Terry", .LastName = "Adams"}
        _people.Add(pers)
        _pets.Add(New Pet With {.Name = "Barley", .Owner = pers})
        _pets.Add(New Pet With {.Name = "Boots", .Owner = pers})
        _pets.Add(New Pet With {.Name = "Blue Moon", .Owner = pers})

        pers = New Person With {.FirstName = "Charlotte", .LastName = "Weiss"}
        _people.Add(pers)
        _pets.Add(New Pet With {.Name = "Whiskers", .Owner = pers})

        ' Add a person with no pets for the sake of Join examples.
        _people.Add(New Person With {.FirstName = "Arlene", .LastName = "Huff"})

        pers = New Person With {.FirstName = "Don", .LastName = "Hall"}
        ' Do not add person to people list for the sake of Join examples.
        _pets.Add(New Pet With {.Name = "Spot", .Owner = pers})

        ' Add a pet with no owner for the sake of Join examples.
        _pets.Add(New Pet With {.Name = "Unknown", 
                                .Owner = New Person With {.FirstName = String.Empty, 
                                                          .LastName = String.Empty}})
    End Sub
    '</Snippet1>

    Sub FullOuterJoinExample()
        ' Create two lists.
        Dim people = GetPeople()
        Dim pets = GetPets(people)

        ' Left Outer Join
        Dim petOwners = From pers In people 
                        Group Join pet In pets On pers Equals pet.Owner
                        Into PetList = Group
                        From pet In PetList.DefaultIfEmpty()
                        Select pers.FirstName, pers.LastName, 
                               PetName = If(pet Is Nothing, String.Empty, pet.Name)

        ' The remaining list of the full outer join is made up of the pets that are not
        ' included in an inner join with the list of people.
        Dim outerPetList = (From pet In pets).Except(
                              From owner In people
                              Join pet In pets On owner Equals pet.Owner
                              Select pet)

        ' Combine the results of the Left Outer Join with the results of the excluded pets
        ' for a full outer join.
        Dim fullOuterJoin = (From owner In petOwners Select owner.PetName, owner.LastName, owner.FirstName).Union(
                             From pet In outerPetList
                             Select PetName = pet.Name,
                                    LastName = If(pet.Owner Is Nothing, String.Empty, pet.Owner.LastName),
                                    FirstName = If(pet.Owner Is Nothing, String.Empty, pet.Owner.FirstName))

        ' Display results.
        Dim output As New System.Text.StringBuilder
        For Each pers In fullOuterJoin
            output.AppendFormat("{0}:{1}{2}{3}",
                pers.FirstName, vbTab, pers.PetName, vbCrLf)
        Next

        Console.WriteLine(output.ToString())
    End Sub

    ' This code produces the following output:
    '
    '  Magnus:    Daisy
    '  Terry:     Barley
    '  Terry:     Boots
    '  Terry:     Blue Moon
    '  Charlotte: Whiskers
    '  Arlene:
    '  Don:       Spot
    '   :       Unknown

    '<Snippet3>
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
    '</Snippet3>

    '<Snippet4>
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
    '</Snippet4>

    '<Snippet5>
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
    '</Snippet5>


    '<Snippet2>
    Class Person
        Public Property FirstName As String
        Public Property LastName As String
    End Class

    Class Pet
        Public Property Name As String
        Public Property Owner As Person
    End Class
    '</Snippet2>
End Module
