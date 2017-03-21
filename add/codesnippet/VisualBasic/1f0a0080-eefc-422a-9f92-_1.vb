            Structure PetOwner
                Public Name As String
                Public Pets() As String
            End Structure

            Sub SelectManyEx2()
                ' Create an array of PetOwner objects.
                Dim petOwners() As PetOwner =
            {New PetOwner With
             {.Name = "Higa, Sidney", .Pets = New String() {"Scruffy", "Sam"}},
             New PetOwner With
             {.Name = "Ashkenazi, Ronen", .Pets = New String() {"Walker", "Sugar"}},
             New PetOwner With
             {.Name = "Price, Vernette", .Pets = New String() {"Scratches", "Diesel"}},
             New PetOwner With
             {.Name = "Hines, Patrick", .Pets = New String() {"Dusty"}}}

                ' Project the items in the array by appending the index 
                ' of each PetOwner to each pet's name in that petOwner's 
                ' array of pets.
                Dim query As IEnumerable(Of String) =
            petOwners.SelectMany(Function(petOwner, index) _
                                     petOwner.Pets.Select(Function(pet) _
                                                              index.ToString() + pet))

                Dim output As New System.Text.StringBuilder
                For Each pet As String In query
                    output.AppendLine(pet)
                Next

                ' Display the output.
                MsgBox(output.ToString())
            End Sub