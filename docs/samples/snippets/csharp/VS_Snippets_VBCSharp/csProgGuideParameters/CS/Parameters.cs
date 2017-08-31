
using System;

namespace CsCsrefProgrammingParameters
{
    //-------------------------------------------------------------------------
    class WrapParameters
    {
        //<Snippet1>
        // Passing by value
        static void Square(int x)
        {
            // code...
        }
        //</Snippet1>

        //<Snippet2>
        // Passing by reference
        static void Square(ref int x)
        {
            // code...
        }
        //</Snippet2>
    }

    //-------------------------------------------------------------------------
    namespace WrapPassingVals
    {
        //<Snippet3>
        class PassingValByVal
        {
            static void SquareIt(int x)
            // The parameter x is passed by value.
            // Changes to x will not affect the original value of x.
            {
                x *= x;
                System.Console.WriteLine("The value inside the method: {0}", x);
            }
            static void Main()
            {
                int n = 5;
                System.Console.WriteLine("The value before calling the method: {0}", n);

                SquareIt(n);  // Passing the variable by value.
                System.Console.WriteLine("The value after calling the method: {0}", n);

                // Keep the console window open in debug mode.
                System.Console.WriteLine("Press any key to exit.");
                System.Console.ReadKey();
            }
        }
        /* Output:
            The value before calling the method: 5
            The value inside the method: 25
            The value after calling the method: 5
        */
        //</Snippet3>

        //<Snippet4>
        class PassingValByRef
        {
            static void SquareIt(ref int x)
            // The parameter x is passed by reference.
            // Changes to x will affect the original value of x.
            {
                x *= x;
                System.Console.WriteLine("The value inside the method: {0}", x);
            }
            static void Main()
            {
                int n = 5;
                System.Console.WriteLine("The value before calling the method: {0}", n);

                SquareIt(ref n);  // Passing the variable by reference.
                System.Console.WriteLine("The value after calling the method: {0}", n);

                // Keep the console window open in debug mode.
                System.Console.WriteLine("Press any key to exit.");
                System.Console.ReadKey();
            }
        }
        /* Output:
            The value before calling the method: 5
            The value inside the method: 25
            The value after calling the method: 25
        */
        //</Snippet4>

        class SwappingValTypes
        {
            //<Snippet5>
            static void SwapByRef(ref int x, ref int y)
            {
                int temp = x;
                x = y;
                y = temp;
            }
            //</Snippet5>


            //<Snippet6>
            static void Main()
            {
                int i = 2, j = 3;
                System.Console.WriteLine("i = {0}  j = {1}" , i, j);

                SwapByRef (ref i, ref j);

                System.Console.WriteLine("i = {0}  j = {1}" , i, j);

                // Keep the console window open in debug mode.
                System.Console.WriteLine("Press any key to exit.");
                System.Console.ReadKey();
            }
            /* Output:
                i = 2  j = 3
                i = 3  j = 2
            */
            //</Snippet6>
        }
    }

    //-------------------------------------------------------------------------
    namespace WrapPassingRefs
    {
        //<Snippet7>
        class PassingRefByVal 
        {
            static void Change(int[] pArray)
            {
                pArray[0] = 888;  // This change affects the original element.
                pArray = new int[5] {-3, -1, -2, -3, -4};   // This change is local.
                System.Console.WriteLine("Inside the method, the first element is: {0}", pArray[0]);
            }

            static void Main() 
            {
                int[] arr = {1, 4, 5};
                System.Console.WriteLine("Inside Main, before calling the method, the first element is: {0}", arr [0]);

                Change(arr);
                System.Console.WriteLine("Inside Main, after calling the method, the first element is: {0}", arr [0]);
            }
        }
        /* Output:
            Inside Main, before calling the method, the first element is: 1
            Inside the method, the first element is: -3
            Inside Main, after calling the method, the first element is: 888
        */
        //</Snippet7>

        //<Snippet8>
        class PassingRefByRef 
        {
            static void Change(ref int[] pArray)
            {
                // Both of the following changes will affect the original variables:
                pArray[0] = 888;
                pArray = new int[5] {-3, -1, -2, -3, -4};
                System.Console.WriteLine("Inside the method, the first element is: {0}", pArray[0]);
            }
                
            static void Main() 
            {
                int[] arr = {1, 4, 5};
                System.Console.WriteLine("Inside Main, before calling the method, the first element is: {0}", arr[0]);

                Change(ref arr);
                System.Console.WriteLine("Inside Main, after calling the method, the first element is: {0}", arr[0]);
            }
        }
        /* Output:
            Inside Main, before calling the method, the first element is: 1
            Inside the method, the first element is: -3
            Inside Main, after calling the method, the first element is: -3
        */
        //</Snippet8>

        //<Snippet9>
        class SwappingStrings
        {
            static void SwapStrings(ref string s1, ref string s2)
            // The string parameter is passed by reference.
            // Any changes on parameters will affect the original variables.
            {
                string temp = s1;
                s1 = s2;
                s2 = temp;
                System.Console.WriteLine("Inside the method: {0} {1}", s1, s2);
            }

            static void Main()
            {
                string str1 = "John";
                string str2 = "Smith";
                System.Console.WriteLine("Inside Main, before swapping: {0} {1}", str1, str2);

                SwapStrings(ref str1, ref str2);   // Passing strings by reference
                System.Console.WriteLine("Inside Main, after swapping: {0} {1}", str1, str2);
            }
        }
        /* Output:
            Inside Main, before swapping: John Smith
            Inside the method: Smith John
            Inside Main, after swapping: Smith John
       */
        //</Snippet9>
    }

    namespace PassByValueAndRef
    {
        //<Snippet10>
        class Program
        {
            static void Main(string[] args)
            {
                int arg;

                // Passing by value.
                // The value of arg in Main is not changed.
                arg = 4;
                squareVal(arg);
                Console.WriteLine(arg);
                // Output: 4

                // Passing by reference.
                // The value of arg in Main is changed.
                arg = 4;
                squareRef(ref arg);
                Console.WriteLine(arg);
                // Output: 16 
            }

            static void squareVal(int valParameter)
            {
                valParameter *= valParameter;
            }

            // Passing by reference
            static void squareRef(ref int refParameter)
            {
                refParameter *= refParameter;
            }
        }
        //</Snippet10>
    }


}
