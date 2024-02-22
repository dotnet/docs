namespace Keywords;

internal class ParameterModifiers
{
    internal static void ParamPassingExamples()
    {
        // <ParameterPassingExamples>

        // Passing a variable by value means passing a copy of the variable.
        // n1 is a value type
        int n1 = 5;
        System.Console.WriteLine("The value before calling the method: {0}", n1);

        SquareItValue(n1);  // Passing the variable by value.
        System.Console.WriteLine("The value after calling the method: {0}", n1);

        static void SquareItValue(int x)
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

        // arr1 is a reference type
        int[] arr1 = { 1, 4, 5 };
        System.Console.WriteLine("Before calling the method, the first element is: {0}", arr1[0]);

        ChangeValue(arr1);
        System.Console.WriteLine("After calling the method, the first element is: {0}", arr1[0]);

        static void ChangeValue(int[] pArray)
        {
            pArray[0] = 888;  // This change affects the original element.
            pArray = new int[5] { -3, -1, -2, -3, -4 };   // This change is local.
            System.Console.WriteLine("Inside the method, the first element is: {0}", pArray[0]);
        }
        /* Output:
            Before calling the method, the first element is: 1
            Inside the method, the first element is: -3
            After calling the method, the first element is: 888
        */

        // Passing a value by reference means passing a reference to the variable.
        // n is a value type
        int n2 = 5;
        System.Console.WriteLine("The value before calling the method: {0}", n2);

        SquareItReference(ref n2);  // Passing the variable by reference.
        System.Console.WriteLine("The value after calling the method: {0}", n2);

        static void SquareItReference(ref int x)
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

        // arr2 is a reference type
        int[] arr2 = { 1, 4, 5 };
        System.Console.WriteLine("Before calling the method, the first element is: {0}", arr2[0]);

        ChangeItReference(ref arr2);
        System.Console.WriteLine("After calling the method, the first element is: {0}", arr2[0]);

        static void ChangeItReference(ref int[] pArray)
        {
            // Both of the following changes will affect the original variables:
            pArray[0] = 888;
            pArray = new int[5] { -3, -1, -2, -3, -4 };
            System.Console.WriteLine("Inside the method, the first element is: {0}", pArray[0]);
        }
        /* Output:
            Before calling the method, the first element is: 1
            Inside the method, the first element is: -3
            After calling the method, the first element is: -3        */
        // </ParameterPassingExamples>
    }
}
