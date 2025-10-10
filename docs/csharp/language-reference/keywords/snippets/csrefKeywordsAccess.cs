using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csrefKeywordsAccess
{
    //<snippet1>
    public class Person
    {
        protected string ssn = "444-55-6666";
        protected string name = "John L. Malgraine";

        public virtual void GetInfo()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"SSN: {ssn}");
        }
    }
    class Employee : Person
    {
        public readonly string id = "ABC567EFG";
        public override void GetInfo()
        {
            // Calling the base class GetInfo method:
            base.GetInfo();
            Console.WriteLine($"Employee ID: {id}");
        }
    }

    class TestClass
    {
        static void Main()
        {
            Employee E = new Employee();
            E.GetInfo();
        }
    }
    /*
    Output
    Name: John L. Malgraine
    SSN: 444-55-6666
    Employee ID: ABC567EFG
    */

    //</snippet1>

    //<snippet2>
    public class BaseClass
    {
        private int num;

        public BaseClass() => 
            Console.WriteLine("in BaseClass()");

        public BaseClass(int i)
        {
            num = i;
            Console.WriteLine("in BaseClass(int i)");
        }

        public int GetNum() => num;
    }

    public class DerivedClass : BaseClass
    {
        // This constructor will call BaseClass.BaseClass()
        public DerivedClass() : base() { }

        // This constructor will call BaseClass.BaseClass(int i)
        public DerivedClass(int i) : base(i) { }

        static void Main()
        {
            DerivedClass md = new DerivedClass();
            DerivedClass md1 = new DerivedClass(1);
        }
    }
    /*
    Output:
    in BaseClass()
    in BaseClass(int i)
    */
    //</snippet2>

    namespace Example1 //for redefinition of Employee
    {
        //<snippet4>
        public class Employee
        {
            private string alias;
            private string name;

            public Employee(string name, string alias)
            {
                // Use this to qualify the members of the class
                // instead of the constructor parameters.
                this.name = name;
                this.alias = alias;
            }
        }
        //</snippet4>
    }

    namespace Example2 //for redefinition of Employee
    {
        //<snippet3>
        class Employee
        {
            private string name;
            private string alias;

            // Constructor:
            public Employee(string name, string alias)
            {
                // Use this to qualify the fields, name and alias:
                this.name = name;
                this.alias = alias;
            }

            // Printing method:
            public void printEmployee()
            {
                Console.WriteLine($"""
                Name: {name}
                Alias: {alias}
                """);
                // Passing the object to the CalcTax method by using this:
                Console.WriteLine($"Taxes: {Tax.CalcTax(this):C}");
            }

            public decimal Salary { get; } = 3000.00m;
        }

        class Tax
        {
            public static decimal CalcTax(Employee E)=> 0.08m * E.Salary;
        }

        class Program
        {
            static void Main()
            {
                // Create objects:
                Employee E1 = new Employee("Mingda Pan", "mpan");

                // Display results:
                E1.printEmployee();
            }
        }
        /*
        Output:
            Name: Mingda Pan
            Alias: mpan
            Taxes: $240.00
         */

        //</snippet3>

        class Test
        {
            int[] array = new int[100];

            //<snippet5>
            public int this[int param]
            {
                get => array[param];
                set => array[param] = value;
            }
            //</snippet5>
        }
    } //end Example2 namespace
}