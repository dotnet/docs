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
}
