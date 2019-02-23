    // Declare and initialize struct objects.
    class TestCoords
    {
        static void Main()
        {
            // Initialize:   
            Coords coords1 = new Coords();
            Coords coords2 = new Coords(10, 10);

            // Display results:
            Console.Write("Coords 1: ");
            Console.WriteLine("x = {0}, y = {1}", coords1.x, coords1.y);

            Console.Write("Coords 2: ");
            Console.WriteLine("x = {0}, y = {1}", coords2.x, coords2.y);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    /* Output:
        Coords 1: x = 0, y = 0
        Coords 2: x = 10, y = 10
    */