            class Person
            {
                public string Name { get; set; }
            }

            class Pet
            {
                public string Name { get; set; }
                public Person Owner { get; set; }
            }

            public static void JoinEx1()
            {
                Person magnus = new Person { Name = "Hedlund, Magnus" };
                Person terry = new Person { Name = "Adams, Terry" };
                Person charlotte = new Person { Name = "Weiss, Charlotte" };

                Pet barley = new Pet { Name = "Barley", Owner = terry };
                Pet boots = new Pet { Name = "Boots", Owner = terry };
                Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
                Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

                List<Person> people = new List<Person> { magnus, terry, charlotte };
                List<Pet> pets = new List<Pet> { barley, boots, whiskers, daisy };

                // Join the list of Person objects and the list of Pet objects 
                // to create a list of person-pet pairs where each element is 
                // an anonymous type that contains the name of pet and the name
                // of the person that owns the pet.
                var query = people.AsQueryable().Join(pets,
                                person => person,
                                pet => pet.Owner,
                                (person, pet) =>
                                    new { OwnerName = person.Name, Pet = pet.Name });

                foreach (var obj in query)
                {
                    Console.WriteLine(
                        "{0} - {1}",
                        obj.OwnerName,
                        obj.Pet);
                }
            }

            /*
                This code produces the following output:

                Hedlund, Magnus - Daisy
                Adams, Terry - Barley
                Adams, Terry - Boots
                Weiss, Charlotte - Whiskers
            */
