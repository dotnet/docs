﻿namespace CsCsrefProgrammingProperties
{
    using System.Linq;
    using System.Collections.Generic;
    using System;
    using System.Collections.ObjectModel;

    //---------------------------------------------------------------------------
    namespace WrapProperties
    {
        //<Snippet1>
        class TimePeriod
        {
            private double seconds;

            public double Hours
            {
				get => seconds / 3600;
                set => seconds = value * 3600;
            }
        }

        class Program
        {
            static void Main()
            {
                TimePeriod t = new TimePeriod();

                // Assigning the Hours property causes the 'set' accessor to be called.
                t.Hours = 24;

                // Evaluating the Hours property causes the 'get' accessor to be called.
                System.Console.WriteLine("Time in hours: " + t.Hours);
            }
        }
        // Output: Time in hours: 24
        //</Snippet1>
    }

    //---------------------------------------------------------------------------
    namespace WrapUsingExample1
    {
        //<Snippet2>
        public class Employee
        {
            public static int NumberOfEmployees;
            private static int _counter;
            private string _name;

            // A read-write instance property:
            public string Name
            {
                get => _name;
                set => _name = value;
            }

            // A read-only static property:
            public static int Counter => _counter;

            // A Constructor:
            public Employee() => _counter = ++NumberOfEmployees; // Calculate the employee's number:
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
        //</Snippet2>
    }

    //---------------------------------------------------------------------------
    namespace WrapUsingExample2
    {
        //<Snippet3>
        public class Employee
        {
            private string _name;
            public string Name
            {
                get => _name;
                set => _name = value;
            }
        }

        public class Manager : Employee
        {
            private string _name;

            // Notice the use of the new modifier:
            //<Snippet4>
            public new string Name
            //</Snippet4>
            {
                get => _name;
                set => _name = value + ", Manager";
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
                //<Snippet5>
                ((Employee)m1).Name = "Mary";
                //</Snippet5>

                System.Console.WriteLine("Name in the derived class is: {0}", m1.Name);
                System.Console.WriteLine("Name in the base class is: {0}", ((Employee)m1).Name);
            }
        }
        /* Output:
            Name in the derived class is: John, Manager
            Name in the base class is: Mary
        */
        //</Snippet3>
    }

    //---------------------------------------------------------------------------
    namespace WrapUsingExample3
    {
        //<Snippet6>
        abstract class Shape
        {
            public abstract double Area
            {
                get;
                set;
            }
        }

        class Square : Shape
        {
            public double side;

            //constructor
			public Square(double s) => side = s;

            public override double Area
            {
                get => side * side;
                set => side = System.Math.Sqrt(value);
            }
        }

        class Cube : Shape
        {
            public double side;

            //constructor
			public Cube(double s) => side = s;

            public override double Area
            {
                get => 6 * side * side;
                set => side = System.Math.Sqrt(value / 6);
            }
        }

        class TestShapes
        {
            static void Main()
            {
                // Input the side:
                System.Console.Write("Enter the side: ");
                double side = double.Parse(System.Console.ReadLine());

                // Compute the areas:
                Square s = new Square(side);
                Cube c = new Cube(side);

                // Display the results:
                System.Console.WriteLine("Area of the square = {0:F2}", s.Area);
                System.Console.WriteLine("Area of the cube = {0:F2}", c.Area);
                System.Console.WriteLine();

                // Input the area:
                System.Console.Write("Enter the area: ");
                double area = double.Parse(System.Console.ReadLine());

                // Compute the sides:
                s.Area = area;
                c.Area = area;

                // Display the results:
                System.Console.WriteLine("Side of the square = {0:F2}", s.side);
                System.Console.WriteLine("Side of the cube = {0:F2}", c.side);
            }
        }
        /* Example Output:
            Enter the side: 4
            Area of the square = 16.00
            Area of the cube = 96.00

            Enter the area: 24
            Side of the square = 4.90
            Side of the cube = 2.00
        */
        //</Snippet6>
    }

    //---------------------------------------------------------------------------
    class WrapUsing
    {
        //<Snippet7>
        public class Date
        {
            private int _month = 7;  // Backing store

            public int Month
            {
                get => _month;
                set
                {
                    if ((value > 0) && (value < 13))
                    {
                        _month = value;
                    }
                }
            }
        }
        //</Snippet7>

        //<Snippet8>
        class Person
        {
            private string _name;  // the name field
            public string Name => _name;     // the Name property
        }
        //</Snippet8>

        class TestPerson
        {
            static void Main()
            {
                //<Snippet9>
                Person person = new Person();
                //...

                System.Console.Write(person.Name);  // the get accessor is invoked here
                //</Snippet9>
            }
        }

        //<Snippet10>
        private int _number;
        public int Number => _number++;	// Don't do this
        //</Snippet10>

        //<Snippet11>
        class Employee
        {
            private string _name;
            public string Name => _name != null ? _name : "NA";
        }
        //</Snippet11>
    }

    //---------------------------------------------------------------------------
    class WrapUsing2
    {
        //<Snippet12>
        class Person
        {
            private string _name;  // the name field
            public string Name    // the Name property
            {
                get => _name;
                set => _name = value;
            }
        }
        //</Snippet12>

        class TestPerson
        {
            static void Main()
            {
                //<Snippet13>
                Person person = new Person();
                person.Name = "Joe";  // the set accessor is invoked here

                System.Console.Write(person.Name);  // the get accessor is invoked here
                //</Snippet13>
            }
        }
    }

    class ReadOnlyPropertyExamples
    {

        private List<string> names;
        public ReadOnlyPropertyExamples()
        {
            names = new List<string>() { "Deborah", "Alex", "Sasha" };
        }
        public IEnumerable<string> Names
        {
            get
            {
                return names;
            }
        }

        public IEnumerable<string> Names_2
        {
            get
            {
                return from name in names select name;
            }
        }

        public ReadOnlyCollection<string> Names_3
        {
            get
            {
                return names.AsReadOnly(); //return list as a ReadOnlyCollection
            }
        }

        public List<string> BadProp
        {
            get { return names; }
        }
    }

    class Program
    {
        static void Main()
        {
            ReadOnlyPropertyExamples ro = new ReadOnlyPropertyExamples();
            System.Console.WriteLine("return names");
            foreach(string s in ro.Names)
                System.Console.WriteLine(s);
            List<string> list = ro.Names.ToList();
            list.Add("Joy");
            Console.WriteLine("added 'Joy' to local list");
            foreach(string s in ro.Names)
                Console.WriteLine(s);

            //names_2
            System.Console.WriteLine("return from names...");
           // foreach (string s in ro.Names_2)
           //     System.Console.WriteLine(s);
           //list = ro.Names_2.ToList();
           // list.Add("Joy");
           // Console.WriteLine("added 'Joy' to local list");

            var q = from s in ro.Names_2
                    where s.Contains('x')
                    select s;
            foreach (string str in q)
                Console.WriteLine(str);

            List<string> list2 = ro.Names_2.ToList();

            list2.RemoveAt(0);

            foreach(string s in list2)
                Console.WriteLine(s);

            //names_3
            System.Console.WriteLine("return AsReadOnly...");
            foreach (string s in ro.Names_3)
                System.Console.WriteLine(s);

            //ROC allows [] access
            Console.WriteLine("names_3[0] = {0}", ro.Names_3[0]);

            //throws runtime exceptions on unimplemented interface methods
            IList<string> myList = (IList<string>)ro.Names_3;
            try
            {
                myList.RemoveAt(0); //throws not supported exception at run time
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine("RemoveAt is not implemented in ReadOnlyCollection<T>");
            }

            //add name then interate private list
            List<string> badList = ro.BadProp;
            badList.Add("Ha ha");

            foreach(string s in ro.Names)
                Console.WriteLine(s);

            // Keep the console open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
