
using System.Linq;

//<Snippet38>
class TestRef
{
    static void FillArray(ref int[] arr)
    {
        // Create the array on demand:
        if (arr == null)
        {
            arr = new int[10];
        }
        // Fill the array:
        arr[0] = 1111;
        arr[4] = 5555;
    }

    static void Main()
    {
        // Initialize the array:
        int[] theArray = { 1, 2, 3, 4, 5 };

        // Pass the array using ref:
        FillArray(ref theArray);

        // Display the updated array:
        System.Console.WriteLine("Array elements are:");
        for (int i = 0; i < theArray.Length; i++)
        {
            System.Console.Write(theArray[i] + " ");
        }

        // Keep the console window open in debug mode.
        System.Console.WriteLine("Press any key to exit.");
        System.Console.ReadKey();
    }
}
    /* Output:
        Array elements are:
        1111 2 3 4 5555
    */
//</Snippet38>


//<Snippet37>
class TestOut
{
    static void FillArray(out int[] arr)
    {
        // Initialize the array:
        arr = new int[5] { 1, 2, 3, 4, 5 };
    }

    static void Main()
    {
        int[] theArray; // Initialization is not required

        // Pass the array to the callee using out:
        FillArray(out theArray);

        // Display the array elements:
        System.Console.WriteLine("Array elements are:");
        for (int i = 0; i < theArray.Length; i++)
        {
            System.Console.Write(theArray[i] + " ");
        }

        // Keep the console window open in debug mode.
        System.Console.WriteLine("Press any key to exit.");
        System.Console.ReadKey();
    }
}
    /* Output:
        Array elements are:
        1 2 3 4 5        
    */
//</Snippet37>


//<Snippet30>
class ArrayClass
{
    static void PrintArray(string[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            System.Console.Write(arr[i] + "{0}", i < arr.Length - 1 ? " " : "");
        }
        System.Console.WriteLine();
    }

    static void ChangeArray(string[] arr)
    {
        // The following attempt to reverse the array does not persist when
        // the method returns, because arr is a value parameter.
        arr = (arr.Reverse()).ToArray();
        // The following statement displays Sat as the first element in the array.
        System.Console.WriteLine("arr[0] is {0} in ChangeArray.", arr[0]);
    }

    static void ChangeArrayElements(string[] arr)
    {
        // The following assignments change the value of individual array 
        // elements. 
        arr[0] = "Sat";
        arr[1] = "Fri";
        arr[2] = "Thu";
        // The following statement again displays Sat as the first element
        // in the array arr, inside the called method.
        System.Console.WriteLine("arr[0] is {0} in ChangeArrayElements.", arr[0]);
    }

    static void Main()
    {
        // Declare and initialize an array.
        //<Snippet7>
        string[] weekDays = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
        //</Snippet7>

        // Pass the array as an argument to PrintArray.
        PrintArray(weekDays);

        // ChangeArray tries to change the array by assigning something new
        // to the array in the method. 
        ChangeArray(weekDays);

        // Print the array again, to verify that it has not been changed.
        System.Console.WriteLine("Array weekDays after the call to ChangeArray:");
        PrintArray(weekDays);
        System.Console.WriteLine();

        // ChangeArrayElements assigns new values to individual array
        // elements.
        ChangeArrayElements(weekDays);

        // The changes to individual elements persist after the method returns.
        // Print the array, to verify that it has been changed.
        System.Console.WriteLine("Array weekDays after the call to ChangeArrayElements:");
        PrintArray(weekDays);
    }
}
// Output: 
// Sun Mon Tue Wed Thu Fri Sat
// arr[0] is Sat in ChangeArray.
// Array weekDays after the call to ChangeArray:
// Sun Mon Tue Wed Thu Fri Sat
// 
// arr[0] is Sat in ChangeArrayElements.
// Array weekDays after the call to ChangeArrayElements:
// Sat Fri Thu Wed Thu Fri Sat
//</Snippet30>


class TestPrintArray1D
{
    int[] theArray = new int[] { 1, 3, 5, 7, 9 };

    //<Snippet33>
    void PrintArray(int[] arr)
    {
        // Method code.
    }
    //</Snippet33>

    void Test()
    {
        //<Snippet34>
        int[] theArray = { 1, 3, 5, 7, 9 };
        PrintArray(theArray);
        //</Snippet34>

        //<Snippet35>
        PrintArray(new int[] { 1, 3, 5, 7, 9 });
        //</Snippet35>
    }
}


class TestPrintArray2D
{
    int[,] theArray =  { { 1, 2 }, { 2, 3 }, { 3, 4 } };

    //<Snippet36>
    void Print2DArray(int[,] arr)
    {
        // Method code.
    }
    //</Snippet36>

