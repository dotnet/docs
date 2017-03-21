    Structure PetOwner
        Public Name As String
        Public Pets As List(Of Pet)
    End Structure

    Structure Pet
        Public Name As String
        Public Breed As String
    End Structure

    Shared Sub SelectManyEx3()
        Dim petOwners() As PetOwner = _
                    {New PetOwner With {.Name = "Higa", _
                          .Pets = New List(Of Pet)(New Pet() { _
                              New Pet With {.Name = "Scruffy", .Breed = "Poodle"}, _
                              New Pet With {.Name = "Sam", .Breed = "Hound"}})}, _
                      New PetOwner With {.Name = "Ashkenazi", _
                          .Pets = New List(Of Pet)(New Pet() { _
                              New Pet With {.Name = "Walker", .Breed = "Collie"}, _
                              New Pet With {.Name = "Sugar", .Breed = "Poodle"}})}, _
                      New PetOwner With {.Name = "Price", _
                          .Pets = New List(Of Pet)(New Pet() { _
                              New Pet With {.Name = "Scratches", .Breed = "Dachshund"}, _
                              New Pet With {.Name = "Diesel", .Breed = "Collie"}})}, _
                      New PetOwner With {.Name = "Hines", _
                          .Pets = New List(Of Pet)(New Pet() { _
                              New Pet With {.Name = "Dusty", .Breed = "Collie"}})} _
                    }

        ' This query demonstrates how to obtain a sequence of
        ' the names of all the pets whose breed is "Collie", while
        ' keeping an association with the owner that owns the pet.
        Dim query = petOwners.AsQueryable() _
            .SelectMany(Function(owner) owner.Pets, _
                   Function(owner, pet) New With {owner, pet}) _
            .Where(Function(ownerAndPet) ownerAndPet.pet.Breed = "Collie") _
            .Select(Function(ownerAndPet) New With { _
                .Owner = ownerAndPet.owner.Name, _
                .Pet = ownerAndPet.pet.Name})

        Dim output As New System.Text.StringBuilder
        For Each obj In query
            output.AppendLine(String.Format("Owner={0}, Pet={1}", obj.Owner, obj.Pet))
        Next

        ' Display the output.
        MsgBox(output.ToString())
    End Sub

    ' This code produces the following output:

    ' Owner=Ashkenazi, Pet=Walker
    ' Owner=Price, Pet=Diesel
    ' Owner=Hines, Pet=Dusty
