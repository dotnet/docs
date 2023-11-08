namespace LinqSamples;

public class ReturnQueryFromMethod
{
    public static void ReturnQueryFromMethod1()
    {
        // <return_query_from_method_1>
        // QueryMethod1 returns a query as its value.
        IEnumerable<string> QueryMethod1(int[] ints) =>
            from i in ints
            where i > 4
            select i.ToString();

        // QueryMethod2 returns a query as the value of the out parameter returnQ
        void QueryMethod2(int[] ints, out IEnumerable<string> returnQ) =>
            returnQ =
                from i in ints
                where i < 4
                select i.ToString();

        int[] nums = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];

        // QueryMethod1 returns a query as the value of the method.
        var myQuery1 = QueryMethod1(nums);

        // Query myQuery1 is executed in the following foreach loop.
        Console.WriteLine("Results of executing myQuery1:");
        // Rest the mouse pointer over myQuery1 to see its type.
        foreach (var s in myQuery1)
        {
            Console.WriteLine(s);
        }

        // You also can execute the query returned from QueryMethod1
        // directly, without using myQuery1.
        Console.WriteLine("\nResults of executing myQuery1 directly:");
        // Rest the mouse pointer over the call to QueryMethod1 to see its
        // return type.
        foreach (var s in QueryMethod1(nums))
        {
            Console.WriteLine(s);
        }

        // QueryMethod2 returns a query as the value of its out parameter.
        QueryMethod2(nums, out IEnumerable<string> myQuery2);

        // Execute the returned query.
        Console.WriteLine("\nResults of executing myQuery2:");
        foreach (var s in myQuery2)
        {
            Console.WriteLine(s);
        }

        // You can modify a query by using query composition. In this case, the
        // previous query object is used to create a new query object; this new object
        // will return different results than the original query object.
        myQuery1 =
            from item in myQuery1
            orderby item descending
            select item;

        // Execute the modified query.
        Console.WriteLine("\nResults of executing modified myQuery1:");
        foreach (var s in myQuery1)
        {
            Console.WriteLine(s);
        }
        // </return_query_from_method_1>
    }
}
