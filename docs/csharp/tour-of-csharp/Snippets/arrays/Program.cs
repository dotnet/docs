namespace ArraySample
{
    // <ArraysSample>
    using System;
    class ArrayExample
    {
        static void Main()
        {
            int[] a = new int[10];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = i * i;
            }
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine($"a[{i}] = {a[i]}");
            }
        }
    }
    // </ArraysSample>

    class SampleCode
    {
        static void ExampleOne()
        {
            // <DeclareArrays>
            int[] a1 = new int[10];
            int[,] a2 = new int[10, 5];
            int[,,] a3 = new int[10, 5, 2];
            // </DeclareArrays>
        }

        static void ExampleTwo()
        {
            // <ArrayOfArrays>
            int[][] a = new int[3][];
            a[0] = new int[10];
            a[1] = new int[5];
            a[2] = new int[20];
            // </ArrayOfArrays>
        }

        static void ExampleThree()
        {
            // <SnippetInitialize>
            int[] a = new int[] {1, 2, 3};
            // </SnippetInitialize>
        }

        static void ExampleFour()
        {
            // <InitializeShortened>
            int[] a = {1, 2, 3};
            // </InitializeShortened>
        }

        static void ExampleFive()
        {
            // <InitializeGenerated>
            int[] t = new int[3];
            t[0] = 1;
            t[1] = 2;
            t[2] = 3;
            int[] a = t;
            // </InitializeGenerated>

            // <EnumerateArray>
            foreach(int item in a)
            {
                Console.WriteLine(item);
            }
            // </EnumerateArray>
        }
    }
}
