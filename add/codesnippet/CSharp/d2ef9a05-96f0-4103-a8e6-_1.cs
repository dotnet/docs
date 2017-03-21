            class Person
            {
                public string Name { get; set; }
            }

            class Pet
            {
                public string Name { get; set; }
                public Person Owner { get; set; }
            }

            public static void GroupJoinEx1()
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

                // Create a list where each element is an anonymous 
                // type that contains a person's name and a collection 
                // of names of the pets that are owned by them.
                var query =
                    people.AsQueryable().GroupJoin(pets,
                                     person => person,
                                     pet => pet.Owner,
                                     (person, petCollection) =>
                                         new
                                         {
                                             OwnerName = person.Name,
                                             Pets = petCollection.Select(pet => pet.Name)
                                         });

                foreach (var obj in query)
                {
                    // Output the owner's name.
                    Console.WriteLine("{0}:", obj.OwnerName);
                    // Output each of the owner's pet's names.
                    foreach (string pet in obj.Pets)
                        Console.WriteLine("  {0}", pet);
                }
            }

            /*
                This code produces the following output:

                Hedlund, Magnus:
                  Daisy
                Adams, Terry:
                  Barley
                  Boots
                Weiss, Charlotte:
                  Whiskers
            */
