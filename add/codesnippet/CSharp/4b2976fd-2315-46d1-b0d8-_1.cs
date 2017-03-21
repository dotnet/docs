            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }

            public static void GroupByEx1()
            {
                // Create a list of Pet objects.
                List<Pet> pets =
                    new List<Pet>{ new Pet { Name="Barley", Age=8 },
                                   new Pet { Name="Boots", Age=4 },
                                   new Pet { Name="Whiskers", Age=1 },
                                   new Pet { Name="Daisy", Age=4 } };

                // Group the pets using Pet.Age as the key.
                // Use Pet.Name as the value for each entry.
                var query = pets.AsQueryable().GroupBy(pet => pet.Age);

                // Iterate over each IGrouping in the collection.
                foreach (var ageGroup in query)
                {
                    Console.WriteLine("Age group: {0}  Number of pets: {1}", ageGroup.Key, ageGroup.Count());
                }
            }

            /*
                This code produces the following output:

                Age group: 8  Number of pets: 1
                Age group: 4  Number of pets: 2
                Age group: 1  Number of pets: 1
             
            */