    void Test()
    {
        //<Snippet41>
        int[,] theArray = { { 1, 2 }, { 2, 3 }, { 3, 4 } };
        Print2DArray(theArray);
        //</Snippet41>
    }
}


//<Snippet31>
class ArrayClass2D
{
    static void Print2DArray(int[,] arr)
    {
        // Display the array elements.
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                System.Console.WriteLine("Element({0},{1})={2}", i, j, arr[i, j]);
            }
        }
    }
    static void Main()
    {
        // Pass the array as an argument.
        //<Snippet32>
        Print2DArray(new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } });
        //</Snippet32>

        // Keep the console window open in debug mode.
        System.Console.WriteLine("Press any key to exit.");
        System.Console.ReadKey();
    }
}
    /* Output:
        Element(0,0)=1
        Element(0,1)=2
        Element(1,0)=3
        Element(1,1)=4
        Element(2,0)=5
        Element(2,1)=6
        Element(3,0)=7
        Element(3,1)=8
    */
//</Snippet31>


class Test3
{
    static void Main()
    {
        //<Snippet28>
        int[] numbers = { 4, 5, 6, 1, 2, 3, -2, -1, 0 };
        foreach (int i in numbers)
        {
            System.Console.Write("{0} ", i);
        }
        // Output: 4 5 6 1 2 3 -2 -1 0
         //</Snippet28>

        System.Console.WriteLine();

        //<Snippet29>
        int[,] numbers2D = new int[3, 2] { { 9, 99 }, { 3, 33 }, { 5, 55 } };
        // Or use the short form:
        // int[,] numbers2D = { { 9, 99 }, { 3, 33 }, { 5, 55 } };

        foreach (int i in numbers2D)
        {
            System.Console.Write("{0} ", i);
        }
        // Output: 9 99 3 33 5 55
        //</Snippet29>
    }

    //<Snippet39>
    static void TestMethod1(out int[] arr)
    {
        arr = new int[10];   // definite assignment of arr
    }
    //</Snippet39>

    //<Snippet40>
    static void TestMethod2(ref int[] arr)
    {
        arr = new int[10];   // arr initialized to a different array
    }
    //</Snippet40>
}


class Test1
{
    void test()
    {
        //<Snippet3>
        int[] numbers = { 1, 2, 3, 4, 5 };
        int lengthOfNumbers = numbers.Length;
        //</Snippet3>

        //<Snippet4>
        int[] array = new int[5];
        //</Snippet4>

        //<Snippet5>
        string[] stringArray = new string[6];
        //</Snippet5>

        // Declare and set array element values
        //<Snippet6>
        int[] array1 = new int[] { 1, 3, 5, 7, 9 };
        //</Snippet6>

        //<Snippet8>
        int[] array2 = { 1, 3, 5, 7, 9 };
        string[] weekDays2 = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
        //</Snippet8>

        //<Snippet9>
        int[] array3;
        array3 = new int[] { 1, 3, 5, 7, 9 };   // OK
        //array3 = {1, 3, 5, 7, 9};   // Error
        //</Snippet9>

        //<Snippet10>
        SomeType[] array4 = new SomeType[10];
        //</Snippet10>
    }
}


class SomeType
{
}


class Test2
{
    void test()
    {
        //<Snippet11>
        int[,] array = new int[4, 2];
        //</Snippet11>

        //<Snippet12>
        int[, ,] array1 = new int[4, 2, 3];
        //</Snippet12>

        //<Snippet13>
        // Two-dimensional array.
        int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
        // The same array with dimensions specified.
        int[,] array2Da = new int[4, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
        // A similar array with string elements.
        string[,] array2Db = new string[3, 2] { { "one", "two" }, { "three", "four" },
                                                { "five", "six" } };

        // Three-dimensional array.
        int[, ,] array3D = new int[,,] { { { 1, 2, 3 }, { 4, 5, 6 } }, 
                                         { { 7, 8, 9 }, { 10, 11, 12 } } };
        // The same array with dimensions specified.
        int[, ,] array3Da = new int[2, 2, 3] { { { 1, 2, 3 }, { 4, 5, 6 } }, 
                                               { { 7, 8, 9 }, { 10, 11, 12 } } };

        // Accessing array elements.
        System.Console.WriteLine(array2D[0, 0]);
        System.Console.WriteLine(array2D[0, 1]);
        System.Console.WriteLine(array2D[1, 0]);
        System.Console.WriteLine(array2D[1, 1]);
        System.Console.WriteLine(array2D[3, 0]);
        System.Console.WriteLine(array2Db[1, 0]);
        System.Console.WriteLine(array3Da[1, 0, 1]);
        System.Console.WriteLine(array3D[1, 1, 2]);

        // Getting the total count of elements or the length of a given dimension.
        var allLength = array3D.Length;
        var total = 1;
        for (int i = 0; i < array3D.Rank; i++) {
            total *= array3D.GetLength(i);
        }
        System.Console.WriteLine("{0} equals {1}", allLength, total);

        // Output:
        // 1
        // 2
        // 3
        // 4
        // 7
        // three
        // 8
        // 12
        // 12 equals 12
        //</Snippet13>

        //<Snippet14>
        int[,] array4 = { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
        //</Snippet14>

        //<Snippet15>
        int[,] array5;
        array5 = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };   // OK
        //array5 = {{1,2}, {3,4}, {5,6}, {7,8}};   // Error
        //</Snippet15>

        //<Snippet16>
        array5[2, 1] = 25;
        //</Snippet16>

        //<Snippet42>
        int elementValue = array5[2, 1];
        //</Snippet42>
        //Console.WriteLine(elementValue);

        //<Snippet17>
        int[,] array6 = new int[10, 10];
        //</Snippet17>
    }
}


//<Snippet1>
class TestArraysClass
{
    static void Main()
    {
        // Declare a single-dimensional array 
        int[] array1 = new int[5];

        // Declare and set array element values
        int[] array2 = new int[] { 1, 3, 5, 7, 9 };

        // Alternative syntax
        int[] array3 = { 1, 2, 3, 4, 5, 6 };

        // Declare a two dimensional array
        int[,] multiDimensionalArray1 = new int[2, 3];

        // Declare and set array element values
        int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };

