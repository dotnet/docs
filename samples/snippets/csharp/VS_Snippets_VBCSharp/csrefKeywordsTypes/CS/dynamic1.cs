using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicSnippets
{
    //<Snippet21>
    class Program
    {
        static void Main(string[] args)
        {
            dynamic dyn = 1;
            object obj = 1;

            // Rest the mouse pointer over dyn and obj to see their
            // types at compile time.
            System.Console.WriteLine(dyn.GetType());
            System.Console.WriteLine(obj.GetType());
        }
    }
    //</Snippet21>

    //<Snippet22>
    class ExampleClass
    {
        // A dynamic field.
        static dynamic field;

        // A dynamic property.
        dynamic prop { get; set; }

        // A dynamic return type and a dynamic parameter type.
        public dynamic exampleMethod(dynamic d)
        {
            // A dynamic local variable.
            dynamic local = "Local variable";
            int two = 2;

            if (d is int)
            {
                return local;
            }
            else
            {
                return two;
            }
        }
    }
    //</Snippet22>

    class Examples
    {
        //<Snippet23>
        static void convertToDynamic()
        {
            dynamic d;
            int i = 20;
            d = (dynamic)i;
            Console.WriteLine(d);

            string s = "Example string.";
            d = (dynamic)s;
            Console.WriteLine(d);

            DateTime dt = DateTime.Today;
            d = (dynamic)dt;
            Console.WriteLine(d);
        }
        // Results:
        // 20
        // Example string.
        // 7/25/2018 12:00:00 AM
        //</Snippet23>

        static void ExamplesMethod()
        {
            var someVar = new ExampleClass();
            //<Snippet24>
            int i = 8;
            dynamic d;
            // With the is operator.
            // The dynamic type behaves like object. The following
            // expression returns true unless someVar has the value null.
            if (someVar is dynamic) { }

            // With the as operator.
            d = i as dynamic;

            // With typeof, as part of a constructed type.
            Console.WriteLine(typeof(List<dynamic>));

            // The following statement causes a compiler error.
            //Console.WriteLine(typeof(dynamic));
            //</Snippet24>
        }
    }
}
