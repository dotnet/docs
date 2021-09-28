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
        /// Performs an inner join by using GroupJoin().
        /// </summary>
        public static void InnerGroupJoinExample()
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

            var query1 = from person in people
                         join pet in pets on person equals pet.Owner into gj
                         from subpet in gj
                         select new { OwnerName = person.FirstName, PetName = subpet.Name };

            Console.WriteLine("Inner join using GroupJoin():");
            foreach (var v in query1)
            {
                Console.WriteLine($"{v.OwnerName} - {v.PetName}");
            }

            var query2 = from person in people
                         join pet in pets on person equals pet.Owner
                         select new { OwnerName = person.FirstName, PetName = pet.Name };

            Console.WriteLine("\nThe equivalent operation using Join():");
            foreach (var v in query2)
                Console.WriteLine($"{v.OwnerName} - {v.PetName}");
        }

        // This code produces the following output:
        //
        // Inner join using GroupJoin():
        // Magnus - Daisy
        // Terry - Barley
        // Terry - Boots
        // Terry - Blue Moon
        // Charlotte - Whiskers
        //
        // The equivalent operation using Join():
        // Magnus - Daisy
        // Terry - Barley
        // Terry - Boots
        // Terry - Blue Moon
        // Charlotte - Whiskers
