 namespace ExtensionMethods;
public static class ExtensionMethods
{
    public static void Examples()
    {
        //<UseOrderBy>
        int[] numbers = [10, 45, 15, 39, 21, 26];
        IOrderedEnumerable<int> result = numbers.OrderBy(g => g);
        foreach (int i in result)
        {
            Console.Write(i + " ");
        }
        //Output: 10 15 21 26 39 45
        //</UseOrderBy>
    }
}
