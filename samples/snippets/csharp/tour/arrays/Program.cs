namespace ArraySample
{
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

    class SampleCode
    {
        static void ExampleOne()
        {
            int[] a1 = new int[10];
            int[,] a2 = new int[10, 5];
            int[,,] a3 = new int[10, 5, 2];
        }

        static void ExampleTwo()
        {
            int[][] a = new int[3][];
            a[0] = new int[10];
            a[1] = new int[5];
            a[2] = new int[20];
        }

        static void ExampleThree()
        {
            int[] a = new int[] {1, 2, 3};
        }

        static void ExampleFour()
        {
            int[] a = {1, 2, 3};
        }     

        static void ExampleFive()
        {
            int[] t = new int[3];
            t[0] = 1;
            t[1] = 2;
            t[2] = 3;
            int[] a = t;
        }
    }
}