        // Declare a jagged array
        int[][] jaggedArray = new int[6][];

        // Set the values of the first array in the jagged array structure
        jaggedArray[0] = new int[4] { 1, 2, 3, 4 };
    }
}
//</Snippet1>


namespace WrapTestArraysClass
{
    //<Snippet2>
    class TestArraysClass
    {
        static void Main()
        {
            // Declare and initialize an array:
            int[,] theArray = new int[5, 10];
            System.Console.WriteLine("The array has {0} dimensions.", theArray.Rank);
        }
    }
    // Output: The array has 2 dimensions.
    //</Snippet2>
}


//<Snippet18>
class ArrayTest
{
    static void Main()
    {
        // Declare the array of two elements:
        int[][] arr = new int[2][];

        // Initialize the elements:
        arr[0] = new int[5] { 1, 3, 5, 7, 9 };
        arr[1] = new int[4] { 2, 4, 6, 8 };

        // Display the array elements:
        for (int i = 0; i < arr.Length; i++)
        {
            System.Console.Write("Element({0}): ", i);

            for (int j = 0; j < arr[i].Length; j++)
            {
                System.Console.Write("{0}{1}", arr[i][j], j == (arr[i].Length - 1) ? "" : " ");
            }
            System.Console.WriteLine();            
        }
        // Keep the console window open in debug mode.
        System.Console.WriteLine("Press any key to exit.");
        System.Console.ReadKey();
    }
}
/* Output:
    Element(0): 1 3 5 7 9
    Element(1): 2 4 6 8
*/
//</Snippet18>


class TestJagged
{
    void test()
    {
        //<Snippet19>
        int[][] jaggedArray = new int[3][];
        //</Snippet19>

        //<Snippet20>
        jaggedArray[0] = new int[5];
        jaggedArray[1] = new int[4];
        jaggedArray[2] = new int[2];
        //</Snippet20>

        //<Snippet21>
        jaggedArray[0] = new int[] { 1, 3, 5, 7, 9 };
        jaggedArray[1] = new int[] { 0, 2, 4, 6 };
        jaggedArray[2] = new int[] { 11, 22 };
        //</Snippet21>

        //<Snippet22>
        int[][] jaggedArray2 = new int[][] 
    {
        new int[] {1,3,5,7,9},
        new int[] {0,2,4,6},
        new int[] {11,22}
    };
        //</Snippet22>

        //<Snippet23>
        int[][] jaggedArray3 = 
    {
        new int[] {1,3,5,7,9},
        new int[] {0,2,4,6},
        new int[] {11,22}
    };
        //</Snippet23>

        //<Snippet24>
        // Assign 77 to the second element ([1]) of the first array ([0]):
        jaggedArray3[0][1] = 77;

        // Assign 88 to the second element ([1]) of the third array ([2]):
        jaggedArray3[2][1] = 88;
        //</Snippet24>

        //<Snippet25>
        int[][,] jaggedArray4 = new int[3][,] 
        {
            new int[,] { {1,3}, {5,7} },
            new int[,] { {0,2}, {4,6}, {8,10} },
            new int[,] { {11,22}, {99,88}, {0,9} } 
        };
        //</Snippet25>

        //<Snippet26>
        System.Console.Write("{0}", jaggedArray4[0][1, 0]);
        //</Snippet26>

        //<Snippet27>
        System.Console.WriteLine(jaggedArray4.Length);
        //</Snippet27>
    }
}