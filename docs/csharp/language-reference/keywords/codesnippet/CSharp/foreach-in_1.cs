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