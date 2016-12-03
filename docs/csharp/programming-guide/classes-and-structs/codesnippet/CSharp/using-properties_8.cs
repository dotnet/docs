        public class Employee
        {
            public static int NumberOfEmployees;
            private static int counter;
            private string name;

            // A read-write instance property:
            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            // A read-only static property:
            public static int Counter
            {
                get { return counter; }
            }

            // A Constructor:
            public Employee()
            {
                // Calculate the employee's number:
                counter = ++counter + NumberOfEmployees;
            }
        }

        class TestEmployee
        {
            static void Main()
            {
                Employee.NumberOfEmployees = 107;
                Employee e1 = new Employee();
                e1.Name = "Claude Vige";

                System.Console.WriteLine("Employee number: {0}", Employee.Counter);
                System.Console.WriteLine("Employee name: {0}", e1.Name);
            }
        }
        /* Output:
            Employee number: 108
            Employee name: Claude Vige
        */