    class QueryThatThrows
    {
        static void Main()
        {
            // Data source.
            string[] files = { "fileA.txt", "fileB.txt", "fileC.txt" };

            // Demonstration query that throws.
            var exceptionDemoQuery =
                from file in files
                let n = SomeMethodThatMightThrow(file)
                select n;

            // Runtime exceptions are thrown when query is executed.
            // Therefore they must be handled in the foreach loop.
            try
            {
                foreach (var item in exceptionDemoQuery)
                {
                    Console.WriteLine("Processing {0}", item);
                }
            }

            // Catch whatever exception you expect to raise
            // and/or do any necessary cleanup in a finally block
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            //Keep the console window open in debug mode
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        // Not very useful as a general purpose method.
        static string SomeMethodThatMightThrow(string s)
        {
            if (s[4] == 'C')
                throw new InvalidOperationException();
            return @"C:\newFolder\" + s;
        }
    }
    /* Output:
        Processing C:\newFolder\fileA.txt
        Processing C:\newFolder\fileB.txt
        Operation is not valid due to the current state of the object.
     */