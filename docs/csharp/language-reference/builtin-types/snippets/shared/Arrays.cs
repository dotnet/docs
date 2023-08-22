using System.Linq;

//<Snippet38>
class TestRef
{
    static void FillArray(ref int[] arr)
    {
        // Create the array on demand.
        arr ??= new int[10];
        // Fill the array.
        arr[0] = 1111;
        arr[4] = 5555;
    }

    static void Main()
    {
        // Initialize the array.
        int[] theArray = { 1, 2, 3, 4, 5 };

        // Pass the array using ref.
        FillArray(ref theArray);

        // Display the updated array.
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
        // Initialize the array.
        arr = new int[5] { 1, 2, 3, 4, 5 };
    }

    static void Main()
    {
        int[] theArray; // Initialization is not required

        // Pass the array to the callee using out.
        FillArray(out theArray);

        // Display the array elements.
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
    int[,] theArray = { { 1, 2 }, { 2, 3 }, { 3, 4 } };

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
        int[,,] array1 = new int[4, 2, 3];
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
        int[,,] array3D = new int[,,] { { { 1, 2, 3 }, { 4, 5, 6 } },
                                         { { 7, 8, 9 }, { 10, 11, 12 } } };
        // The same array with dimensions specified.
        int[,,] array3Da = new int[2, 2, 3] { { { 1, 2, 3 }, { 4, 5, 6 } },
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
        for (int i = 0; i < array3D.Rank; i++)
        {
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
        // Declare a single-dimensional array of 5 integers.
        int[] array1 = new int[5];

        // Declare and set array element values.
        int[] array2 = new int[] { 1, 3, 5, 7, 9 };

        // Alternative syntax.
        int[] array3 = { 1, 2, 3, 4, 5, 6 };

        // Declare a two dimensional array.
        int[,] multiDimensionalArray1 = new int[2, 3];

        // Declare and set array element values.
        int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };

        // Declare a jagged array.
        int[][] jaggedArray = new int[6][];

        // Set the values of the first array in the jagged array structure.
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
            // Declare and initialize an array.
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
        // Declare the array of two elements.
        int[][] arr = new int[2][];

        // Initialize the elements.
        arr[0] = new int[5] { 1, 3, 5, 7, 9 };
        arr[1] = new int[4] { 2, 4, 6, 8 };

        // Display the array elements.
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
        new int[] { 1, 3, 5, 7, 9 },
        new int[] { 0, 2, 4, 6 },
        new int[] { 11, 22 }
        };
        //</Snippet22>

        //<Snippet23>
        int[][] jaggedArray3 =
        {
            new int[] { 1, 3, 5, 7, 9 },
            new int[] { 0, 2, 4, 6 },
            new int[] { 11, 22 }
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

namespace FromLINQ
{
    // Implicitly Typed Arrays example 1
    //<snippetLINQ37>
    class ImplicitlyTypedArraySample
    {
        static void Main()
        {
            var a = new[] { 1, 10, 100, 1000 }; // int[]

            // Accessing array
            Console.WriteLine("First element: " + a[0]);
            Console.WriteLine("Second element: " + a[1]);
            Console.WriteLine("Third element: " + a[2]);
            Console.WriteLine("Fourth element: " + a[3]);
            /* Outputs
            First element: 1
            Second element: 10
            Third element: 100
            Fourth element: 1000
            */

            var b = new[] { "hello", null, "world" }; // string[]

            // Accessing elements of an array using 'string.Join' method
            Console.WriteLine(string.Join(" ", b));
            /* Output
            hello  world
            */

            // single-dimension jagged array
            var c = new[]
            {
                                            new[]{1,2,3,4},
                                            new[]{5,6,7,8}
                    };
            // Looping through the outer array
            for (int k = 0; k < c.Length; k++)
            {
                // Looping through each inner array
                for (int j = 0; j < c[k].Length; j++)
                {
                    // Accessing each element and printing it to the console
                    Console.WriteLine($"Element at c[{k}][{j}] is: {c[k][j]}");
                }
            }
            /* Outputs
            Element at c[0][0] is: 1
            Element at c[0][1] is: 2
            Element at c[0][2] is: 3
            Element at c[0][3] is: 4
            Element at c[1][0] is: 5
            Element at c[1][1] is: 6
            Element at c[1][2] is: 7
            Element at c[1][3] is: 8
            */

            // jagged array of strings
            var d = new[]
            {
                        new[]{"Luca", "Mads", "Luke", "Dinesh"},
                        new[]{"Karen", "Suma", "Frances"}
                    };

            // Looping through the outer array
            int i = 0;
            foreach (var subArray in d)
            {
                // Looping through each inner array
                int j = 0;
                foreach (var element in subArray)
                {
                    // Accessing each element and printing it to the console
                    Console.WriteLine($"Element at d[{i}][{j}] is: {element}");
                    j++;
                }
                i++;
            }
            /* Outputs
            Element at d[0][0] is: Luca
            Element at d[0][1] is: Mads
            Element at d[0][2] is: Luke
            Element at d[0][3] is: Dinesh
            Element at d[1][0] is: Karen
            Element at d[1][1] is: Suma
            Element at d[1][2] is: Frances
            */
        }
    }
    //</snippetLINQ37>

    public class ArrayInit
    {
        public static void Init()
        {
            //<snippetLINQ38>
            var contacts = new[]
            {
                new {
                    Name = " Eugene Zabokritski",
                    PhoneNumbers = new[] { "206-555-0108", "425-555-0001" }
                },
                new {
                    Name = " Hanying Feng",
                    PhoneNumbers = new[] { "650-555-0199" }
                }
            };
            //</snippetLINQ38>
        }
    }
}
