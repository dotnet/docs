        class Person
        {
            private string name = "N/A";
            private int age = 0;

            // Declare a Name property of type string:
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }

            // Declare an Age property of type int:
            public int Age
            {
                get
                {
                    return age;
                }

                set
                {
                    age = value;
                }
            }

            public override string ToString()
            {
                return "Name = " + Name + ", Age = " + Age;
            }
        }

        class TestPerson
        {
            static void Main()
            {
                // Create a new Person object:
                Person person = new Person();

                // Print out the name and the age associated with the person:
                Console.WriteLine("Person details - {0}", person);

                // Set some values on the person object:
                person.Name = "Joe";
                person.Age = 99;
                Console.WriteLine("Person details - {0}", person);

                // Increment the Age property:
                person.Age += 1;
                Console.WriteLine("Person details - {0}", person);

                // Keep the console window open in debug mode.
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
        /* Output:
            Person details - Name = N/A, Age = 0
            Person details - Name = Joe, Age = 99
            Person details - Name = Joe, Age = 100
        */