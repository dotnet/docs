        interface IEmployee
        {
            string Name
            {
                get;
                set;
            }

            int Counter
            {
                get;
            }
        }

        public class Employee : IEmployee
        {
            public static int numberOfEmployees;

            private string name;
            public string Name  // read-write instance property
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

            private int counter;
            public int Counter  // read-only instance property
            {
                get
                {
                    return counter;
                }
            }

            public Employee()  // constructor
            {
                counter = ++counter + numberOfEmployees;
            }
        }

        class TestEmployee
        {
            static void Main()
            {
                System.Console.Write("Enter number of employees: ");
                Employee.numberOfEmployees = int.Parse(System.Console.ReadLine());

                Employee e1 = new Employee();
                System.Console.Write("Enter the name of the new employee: ");
                e1.Name = System.Console.ReadLine();

                System.Console.WriteLine("The employee information:");
                System.Console.WriteLine("Employee number: {0}", e1.Counter);
                System.Console.WriteLine("Employee name: {0}", e1.Name);
            }
        }