using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IterationKeywords
{ 


    //<snippet1>
    public class TestDoWhile 
    {
        public static void Main () 
        {
            int x = 0;
            do 
            {
                Console.WriteLine(x);
                x++;
            } while (x < 5);
        }
    }
    /*
        Output:
        0
        1
        2
        3
        4
    */
    //</snippet1>

    //<snippet2>
    
    class ForLoopTest 
    {
        static void Main() 
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
    /*
    Output:
    1
    2
    3
    4
    5
    */
    //</snippet2>

    class Test3
    {
        void InfiniteLoop()
        {
            //<snippet3>
            for (; ; )
            {
                // ...
            }
            //</snippet3>
        }
    }

    //<snippet4>
class ForEachTest
{
    static void Main(string[] args)
    {
        int[] fibarray = new int[] { 0, 1, 1, 2, 3, 5, 8, 13 };
        foreach (int element in fibarray)
        {
            System.Console.WriteLine(element);
        }
        System.Console.WriteLine();


        // Compare the previous loop to a similar for loop.
        for (int i = 0; i < fibarray.Length; i++)
        {
            System.Console.WriteLine(fibarray[i]);
        }
        System.Console.WriteLine();


        // You can maintain a count of the elements in the collection.
        int count = 0;
        foreach (int element in fibarray)
        {
            count += 1;
            System.Console.WriteLine("Element #{0}: {1}", count, element);
        }
        System.Console.WriteLine("Number of elements in the array: {0}", count);
    }
    // Output:
    // 0
    // 1
    // 1
    // 2
    // 3
    // 5
    // 8
    // 13

    // 0
    // 1
    // 1
    // 2
    // 3
    // 5
    // 8
    // 13

    // Element #1: 0
    // Element #2: 1
    // Element #3: 1
    // Element #4: 2
    // Element #5: 3
    // Element #6: 5
    // Element #7: 8
    // Element #8: 13
    // Number of elements in the array: 8
}
    //</snippet4>

    //<snippet5>
    
    class WhileTest 
    {
        static void Main() 
        {
            int n = 1;
            while (n < 6) 
            {
                Console.WriteLine("Current value of n is {0}", n);
                n++;
            }
        }
    }
    /*
        Output:
        Current value of n is 1
        Current value of n is 2
        Current value of n is 3
        Current value of n is 4
        Current value of n is 5
     */

        //</snippet5>

    //<snippet6>    
    class WhileTest2 
    {
        static void Main() 
        {
            int n = 1;
            while (n++ < 6) 
            {
                Console.WriteLine("Current value of n is {0}", n);
            }
        }
    }
    /*
    Output:
    Current value of n is 2
    Current value of n is 3
    Current value of n is 4
    Current value of n is 5
    Current value of n is 6
    */
     //</snippet6>

    //<snippet7>    
    class WhileTest3
    {
        static void Main() 
        {
            int n = 5;
            while (++n < 6) 
            {
                Console.WriteLine("Current value of n is {0}", n);
            }
        }
    }
    //</snippet7>

   
class ForLoopTest2
//<snippet8>
       static void Main()
        {
            int i;
            int j = 10;
            for (i = 0, Console.WriteLine("Start: {0}",i); i < j; i++, j--, Console.WriteLine("i={0}, j={1}", i, j))
            {
                // Body of the loop.
            }
        }
        // Output:
        // Start: 0
        // i=1, j=9
        // i=2, j=8
        // i=3, j=7
        // i=4, j=6
        // i=5, j=5
//</snippet8>
}

    









}