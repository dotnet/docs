            class PetOwner
            {
                public string Name { get; set; }
                public List<string> Pets { get; set; }
            }

            public static void SelectManyEx2()
            {
                PetOwner[] petOwners = 
                    { new PetOwner { Name="Higa, Sidney", 
                          Pets = new List<string>{ "Scruffy", "Sam" } },
                      new PetOwner { Name="Ashkenazi, Ronen", 
                          Pets = new List<string>{ "Walker", "Sugar" } },
                      new PetOwner { Name="Price, Vernette", 
                          Pets = new List<string>{ "Scratches", "Diesel" } },
                      new PetOwner { Name="Hines, Patrick", 
                          Pets = new List<string>{ "Dusty" } } };

                // For each PetOwner element in the source array,
                // project a sequence of strings where each string
                // consists of the index of the PetOwner element in the
                // source array and the name of each pet in PetOwner.Pets.
                IEnumerable<string> query =
                    petOwners.AsQueryable()
                    .SelectMany(
                    (petOwner, index) => petOwner.Pets.Select(pet => index + pet)
                    );

                foreach (string pet in query)
                    Console.WriteLine(pet);
            }

            // This code produces the following output:
            //
            // 0Scruffy
            // 0Sam
            // 1Walker
            // 1Sugar
            // 2Scratches
            // 2Diesel
            // 3Dusty
