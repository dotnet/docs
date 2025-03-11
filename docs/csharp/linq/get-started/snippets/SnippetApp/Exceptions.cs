namespace LinqSamples;

public static class Exceptions
{
    public static void Exceptions1()
    {
        // <exceptions_1>
        // A data source that is very likely to throw an exception!
        IEnumerable<int> GetData() => throw new InvalidOperationException();

        // DO THIS with a datasource that might
        // throw an exception.
        IEnumerable<int>? dataSource = null;
        try
        {
            dataSource = GetData();
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Invalid operation");
        }

        if (dataSource is not null)
        {
            // If we get here, it is safe to proceed.
            var query = from i in dataSource
                        select i * i;

            foreach (var i in query)
            {
                Console.WriteLine(i.ToString());
            }
        }
        // </exceptions_1>
    }

    public static void Exceptions2()
    {
        // <exceptions_2>
        // Not very useful as a general purpose method.
        string SomeMethodThatMightThrow(string s) =>
            s[4] == 'C' ?
                throw new InvalidOperationException() :
                $"""C:\newFolder\{s}""";

        // Data source.
        string[] files = ["fileA.txt", "fileB.txt", "fileC.txt"];

        // Demonstration query that throws.
        var exceptionDemoQuery = from file in files
                                 let n = SomeMethodThatMightThrow(file)
                                 select n;

        try
        {
            foreach (var item in exceptionDemoQuery)
            {
                Console.WriteLine($"Processing {item}");
            }
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }

        /* Output:
            Processing C:\newFolder\fileA.txt
            Processing C:\newFolder\fileB.txt
            Operation is not valid due to the current state of the object.
         */
        // </exceptions_2>
    }
}
