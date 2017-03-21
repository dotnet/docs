            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }

            // This method creates and returns an array of Pet objects.
            static Pet[] GetCats()
            {
                Pet[] cats = { new Pet { Name="Barley", Age=8 },
                               new Pet { Name="Boots", Age=4 },
                               new Pet { Name="Whiskers", Age=1 } };
                return cats;
            }

            // This method creates and returns an array of Pet objects.
            static Pet[] GetDogs()
            {
                Pet[] dogs = { new Pet { Name="Bounder", Age=3 },
                               new Pet { Name="Snoopy", Age=14 },
                               new Pet { Name="Fido", Age=9 } };
                return dogs;
            }

            public static void ConcatEx1()
            {
                Pet[] cats = GetCats();
                Pet[] dogs = GetDogs();

                // Concatenate a collection of cat names to a
                // collection of dog names by using Concat().
                IEnumerable<string> query =
                    cats.AsQueryable()
                    .Select(cat => cat.Name)
                    .Concat(dogs.Select(dog => dog.Name));

                foreach (string name in query)
                    Console.WriteLine(name);
            }

            // This code produces the following output:
            //
            // Barley
            // Boots
            // Whiskers
            // Bounder
            // Snoopy
            // Fido
