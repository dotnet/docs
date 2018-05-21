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