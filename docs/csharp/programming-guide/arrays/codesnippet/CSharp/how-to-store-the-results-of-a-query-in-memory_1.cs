    class StoreQueryResults
    {
        static List<int> numbers = new List<int>() { 1, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
        static void Main()
        {

            IEnumerable<int> queryFactorsOfFour =
                from num in numbers
                where num % 4 == 0
                select num;

            // Store the results in a new variable
            // without executing a foreach loop.
            List<int> factorsofFourList = queryFactorsOfFour.ToList();

            // Iterate the list just to prove it holds data.
            foreach (int n in factorsofFourList)
            {
                Console.WriteLine(n);
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }
    }