        public class Person
        {
            public int age;
            public string name;
        }

        class TestPerson
        {
            static void Main()
            {
                Person person = new Person();

                Console.WriteLine("Name: {0}, Age: {1}", person.name, person.age);
                // Keep the console window open in debug mode.
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
        // Output:  Name: , Age: 0