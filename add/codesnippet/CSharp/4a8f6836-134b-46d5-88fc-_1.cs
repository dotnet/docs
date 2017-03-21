            class Pet
            {
                public string Name { get; set; }
                public bool Vaccinated { get; set; }
            }

            public static void CountEx2()
            {
                // Create an array of Pet objects.
                Pet[] pets = { new Pet { Name="Barley", Vaccinated=true },
                               new Pet { Name="Boots", Vaccinated=false },
                               new Pet { Name="Whiskers", Vaccinated=false } };

                // Count the number of unvaccinated pets in the array.
                int numberUnvaccinated =
                    pets.AsQueryable().Count(p => p.Vaccinated == false);

                Console.WriteLine(
                    "There are {0} unvaccinated animals.",
                    numberUnvaccinated);
            }

            // This code produces the following output:
            //
            // There are 2 unvaccinated animals.
