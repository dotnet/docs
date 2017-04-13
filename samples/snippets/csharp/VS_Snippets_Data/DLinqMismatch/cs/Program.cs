using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace cs_mismatch
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        void method2()
        {
            // <Snippet2>
            Nullable<int> i = null;
            Nullable<int> j = null;
            if (i == j)
            {
                // This branch is executed.
            }
            // </Snippet2>

        }

        void method3()
        {
            int i = 0;
            int j = 0;

            // <Snippet3>
            if ((i == j) || (i != j)) // Redundant condition.
            {
                // ...
            }
            // </Snippet3>
        }

        void method5()
        {
            // <Snippet5>
            // C# overflow in absence of explicit checks.
            int i = Int32.MaxValue;
            int j = 5;
            if (i+j < 0) Console.WriteLine("Overflow!");
            // This code prints the overflow message.
            // </Snippet5>
        }

        void method6()
        {
            // <Snippet6>
            // C# equivalent on collections of Strings in place of nvarchars.
            String[] strings = { "food", "FOOD" };
            foreach (String s in strings)
            {
                if (s == "food")
                {
                    Console.WriteLine(s);
                }
            }
            // Only "food" is returned.
            // </Snippet6>

        }

        void method7()
        {
            // <Snippet7>
            // Assume Like(String, String) method.
            string s = ""; // map to T4.Col1
            if (System.Data.Linq.SqlClient.SqlMethods.Like(s, "%1"))
            {
                Console.WriteLine(s);
            }
            // Expected to return true for both "21" and "1021"
            // </Snippet7>

        }


    }
    // <Snippet1>
    class C1
    {
        int x;        // Map to T1.Col1.
        int y;        // Map to T1.Col2.
    }
    // </Snippet1>

    // <Snippet4>
    class C
    {
    string s1;       // Map to T2.Col1.
    string s2;       // Map to T2.Col2.

        void Compare()
        {
            if (s1 == s2) // This is correct.
            {
                // ...
            }
        }
    }
    // </Snippet4>
    


}


namespace ns
{
    // <Snippet8>
    class C
    {
        int x;        // Map to T5.Col1.
        int y;        // Map to T5.Col2.

        void Casting()
        {
            // Intended predicate.
            if (x + y > 4)
            {
                // valid for the data above
            }
        }
    }
    // </Snippet8>

}

namespace ns3
{
    // <Snippet9>
    class C5
    {
        string s;        // Map to T5.Col1.
    }
    // </Snippet9>

}