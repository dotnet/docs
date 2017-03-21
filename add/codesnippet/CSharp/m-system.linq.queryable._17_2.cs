            class Pet
            {
                public string Name { get; set; }
                public int Age { get; set; }
            }
            class Person
            {
                public string LastName { get; set; }
                public Pet[] Pets { get; set; }
            }

            public static void AnyEx2()
            {
                List<Person> people = new List<Person>
                    { new Person { LastName = "Haas",
                                   Pets = new Pet[] { new Pet { Name="Barley", Age=10 },
                                                      new Pet { Name="Boots", Age=14 },
                                                      new Pet { Name="Whiskers", Age=6 }}},
                      new Person { LastName = "Fakhouri",
                                   Pets = new Pet[] { new Pet { Name = "Snowball", Age = 1}}},
                      new Person { LastName = "Antebi",
                                   Pets = new Pet[] { }},
                      new Person { LastName = "Philips",
                                   Pets = new Pet[] { new Pet { Name = "Sweetie", Age = 2},
                                                      new Pet { Name = "Rover", Age = 13}} }
                    };

                // Determine which people have a non-empty Pet array.
                IEnumerable<string> names = from person in people
                                            where person.Pets.AsQueryable().Any()
                                            select person.LastName;

                foreach (string name in names)
                    Console.WriteLine(name);

                /* This code produces the following output:
                  
                   Haas
                   Fakhouri
                   Philips
                */
            }