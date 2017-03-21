            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }

            public static void OrderByEx1()
            {
                Pet[] pets = { new Pet { Name="Barley", Age=8 },
                               new Pet { Name="Boots", Age=4 },
                               new Pet { Name="Whiskers", Age=1 } };

                // Sort the Pet objects in the array by Pet.Age.
                IEnumerable<Pet> query =
                    pets.AsQueryable().OrderBy(pet => pet.Age);

                foreach (Pet pet in query)
                    Console.WriteLine("{0} - {1}", pet.Name, pet.Age);
            }

            /*
                This code produces the following output:

                Whiskers - 1
                Boots - 4
                Barley - 8
            */
