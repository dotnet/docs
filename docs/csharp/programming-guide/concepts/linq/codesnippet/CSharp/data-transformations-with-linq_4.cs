    class FormatQuery
    {
        static void Main()
        {            
            // Data source.
            double[] radii = { 1, 2, 3 };

            // Query.
            IEnumerable<string> query =
                from rad in radii
                select String.Format("Area = {0}", (rad * rad) * 3.14);

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
        Area = 12.56
        Area = 28.26
    */