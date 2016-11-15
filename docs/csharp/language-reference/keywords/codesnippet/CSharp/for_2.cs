       static void Main()
        {
            int i;
            int j = 10;
            for (i = 0, Console.WriteLine("Start: {0}",i); i < j; i++, j--, Console.WriteLine("i={0}, j={1}", i, j))
            {
                // Body of the loop.
            }
        }
        // Output:
        // Start: 0
        // i=1, j=9
        // i=2, j=8
        // i=3, j=7
        // i=4, j=6
        // i=5, j=5