            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }

            public static void MaxEx2()
            {
                Pet[] pets = { new Pet { Name="Barley", Age=8 },
                               new Pet { Name="Boots", Age=4 },
                               new Pet { Name="Whiskers", Age=1 } };

                // Add Pet.Age to the length of Pet.Name
                // to determine the "maximum" Pet object in the array.
                int max =
                    pets.AsQueryable().Max(pet => pet.Age + pet.Name.Length);

                Console.WriteLine(
                    "The maximum pet age plus name length is {0}.",
                    max);
            }

            /*
                This code produces the following output:

                The maximum pet age plus name length is 14.
            */
