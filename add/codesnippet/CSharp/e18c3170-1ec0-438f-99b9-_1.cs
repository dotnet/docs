class FromToAnyDemo
{

    // Demonstrates:
    //      Bounded BlockingCollection<T>
    //      BlockingCollection<T>.TryAddToAny()
    //      BlockingCollection<T>.TryTakeFromAny()
    public static void BC_FromToAny()
    {
        BlockingCollection<int>[] bcs = new BlockingCollection<int>[2];
        bcs[0] = new BlockingCollection<int>(5); // collection bounded to 5 items
        bcs[1] = new BlockingCollection<int>(5); // collection bounded to 5 items

        // Should be able to add 10 items w/o blocking
        int numFailures = 0;
        for (int i = 0; i < 10; i++)
        {
            if (BlockingCollection<int>.TryAddToAny(bcs, i) == -1) numFailures++;
        }
        Console.WriteLine("TryAddToAny: {0} failures (should be 0)", numFailures);

        // Should be able to retrieve 10 items
        int numItems = 0;
        int item;
        while (BlockingCollection<int>.TryTakeFromAny(bcs, out item) != -1) numItems++;
        Console.WriteLine("TryTakeFromAny: retrieved {0} items (should be 10)", numItems);
    }
}