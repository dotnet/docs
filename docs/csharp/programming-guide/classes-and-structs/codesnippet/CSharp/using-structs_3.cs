    // Declare a struct object without "new."
    class TestCoordsNoNew
    {
        static void Main()
        {
            // Declare an object:
            Coords coords1;

            // Initialize:
            coords1.x = 10;
            coords1.y = 20;

            // Display results:
            Console.Write("Coords 1: ");
            Console.WriteLine("x = {0}, y = {1}", coords1.x, coords1.y);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    // Output: Coords 1: x = 10, y = 20