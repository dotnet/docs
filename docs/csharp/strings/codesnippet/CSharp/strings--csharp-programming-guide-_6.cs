    class FormatString
    {
        static void Main()
        {
            // Get user input.
            System.Console.WriteLine("Enter a number");
            string input = System.Console.ReadLine();

            // Convert the input string to an int.
            int j;
            System.Int32.TryParse(input, out j);

            // Write a different string each iteration.
            string s;
            for (int i = 0; i < 10; i++)
            {
                // A simple format string with no alignment formatting.
                s = System.String.Format("{0} times {1} = {2}", i, j, (i * j));
                System.Console.WriteLine(s);
            }

            //Keep the console window open in debug mode.
            System.Console.ReadKey();
        }
    }