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