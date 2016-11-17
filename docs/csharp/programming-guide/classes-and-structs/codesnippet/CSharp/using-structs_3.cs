    // Declare a struct object without "new."
    class TestCoOrdsNoNew
    {
        static void Main()
        {
            // Declare an object:
            CoOrds coords1;

            // Initialize:
            coords1.x = 10;
            coords1.y = 20;

            // Display results:
            Console.Write("CoOrds 1: ");
            Console.WriteLine("x = {0}, y = {1}", coords1.x, coords1.y);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    // Output: CoOrds 1: x = 10, y = 20