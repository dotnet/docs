        class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        class Pet
        {
            public string Name { get; set; }
            public Person Owner { get; set; }
        }

        /// <summary>
        /// This example performs a grouped join.
        /// </summary>
        public static void GroupJoinExample()
        {
            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Name = "Blue Moon", Owner = terry };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            // Create two lists.
            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

            // Create a list where each element is an anonymous type
            // that contains the person's first name and a collection of
            // pets that are owned by them.
            var query = from person in people
                        join pet in pets on person equals pet.Owner into gj
                        select new { OwnerName = person.FirstName, Pets = gj };

            foreach (var v in query)
            {
                // Output the owner's name.
                Console.WriteLine($"{v.OwnerName}:");
                // Output each of the owner's pet's names.
                foreach (Pet pet in v.Pets)
                    Console.WriteLine($"  {pet.Name}");
            }
        }

        // This code produces the following output:
        //
        // Magnus:
        //   Daisy
        // Terry:
        //   Barley
        //   Boots
        //   Blue Moon
        // Charlotte:
        //   Whiskers
        // Arlene:
