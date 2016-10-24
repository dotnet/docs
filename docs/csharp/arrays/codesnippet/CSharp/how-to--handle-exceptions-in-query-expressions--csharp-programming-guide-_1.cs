    class ExceptionsOutsideQuery
    {
        static void Main()
        {
            // DO THIS with a datasource that might
            // throw an exception. It is easier to deal with
            // outside of the query expression.
            IEnumerable<int> dataSource;
            try
            {
                dataSource = GetData();
            }
            catch (InvalidOperationException)
            {
                // Handle (or don't handle) the exception 
                // in the way that is appropriate for your application.
                Console.WriteLine("Invalid operation");
                goto Exit;
            }
            
            // If we get here, it is safe to proceed.
            var query = from i in dataSource
                        select i * i;

            foreach (var i in query)
                Console.WriteLine(i.ToString());

            //Keep the console window open in debug mode
            Exit:
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        // A data source that is very likely to throw an exception!
        static IEnumerable<int> GetData()
        {
            throw new InvalidOperationException();
        }
    }