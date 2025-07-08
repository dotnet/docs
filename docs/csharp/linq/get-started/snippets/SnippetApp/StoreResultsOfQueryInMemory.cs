namespace LinqSamples;

public static class StoreResultsOfQueryInMemory
{
    public static void StoreResultsOfQueryInMemory1()
    {
        // <store_results_of_query_in_memory_1>
        List<int> numbers = [ 1, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 ];

        IEnumerable<int> queryFactorsOfFour = from num in numbers
                                              where num % 4 == 0
                                              select num;

        // Store the results in a new variable
        // without executing a foreach loop.
        var factorsofFourList = queryFactorsOfFour.ToList();

        // Read and write from the newly created list to demonstrate that it holds data.
        Console.WriteLine(factorsofFourList[2]);
        factorsofFourList[2] = 0;
        Console.WriteLine(factorsofFourList[2]);
        // </store_results_of_query_in_memory_1>
    }
}
