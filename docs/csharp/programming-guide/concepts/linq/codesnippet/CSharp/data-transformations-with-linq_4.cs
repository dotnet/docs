    class FormatQuery
    {
        static void Main()
        {            
            // Data source.
            double[] radii = { 1, 2, 3 };

            // Query.
            IEnumerable<string> query =
                from rad in radii
                select $"Area = {rad * rad * Math.PI:F2}";

            // Query execution. 
            foreach (string s in query)
                Console.WriteLine(s);

            // Keep the console open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    /* Output:
        Area = 3.14
        Area = 12.57
        Area = 28.27
    */