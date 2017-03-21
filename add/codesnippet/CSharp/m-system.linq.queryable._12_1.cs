            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }

            public static void DefaultIfEmptyEx1()
            {
                // Create a list of Pet objects.
                List<Pet> pets =
                    new List<Pet>{ new Pet { Name="Barley", Age=8 },
                                   new Pet { Name="Boots", Age=4 },
                                   new Pet { Name="Whiskers", Age=1 } };

                // Call DefaultIfEmtpy() on the collection that Select()
                // returns, so that if the initial list is empty, there
                // will always be at least one item in the returned array.
                string[] names =
                    pets.AsQueryable()
                    .Select(pet => pet.Name)
                    .DefaultIfEmpty()
                    .ToArray();

                string first = names[0];
                Console.WriteLine(first);
            }

            /*
                This code produces the following output:

                Barley
            */