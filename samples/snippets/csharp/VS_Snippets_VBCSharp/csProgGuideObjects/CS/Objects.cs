using System;
using System.Collections.Generic;
using System.Text;

namespace CsCsrefProgrammingObjects
{
    namespace WrapCoords
    {

    }

    namespace WrapConstructorCalls
    {
        public class X
        {
            public X(double x, double y)
            {
            }
        }

        class Cylinder : X
        {
            //<Snippet6>
            public Cylinder(double radius, double height)
                : base(radius, height)
            {
            }
            //</Snippet6>
        }
        class Coords
        {
            public Coords(int x, int y)
            {
            }
            //<Snippet7>
            public Coords()
                : this(0, 20)
            {
            }
            //</Snippet7>
        }
    }

    //-----------------------------------------------------------------------------
    namespace WrapPerson3
    {
        //<Snippet84>
    public class Person
    {
        // Field
        public string name;

        // Constructor that takes no arguments.
        public Person()
        {
            name = "unknown";
        }

        // Constructor that takes one argument.
        public Person(string nm)
        {
            name = nm;
        }

        // Method
        public void SetName(string newName)
        {
            name = newName;
        }
    }
    class TestPerson
    {
        static void Main()
        {
            // Call the constructor that has no parameters.
            Person person1 = new Person();
            Console.WriteLine(person1.name);

            person1.SetName("John Smith");
            Console.WriteLine(person1.name);

            // Call the constructor that has one parameter.
            Person person2 = new Person("Sarah Jones");
            Console.WriteLine(person2.name);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    // Output:
    // unknown
    // John Smith
    // Sarah Jones
        //</Snippet84>
    }

    //-----------------------------------------------------------------------------
    namespace WrapPerson
    {

    }

    //-----------------------------------------------------------------------------


    namespace WrapShapeAndCircle
    {
        abstract class Shape
        {
            protected double x, y;

            public Shape(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        }


    }

    //-----------------------------------------------------------------------------
    //<Snippet27>
    class CompanyInfo
    {
        public string GetCompanyName() { return "CompanyName"; }
        public string GetCompanyAddress() { return "CompanyAddress"; }
        //...
    }
    //</Snippet27>

    namespace WrapCompanyInfo
    {
        //<Snippet28>
        static class CompanyInfo
        {
            public static string GetCompanyName() { return "CompanyName"; }
            public static string GetCompanyAddress() { return "CompanyAddress"; }
            //...
        }
        //</Snippet28>	
    }

    //<Snippet79>
    public class Customer
    {
        //Fields, properties, methods and events go here...
    }
    //</Snippet79>

    class Test
    {
        static void Main()
        {
            //<Snippet80>
            Customer object1 = new Customer();
            //</Snippet80>

            //<Snippet81>
            Customer object2;
            //</Snippet81>

            object2 = object1;

            //<Snippet82>
            Customer object3 = new Customer();
            Customer object4 = object3;
            //</Snippet82>
        }
    }

    //-----------------------------------------------------------------------------
    //<Snippet83>
    public class Manager : Employee
    {
        // Employee fields, properties, methods and events are inherited
        // New Manager fields, properties, methods and events go here...
    }
    //</Snippet83>

    //-----------------------------------------------------------------------------


    class TestParamKeywords
    {
        //<Snippet47>
        static void TestRef(ref char i) { }
        //</Snippet47>

        //<Snippet49>
        static void TestOut(out char i) { i = 'z'; }
        //</Snippet49>

        //<Snippet51>
        static void UseParams(params int[] list) { }
        //</Snippet51>

        void Test()
        {
            char i = 'a';

            //<Snippet48>
            TestRef(ref i);
            //</Snippet48>

            //<Snippet50>
            TestOut(out i);
            //</Snippet50>

            //<Snippet52>
            int[] myarray = new int[3] { 10, 11, 12 };

            UseParams(1, 2, 3);
            UseParams(myarray);
            UseParams();
            //</Snippet52>
        }
    }

    namespace WrapEmployee
    {




        class WrapEmployeeAndManager
        {

        }


    }

    //<snippet88>
    namespace ProgrammingGuide
    {
        // Class definition.
        public class MyCustomClass
        {
            // Class members:
            // Property.
            public int Number { get; set; }

            // Method.
            public int Multiply(int num)
            {
                return num * Number;
            }

            // Instance Constructor.
            public MyCustomClass()
            {
                Number = 0;
            }
        }
        // Another class definition. This one contains
        // the Main method, the entry point for the program.
        class Program
        {
            static void Main(string[] args)
            {
                // Create an object of type MyCustomClass.
                MyCustomClass myClass = new MyCustomClass();

                // Set the value of a public property.
                myClass.Number = 27;

                // Call a public method.
                int result = myClass.Multiply(4);
            }
        }
    }

    //</snippet88>
}

namespace RainyDay
{


    class RD
    {
        static void Main()
        {

            //<Snippet91>
            Console.WriteLine("Saving for a rainy day");
            //</Snippet91>
            //<Snippet92>
            Console.WriteLine("Saving for a rainy day");
            //</Snippet92>
            //<Snippet93>
            Console.WriteLine("Saving for a rainy day");
            //</Snippet93>
            //<Snippet94>
            Console.WriteLine("Saving for a rainy day");
            //</Snippet94>
            //<Snippet95>
            Console.WriteLine("Saving for a rainy day");
            //</Snippet95>
            //<Snippet96>
            Console.WriteLine("Saving for a rainy day");
            //</Snippet96>

            //<Snippet97>
            Console.WriteLine("Saving for a rainy day");
            //</Snippet97>
            //<Snippet98>
            Console.WriteLine("Saving for a rainy day");
            //</Snippet98>
        }
    }
}
