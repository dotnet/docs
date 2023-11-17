namespace LinqSamples;

public static class Index
{
    public static void Intro()
    {
        // <intro>
        // Specify the data source.
        int[] scores = [ 97, 92, 81, 60 ];

        // Define the query expression.
        IEnumerable<int> scoreQuery =
            from score in scores
            where score > 80
            select score;

        // Execute the query.
        foreach (int i in scoreQuery)
        {
            Console.Write(i + " ");
        }

        // Output: 97 92 81
        // </intro>
    }
}
