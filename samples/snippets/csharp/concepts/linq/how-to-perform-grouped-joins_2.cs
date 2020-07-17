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
        /// This example creates XML output from a grouped join.
        /// </summary>
        public static void GroupJoinXMLExample()
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

            // Create XML to display the hierarchical organization of people and their pets.
            XElement ownersAndPets = new XElement("PetOwners",
                from person in people
                join pet in pets on person equals pet.Owner into gj
                select new XElement("Person",
                    new XAttribute("FirstName", person.FirstName),
                    new XAttribute("LastName", person.LastName),
                    from subpet in gj
                    select new XElement("Pet", subpet.Name)));

            Console.WriteLine(ownersAndPets);
        }

        // This code produces the following output:
        //
        // <PetOwners>
        //   <Person FirstName="Magnus" LastName="Hedlund">
        //     <Pet>Daisy</Pet>
        //   </Person>
        //   <Person FirstName="Terry" LastName="Adams">
        //     <Pet>Barley</Pet>
        //     <Pet>Boots</Pet>
        //     <Pet>Blue Moon</Pet>
        //   </Person>
        //   <Person FirstName="Charlotte" LastName="Weiss">
        //     <Pet>Whiskers</Pet>
        //   </Person>
        //   <Person FirstName="Arlene" LastName="Huff" />
        // </PetOwners>
