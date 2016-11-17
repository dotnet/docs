        static void Main(string[] args)
        {
            // To run this program, provide a command line string.
            // In Visual Studio, see Project > Properties > Debug.
            string userName = args[0];
            string date = DateTime.Today.ToShortDateString();

            // Use the + and += operators for one-time concatenations.
            string str = "Hello " + userName + ". Today is " + date + ".";
            System.Console.WriteLine(str);

            str += " How are you today?";
            System.Console.WriteLine(str);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        // Example output: 
        //  Hello Alexander. Today is 1/22/2008.
        //  Hello Alexander. Today is 1/22/2008. How are you today?
        //  Press any key to exit.
        //