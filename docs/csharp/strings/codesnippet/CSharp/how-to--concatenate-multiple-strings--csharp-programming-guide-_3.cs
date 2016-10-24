    class StringBuilderTest
    {
        static void Main()
        {
            string text = null;

            // Use StringBuilder for concatenation in tight loops.
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < 100; i++)
            {
                sb.AppendLine(i.ToString());
            }
            System.Console.WriteLine(sb.ToString());

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
    // Output:
    // 0
    // 1
    // 2
    // 3
    // 4
    // ...
    //