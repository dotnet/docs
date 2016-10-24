        public class Employee
        {
            private string name;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
        }

        public class Manager : Employee
        {
            private string name;

            // Notice the use of the new modifier:
            public new string Name
            {
                get { return name; }
                set { name = value + ", Manager"; }
            }
        }

        class TestHiding
        {
            static void Main()
            {
                Manager m1 = new Manager();

                // Derived class property.
                m1.Name = "John";

                // Base class property.
                ((Employee)m1).Name = "Mary";

                System.Console.WriteLine("Name in the derived class is: {0}", m1.Name);
                System.Console.WriteLine("Name in the base class is: {0}", ((Employee)m1).Name);
            }
        }
        /* Output:
            Name in the derived class is: John, Manager
            Name in the base class is: Mary
        */