            class PetOwner
            {
                public string Name { get; set; }
                public List<Pet> Pets { get; set; }
            }

            class Pet
            {
                public string Name { get; set; }
                public string Breed { get; set; }
            }

            public static void SelectManyEx3()
            {
                PetOwner[] petOwners =
                    { new PetOwner { Name="Higa", 
                          Pets = new List<Pet>{
                              new Pet { Name="Scruffy", Breed="Poodle" },
                              new Pet { Name="Sam", Breed="Hound" } } },
                      new PetOwner { Name="Ashkenazi", 
                          Pets = new List<Pet>{
                              new Pet { Name="Walker", Breed="Collie" },
                              new Pet { Name="Sugar", Breed="Poodle" } } },
                      new PetOwner { Name="Price", 
                          Pets = new List<Pet>{
                              new Pet { Name="Scratches", Breed="Dachshund" },
                              new Pet { Name="Diesel", Breed="Collie" } } },
                      new PetOwner { Name="Hines", 
                          Pets = new List<Pet>{
                              new Pet { Name="Dusty", Breed="Collie" } } }
                    };

                // This query demonstrates how to obtain a sequence of
                // the names of all the pets whose breed is "Collie", while
                // keeping an association with the owner that owns the pet.
                var query =
                    petOwners.AsQueryable()
                    // Create a sequence of ALL the Pet objects. Then
                    // project an anonymous type that consists of each
                    // Pet in the new sequence and the PetOwner object
                    // from the initial array that corresponds to that pet.
                   .SelectMany(owner => owner.Pets,
                               (owner, pet) => new { owner, pet })
                    // Filter the sequence of anonymous types to only
                    // keep pets whose breed is "Collie".
                    .Where(ownerAndPet => ownerAndPet.pet.Breed == "Collie")
                    // Project an anonymous type that consists
                    // of the pet owner's name and the pet's name.
                    .Select(ownerAndPet => new
                    {
                        Owner = ownerAndPet.owner.Name,
                        Pet = ownerAndPet.pet.Name
                    });

                // Print the results.
                foreach (var obj in query)
                    Console.WriteLine(obj);
            }

            /* This code produces the following output:
            
                { Owner = Ashkenazi, Pet = Walker }
                { Owner = Price, Pet = Diesel }
                { Owner = Hines, Pet = Dusty }
            */
