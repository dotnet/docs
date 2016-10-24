    // Declare and initialize struct objects.
    class TestCoOrds
    {
        static void Main()
        {
            // Initialize:   
            CoOrds coords1 = new CoOrds();
            CoOrds coords2 = new CoOrds(10, 10);

            // Display results:
            Console.Write("CoOrds 1: ");
            Console.WriteLine("x = {0}, y = {1}", coords1.x, coords1.y);

            Console.Write("CoOrds 2: ");
            Console.WriteLine("x = {0}, y = {1}", coords2.x, coords2.y);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    /* Output:
        CoOrds 1: x = 0, y = 0
        CoOrds 2: x = 10, y = 10
    */