        public struct Person
        {
            public string Name;
            public int Age;
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }

        public class Application
        {
            static void Main()
            {
                // Create  struct instance and initialize by using "new".
                // Memory is allocated on thread stack.
                Person p1 = new Person("Alex", 9);
                Console.WriteLine("p1 Name = {0} Age = {1}", p1.Name, p1.Age);

                // Create  new struct object. Note that  struct can be initialized
                // without using "new".
                Person p2 = p1;

                // Assign values to p2 members.
                p2.Name = "Spencer";
                p2.Age = 7;
                Console.WriteLine("p2 Name = {0} Age = {1}", p2.Name, p2.Age);

                // p1 values remain unchanged because p2 is  copy.
                Console.WriteLine("p1 Name = {0} Age = {1}", p1.Name, p1.Age);

                // Keep the console open in debug mode.
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
        /*
          Output:
            p1 Name = Alex Age = 9
            p2 Name = Spencer Age = 7
            p1 Name = Alex Age = 9
        */