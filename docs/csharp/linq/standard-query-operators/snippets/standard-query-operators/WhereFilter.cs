namespace StandardQueryOperators;
public class WhereFilter
{
    public static void RunAllSnippets()
    {
        WhereSampleQuerySyntax();
        WhereSampleMethodSyntax();
    }

    private static void WhereSampleQuerySyntax()
    { 
        // <FilterExampleQuery>
        string[] words = ["the", "quick", "brown", "fox", "jumps"];

        IEnumerable<string> query = from word in words
                                    where word.Length == 3
                                    select word;

        foreach (string str in query)
        {
            Console.WriteLine(str);
        }

        /* This code produces the following output:

            the
            fox
        */
        // </FilterExampleQuery>
    }

    private static void WhereSampleMethodSyntax()
    {
        // <FilterExampleMethod>
        string[] words = ["the", "quick", "brown", "fox", "jumps"];

        IEnumerable<string> query =
            words.Where(word => word.Length == 3);

        foreach (string str in query)
        {
            Console.WriteLine(str);
        }

        /* This code produces the following output:

            the
            fox
        */
        // </FilterExampleMethod>
    }
}
