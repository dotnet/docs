using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeywordsUberProject
{
    //<snippet5>
    class ItemFactory<T> where T : new()
    {
        public T GetNewItem()
        {
            return new T();
        }
    }
   //</snippet5>

    //<snippet6>
    public class ItemFactory2<T>
        where T : IComparable, new()
    {  }
    //</snippet6>

    //<snippet8>
    public class BaseC
    {
        public int x;
        public void Invoke() { }
    }
    public class DerivedC : BaseC
    {
        new public void Invoke() { }
    }
    //</snippet8>

    namespace newModifier //to allow reuse of BaseC and DerivedC
    {
        //<snippet9>
        public class BaseC
        {
            public static int x = 55;
            public static int y = 22;
        }

        public class DerivedC : BaseC
        {
            // Hide field 'x'.
            new public static int x = 100;

            static void Main()
            {
                // Display the new value of x:
                Console.WriteLine(x);

                // Display the hidden value of x:
                Console.WriteLine(BaseC.x);

                // Display the unhidden member y:
                Console.WriteLine(y);
            }
        }
        /*
        Output:
        100
        55
        22
        */
        //</snippet9>

    namespace newModifier2
    {
    //<snippet10>
    public class BaseC
    {
        public class NestedC
        {
            public int x = 200;
            public int y;
        }
    }

    public class DerivedC : BaseC
    {
        // Nested type hiding the base type members.
        new public class NestedC
        {
            public int x = 100;
            public int y;
            public int z;
        }

        static void Main()
        {
            // Creating an object from the overlapping class:
            NestedC c1  = new NestedC();

            // Creating an object from the hidden class:
            BaseC.NestedC c2 = new BaseC.NestedC();

            Console.WriteLine(c1.x);
            Console.WriteLine(c2.x);
        }
    }
    /*
    Output:
    100
    200
    */
     //</snippet10>
        }
    }
}
