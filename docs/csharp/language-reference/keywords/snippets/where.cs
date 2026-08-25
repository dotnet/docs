namespace Where;

//<snippet5>
class WhereSample
{
    static void Main()
    {
        // Simple data source. Arrays support IEnumerable<T>.
        int[] numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];

        // Simple query with one predicate in where clause.
        var queryLowNums =
            from num in numbers
            where num < 5
            select num;

        // Execute the query.
        foreach (var s in queryLowNums)
        {
            Console.Write(s.ToString() + " ");
        }
    }
}
//Output: 4 1 3 2 0
//</snippet5>

//<snippet6>
class WhereSample2
{
static void Main()
{
    // Data source.
    int[] numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];

    // Create the query with two predicates in where clause.
    var queryLowNums2 =
        from num in numbers
        where num < 5 && num % 2 == 0
        select num;

    // Execute the query
    foreach (var s in queryLowNums2)
    {
        Console.Write(s.ToString() + " ");
    }
    Console.WriteLine();

    // Create the query with two where clause.
    var queryLowNums3 =
        from num in numbers
        where num < 5
        where num % 2 == 0
        select num;

    // Execute the query
    foreach (var s in queryLowNums3)
    {
        Console.Write(s.ToString() + " ");
    }
}
}
// Output:
// 4 2 0
// 4 2 0
//</snippet6>

//<snippet7>
class WhereSample3
{
    static void Main()
    {
        // Data source
        int[] numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];

        // Create the query with a method call in the where clause.
        // Note: This won't work in LINQ to SQL unless you have a
        // stored procedure that is mapped to a method by this name.
        var queryEvenNums =
            from num in numbers
            where IsEven(num)
            select num;

         // Execute the query.
        foreach (var s in queryEvenNums)
        {
            Console.Write(s.ToString() + " ");
        }
    }

    // Method may be instance method or static method.
    static bool IsEven(int i) => i % 2 == 0;
}
//Output: 4 8 6 2 0
//</snippet7>
