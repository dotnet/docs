                // Create a list of Pet objects.
                List<Pet> pets =
                    new List<Pet>{ new Pet { Name="Barley", Age=8 },
                                   new Pet { Name="Boots", Age=4 },
                                   new Pet { Name="Whiskers", Age=1 } };

                // This query selects only those pets that are 10 or older.
                // In case there are no pets that meet that criteria, call
                // DefaultIfEmpty(). This code passes an (optional) default
                // value to DefaultIfEmpty().
                string[] oldPets =
                    pets.AsQueryable()
                    .Where(pet => pet.Age >= 10)
                    .Select(pet => pet.Name)
                    .DefaultIfEmpty("[EMPTY]")
                    .ToArray();

                Console.WriteLine("First query: " + oldPets[0]);

                // This query selects only those pets that are 10 or older.
                // This code does not call DefaultIfEmpty().
                string[] oldPets2 =
                    pets.AsQueryable()
                    .Where(pet => pet.Age >= 10)
                    .Select(pet => pet.Name)
                    .ToArray();

                // There may be no elements in the array, so directly
                // accessing element 0 may throw an exception.
                try
                {
                    Console.WriteLine("Second query: " + oldPets2[0]);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Second query: An exception was thrown: " + e.Message);
                }

                /*
                    This code produces the following output:
            
                    First query: [EMPTY]
                    Second query: An exception was thrown: Index was outside the bounds of the array.
                */
