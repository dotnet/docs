            Structure PetOwner
                Public Name As String
                Public Pets() As String
            End Structure

            Sub SelectManyEx3()
                ' Create an array of PetOwner objects.
                Dim petOwners() As PetOwner =
            {New PetOwner With
             {.Name = "Higa", .Pets = New String() {"Scruffy", "Sam"}},
             New PetOwner With
             {.Name = "Ashkenazi", .Pets = New String() {"Walker", "Sugar"}},
             New PetOwner With
             {.Name = "Price", .Pets = New String() {"Scratches", "Diesel"}},
             New PetOwner With
             {.Name = "Hines", .Pets = New String() {"Dusty"}}}

                ' Project an anonymous type that consists of
                ' the owner's name and the pet's name (string).
                Dim query =
            petOwners _
            .SelectMany(
                Function(petOwner) petOwner.Pets,
                Function(petOwner, petName) New With {petOwner, petName}) _
            .Where(Function(ownerAndPet) ownerAndPet.petName.StartsWith("S")) _
            .Select(Function(ownerAndPet) _
                   New With {.Owner = ownerAndPet.petOwner.Name,
                             .Pet = ownerAndPet.petName
                   })

                Dim output As New System.Text.StringBuilder
                For Each obj In query
                    output.AppendLine(String.Format("Owner={0}, Pet={1}", obj.Owner, obj.Pet))
                Next

                ' Display the output.
                MsgBox(output.ToString())
            End Sub

            ' This code produces the following output:
            '
            ' Owner=Higa, Pet=Scruffy
            ' Owner=Higa, Pet=Sam
            ' Owner=Ashkenazi, Pet=Sugar
            ' Owner=Price, Pet=Scratches
