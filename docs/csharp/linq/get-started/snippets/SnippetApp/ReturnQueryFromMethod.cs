namespace LinqSamples;

public static class ReturnQueryFromMethod
{
    public static void ReturnQueryFromMethod1()
    {
        // <return_query_from_method_1>
        IEnumerable<string> QueryMethod1(int[] ints) =>
            from i in ints
            where i > 4
            select i.ToString();

        void QueryMethod2(int[] ints, out IEnumerable<string> returnQ) =>
            returnQ = from i in ints
                      where i < 4
                      select i.ToString();

        int[] nums = [ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 ];

        var myQuery1 = QueryMethod1(nums);
        // </return_query_from_method_1>

        Console.WriteLine("Results of executing myQuery1:");
        // <return_query_from_method_2>
        foreach (var s in myQuery1)
        {
            Console.WriteLine(s);
        }
        // </return_query_from_method_2>

        Console.WriteLine("\nResults of executing myQuery1 directly:");
        // <return_query_from_method_3>
        foreach (var s in QueryMethod1(nums))
        {
            Console.WriteLine(s);
        }
        // </return_query_from_method_3>

        Console.WriteLine("\nResults of executing myQuery2:");
        // <return_query_from_method_4>
        QueryMethod2(nums, out IEnumerable<string> myQuery2);

        // Execute the returned query.
        foreach (var s in myQuery2)
        {
            Console.WriteLine(s);
        }
        // </return_query_from_method_4>

        // <return_query_from_method_5>
        myQuery1 = from item in myQuery1
                   orderby item descending
                   select item;

        // Execute the modified query.
        Console.WriteLine("\nResults of executing modified myQuery1:");
        foreach (var s in myQuery1)
        {
            Console.WriteLine(s);
        }
        // </return_query_from_method_5>
    }
}
