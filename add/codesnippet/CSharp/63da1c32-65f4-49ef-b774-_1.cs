            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }

            public static void AllEx1()
            {
                // Create an array of Pets.
                Pet[] pets = { new Pet { Name="Barley", Age=10 },
                               new Pet { Name="Boots", Age=4 },
                               new Pet { Name="Whiskers", Age=6 } };

                // Determine whether all pet names in the array start with 'B'.
                bool allStartWithB =
                    pets.AsQueryable().All(pet => pet.Name.StartsWith("B"));

                Console.WriteLine(
                    "{0} pet names start with 'B'.",
                    allStartWithB ? "All" : "Not all");
            }

            // This code produces the following output:
            //
            //  Not all pet names start with 'B'. 
