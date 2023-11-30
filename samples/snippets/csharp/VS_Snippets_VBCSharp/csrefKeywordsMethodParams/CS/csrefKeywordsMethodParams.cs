using System;

namespace KeywordsMethodParams
{

    //<snippet1>
    class OutExample
    {
        static void Method(out int i)
        {
            i = 44;
        }
        static void Main()
        {
            int value;
            Method(out value);
            // value is now 44
        }
    }
    //</snippet1>

    /* Commented out because this deliberately produces a compile error.
    //<snippet2>
    class CS0663_Example
    {
        // Compiler error CS0663: "Cannot define overloaded
        // methods that differ only on ref and out".
        public void SampleMethod(out int i) { }
        public void SampleMethod(ref int i) { }
    }
    //</snippet2>
    */

    //<snippet3>
    class OutOverloadExample
    {
        public void SampleMethod(int i) { }
        public void SampleMethod(out int i) { i = 5; }
    }
    //</snippet3>

    //<snippet4>
    class OutReturnExample
    {
        static void Method(out int i, out string s1, out string s2)
        {
            i = 44;
            s1 = "I've been returned";
            s2 = null;
        }
        static void Main()
        {
            int value;
            string str1, str2;
            Method(out value, out str1, out str2);
            // value is now 44
            // str1 is now "I've been returned"
            // str2 is (still) null;
        }
    }

    //</snippet4>

    //<snippet5>
    public class MyClass
    {
        public static void UseParams(params int[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }

        public static void UseParams2(params object[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }

        static void Main()
        {
            // You can send a comma-separated list of arguments of the
            // specified type.
            UseParams(1, 2, 3, 4);
            UseParams2(1, 'a', "test");

            // A params parameter accepts zero or more arguments.
            // The following calling statement displays only a blank line.
            UseParams2();

            // An array argument can be passed, as long as the array
            // type matches the parameter type of the method being called.
            int[] myIntArray = { 5, 6, 7, 8, 9 };
            UseParams(myIntArray);

            object[] myObjArray = { 2, 'b', "test", "again" };
            UseParams2(myObjArray);

            // The following call causes a compiler error because the object
            // array cannot be converted into an integer array.
            //UseParams(myObjArray);

            // The following call does not cause an error, but the entire
            // integer array becomes the first element of the params array.
            UseParams2(myIntArray);
        }
    }
    /*
    Output:
        1 2 3 4
        1 a test

        5 6 7 8 9
        2 b test again
        System.Int32[]
    */
//</snippet5>

    //<snippet6>
    class RefExample
    {
        static void Method(ref int i)
        {
            // Rest the mouse pointer over i to verify that it is an int.
            // The following statement would cause a compiler error if i
            // were boxed as an object.
            i = i + 44;
        }

        static void Main()
        {
            int val = 1;
            Method(ref val);
            Console.WriteLine(val);

            // Output: 45
        }
    }

    //</snippet6>

    //<snippet7>
    class RefOverloadExample
    {
        public void SampleMethod(int i) { }
        public void SampleMethod(ref int i) { }
    }

    //</snippet7>

    //<snippet8>
    class RefExample2
    {
        static void ChangeByReference(ref Product itemRef)
        {
            // The following line changes the address that is stored in
            // parameter itemRef. Because itemRef is a ref parameter, the
            // address that is stored in variable item in Main also is changed.
            itemRef = new Product("Stapler", 99999);

            // You can change the value of one of the properties of
            // itemRef. The change happens to item in Main as well.
            itemRef.ItemID = 12345;
        }

        static void Main()
        {
            // Declare an instance of Product and display its initial values.
            Product item = new Product("Fasteners", 54321);
            System.Console.WriteLine("Original values in Main.  Name: {0}, ID: {1}\n",
                item.ItemName, item.ItemID);

            // Send item to ChangeByReference as a ref argument.
            ChangeByReference(ref item);
            System.Console.WriteLine("Back in Main.  Name: {0}, ID: {1}\n",
                item.ItemName, item.ItemID);
        }
    }

    class Product
    {
        public Product(string name, int newID)
        {
            ItemName = name;
            ItemID = newID;
        }

        public string ItemName { get; set; }
        public int ItemID { get; set; }
    }

    // Output:
    //Original values in Main.  Name: Fasteners, ID: 54321

    //Back in Main.  Name: Stapler, ID: 12345
    //</snippet8>
}