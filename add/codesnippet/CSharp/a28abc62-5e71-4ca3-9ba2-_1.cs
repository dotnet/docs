            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }

            public static void MinEx2()
            {
                Pet[] pets = { new Pet { Name="Barley", Age=8 },
                               new Pet { Name="Boots", Age=4 },
                               new Pet { Name="Whiskers", Age=1 } };

                // Get the Pet object that has the smallest Age value.
                int min = pets.AsQueryable().Min(pet => pet.Age);

                Console.WriteLine("The youngest animal is age {0}.", min);
            }

            /*
                This code produces the following output:

                The youngest animal is age 1.  
            */
