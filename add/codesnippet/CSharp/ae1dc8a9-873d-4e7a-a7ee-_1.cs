            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
                public bool Vaccinated { get; set; }
            }

            public static void AnyEx3()
            {
                // Create an array of Pet objects.
                Pet[] pets =
                    { new Pet { Name="Barley", Age=8, Vaccinated=true },
                      new Pet { Name="Boots", Age=4, Vaccinated=false },
                      new Pet { Name="Whiskers", Age=1, Vaccinated=false } };

                // Determine whether any pets over age 1 are also unvaccinated.
                bool unvaccinated =
                    pets.AsQueryable().Any(p => p.Age > 1 && p.Vaccinated == false);

                Console.WriteLine(
                    "There {0} unvaccinated animals over age one.",
                    unvaccinated ? "are" : "are not any");
            }

            // This code produces the following output:
            //
            //  There are unvaccinated animals over age one. 
