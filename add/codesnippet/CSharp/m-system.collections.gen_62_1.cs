    static void Main()
    {
        HashSet<int> Numbers = new HashSet<int>();

        for (int i = 0; i < 10; i++)
        {
            Numbers.Add(i);
        }

        Console.Write("Numbers contains {0} elements: ", Numbers.Count);
        DisplaySet(Numbers);

        Numbers.Clear();
        Numbers.TrimExcess();

        Console.Write("Numbers contains {0} elements: ", Numbers.Count);
        DisplaySet(Numbers);

    }
    /* This example produces output similar to the following:
     * Numbers contains 10 elements: { 0 1 2 3 4 5 6 7 8 9 }
     * Numbers contains 0 elements: { }
     */