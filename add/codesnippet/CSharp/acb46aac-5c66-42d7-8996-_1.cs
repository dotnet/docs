            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }

            public static void GroupByEx2()
            {
                // Create a list of Pet objects.
                List<Pet> pets =
                    new List<Pet>{ new Pet { Name="Barley", Age=8 },
                                   new Pet { Name="Boots", Age=4 },
                                   new Pet { Name="Whiskers", Age=1 },
                                   new Pet { Name="Daisy", Age=4 } };

                // Group the pets using Pet.Age as the key.
                // Use Pet.Name as the value for each entry.
                IEnumerable<IGrouping<int, string>> query =
                    pets.AsQueryable().GroupBy(pet => pet.Age, pet => pet.Name);

                // Iterate over each IGrouping in the collection.
                foreach (IGrouping<int, string> petGroup in query)
                {
                    // Print the key value of the IGrouping.
                    Console.WriteLine(petGroup.Key);
                    // Iterate over each value in the 
                    // IGrouping and print the value.
                    foreach (string name in petGroup)
                        Console.WriteLine("  {0}", name);
                }
            }

            /*
                This code produces the following output:

                8
                  Barley
                4
                  Boots
                  Daisy
                1
                  Whiskers
            */
