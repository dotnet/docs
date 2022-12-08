using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keywords;

internal class ParameterModifiers
{
    internal static void PassValueByValue()
    {
        // <SnippetPassValueByValue>
        int n = 5;
        System.Console.WriteLine("The value before calling the method: {0}", n);

        SquareIt(n);  // Passing the variable by value.
        System.Console.WriteLine("The value after calling the method: {0}", n);

        // Keep the console window open in debug mode.
        System.Console.WriteLine("Press any key to exit.");
        System.Console.ReadKey();

        static void SquareIt(int x)
        // The parameter x is passed by value.
        // Changes to x will not affect the original value of x.
        {
            x *= x;
            System.Console.WriteLine("The value inside the method: {0}", x);
        }
        /* Output:
            The value before calling the method: 5
            The value inside the method: 25
            The value after calling the method: 5
        */
        // </SnippetPassValueByValue>
    }

    internal static void PassingValueByReference()
    {
        // <SnippetPassValueByReference>
        int n = 5;
        System.Console.WriteLine("The value before calling the method: {0}", n);

        SquareIt(ref n);  // Passing the variable by reference.
        System.Console.WriteLine("The value after calling the method: {0}", n);

        // Keep the console window open in debug mode.
        System.Console.WriteLine("Press any key to exit.");
        System.Console.ReadKey();

        static void SquareIt(ref int x)
        // The parameter x is passed by reference.
        // Changes to x will affect the original value of x.
        {
            x *= x;
            System.Console.WriteLine("The value inside the method: {0}", x);
        }
        /* Output:
            The value before calling the method: 5
            The value inside the method: 25
            The value after calling the method: 25
        */
        // </SnippetPassValueByReference>
    }

    internal static void PassingReferenceByValue()
    {
        // <SnippetPassReferenceByValue>
        int[] arr = { 1, 4, 5 };
        System.Console.WriteLine("Inside Main, before calling the method, the first element is: {0}", arr[0]);

        Change(arr);
        System.Console.WriteLine("Inside Main, after calling the method, the first element is: {0}", arr[0]);

        static void Change(int[] pArray)
        {
            pArray[0] = 888;  // This change affects the original element.
            pArray = new int[5] { -3, -1, -2, -3, -4 };   // This change is local.
            System.Console.WriteLine("Inside the method, the first element is: {0}", pArray[0]);
        }
        /* Output:
            Inside Main, before calling the method, the first element is: 1
            Inside the method, the first element is: -3
            Inside Main, after calling the method, the first element is: 888
        */
        // </SnippetPassReferenceByValue>
    }

    internal static void PassingReferenceByReference()
    {
        // <SnippetPassReferenceByReference>
        int[] arr = { 1, 4, 5 };
        System.Console.WriteLine("Inside Main, before calling the method, the first element is: {0}", arr[0]);

        Change(ref arr);
        System.Console.WriteLine("Inside Main, after calling the method, the first element is: {0}", arr[0]);

        static void Change(ref int[] pArray)
        {
            // Both of the following changes will affect the original variables:
            pArray[0] = 888;
            pArray = new int[5] { -3, -1, -2, -3, -4 };
            System.Console.WriteLine("Inside the method, the first element is: {0}", pArray[0]);
        }
        /* Output:
            Inside Main, before calling the method, the first element is: 1
            Inside the method, the first element is: -3
            Inside Main, after calling the method, the first element is: -3
        */
        // </SnippetPassReferenceByReference>
    }
}
