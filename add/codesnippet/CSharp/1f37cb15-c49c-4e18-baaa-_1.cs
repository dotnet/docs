            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }

            public static void SequenceEqualEx1()
            {
                Pet pet1 = new Pet { Name = "Turbo", Age = 2 };
                Pet pet2 = new Pet { Name = "Peanut", Age = 8 };

                // Create two lists of pets.
                List<Pet> pets1 = new List<Pet> { pet1, pet2 };
                List<Pet> pets2 = new List<Pet> { pet1, pet2 };

                // Determine if the lists are equal.
                bool equal = pets1.AsQueryable().SequenceEqual(pets2);

                Console.WriteLine(
                    "The lists {0} equal.",
                    equal ? "are" : "are not");
            }

            /*
                This code produces the following output:

                The lists are equal.
            */
