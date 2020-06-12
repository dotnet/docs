using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csrefKeywordsMethodParams
{
    //<snippet5>
    class Child
    {
        private int age;
        private string name;

        // Default constructor:
        public Child()
        {
            name = "N/A";
        }

        // Constructor:
        public Child(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        // Printing method:
        public void PrintChild()
        {
            Console.WriteLine("{0}, {1} years old.", name, age);
        }
    }

    class StringTest
    {
        static void Main()
        {
            // Create objects by using the new operator:
            Child child1 = new Child("Craig", 11);
            Child child2 = new Child("Sally", 10);

            // Create an object using the default constructor:
            Child child3 = new Child();

            // Display results:
            Console.Write("Child #1: ");
            child1.PrintChild();
            Console.Write("Child #2: ");
            child2.PrintChild();
            Console.Write("Child #3: ");
            child3.PrintChild();
        }
    }
    /* Output:
        Child #1: Craig, 11 years old.
        Child #2: Sally, 10 years old.
        Child #3: N/A, 0 years old.
    */
    //</snippet5>

    //<snippet14>
    interface ISampleInterface
    {
        void SampleMethod();
    }

    class ImplementationClass : ISampleInterface
    {
        // Explicit interface member implementation:
        void ISampleInterface.SampleMethod()
        {
            // Method implementation.
        }

        static void Main()
        {
            // Declare an interface instance.
            ISampleInterface obj = new ImplementationClass();

            // Call the member.
            obj.SampleMethod();
        }
    }
    //</snippet14>

    //<snippet15>
    interface IPoint
    {
       // Property signatures:
       int X
       {
          get;
          set;
       }

       int Y
       {
          get;
          set;
       }

       double Distance
       {
           get;
       }
    }

    class Point : IPoint
    {
       // Constructor:
       public Point(int x, int y)
       {
          X = x;
          Y = y;
       }

       // Property implementation:
       public int X { get; set; }

       public int Y { get; set; }

       // Property implementation
       public double Distance =>
          Math.Sqrt(X * X + Y * Y);

    }

    class MainClass
    {
       static void PrintPoint(IPoint p)
       {
          Console.WriteLine("x={0}, y={1}", p.X, p.Y);
       }

       static void Main()
       {
          IPoint p = new Point(2, 3);
          Console.Write("My Point: ");
          PrintPoint(p);
       }
    }
    // Output: My Point: x=2, y=3
    //</snippet15>

    class VarTest
    {
        #region compilation only
        class Customer
        {
            public string City { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
        }

        #endregion
        static void Main()
        {
            List<Customer> customers = new List<Customer>();
            //<snippet18>
            // Example #1: var is optional when
            // the select clause specifies a string
            string[] words = { "apple", "strawberry", "grape", "peach", "banana" };
            var wordQuery = from word in words
                            where word[0] == 'g'
                            select word;

            // Because each element in the sequence is a string,
            // not an anonymous type, var is optional here also.
            foreach (string s in wordQuery)
            {
                Console.WriteLine(s);
            }

            // Example #2: var is required because
            // the select clause specifies an anonymous type
            var custQuery = from cust in customers
                            where cust.City == "Phoenix"
                            select new { cust.Name, cust.Phone };

            // var must be used because each item
            // in the sequence is an anonymous type
            foreach (var item in custQuery)
            {
                Console.WriteLine("Name={0}, Phone={1}", item.Name, item.Phone);
            }
            //</snippet18>
        }
    }
}
