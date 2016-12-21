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

        class Cat : Pet
        { }

        class Dog : Pet
        { }

        public static void MultipleJoinExample()
        {
            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };
            Person rui = new Person { FirstName = "Rui", LastName = "Raposo" };
            Person phyllis = new Person { FirstName = "Phyllis", LastName = "Harris" };

            Cat barley = new Cat { Name = "Barley", Owner = terry };
            Cat boots = new Cat { Name = "Boots", Owner = terry };
            Cat whiskers = new Cat { Name = "Whiskers", Owner = charlotte };
            Cat bluemoon = new Cat { Name = "Blue Moon", Owner = rui };
            Cat daisy = new Cat { Name = "Daisy", Owner = magnus };

            Dog fourwheeldrive = new Dog { Name = "Four Wheel Drive", Owner = phyllis };
            Dog duke = new Dog { Name = "Duke", Owner = magnus };
            Dog denim = new Dog { Name = "Denim", Owner = terry };
            Dog wiley = new Dog { Name = "Wiley", Owner = charlotte };
            Dog snoopy = new Dog { Name = "Snoopy", Owner = rui };
            Dog snickers = new Dog { Name = "Snickers", Owner = arlene };

            // Create three lists.
            List<Person> people =
                new List<Person> { magnus, terry, charlotte, arlene, rui, phyllis };
            List<Cat> cats =
                new List<Cat> { barley, boots, whiskers, bluemoon, daisy };
            List<Dog> dogs =
                new List<Dog> { fourwheeldrive, duke, denim, wiley, snoopy, snickers };

            // The first join matches Person and Cat.Owner from the list of people and
            // cats, based on a common Person. The second join matches dogs whose names start
            // with the same letter as the cats that have the same owner.
            var query = from person in people
                        join cat in cats on person equals cat.Owner
                        join dog in dogs on 
                        new { Owner = person, Letter = cat.Name.Substring(0, 1) }
                        equals new { dog.Owner, Letter = dog.Name.Substring(0, 1) }
                        select new { CatName = cat.Name, DogName = dog.Name };

            foreach (var obj in query)
            {
                Console.WriteLine( 
                    $"The cat \"{obj.CatName}\" shares a house, and the first letter of their name,
                    with \"{obj.DogName}\".");  
            }
        }

        // This code produces the following output:
        //
        // The cat "Daisy" shares a house, and the first letter of their name, with "Duke".
        // The cat "Whiskers" shares a house, and the first letter of their name, with "Wiley".
