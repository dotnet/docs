namespace StandardQueryOperators;
internal class GroupOverview
{
    public static void RunAllSnippets()
    {
        Console.WriteLine("Group Overview");
        OverviewSampleQuery();
        Console.WriteLine("Group Overview Method");
        OverviewSampleMethod();
    }

    private static void OverviewSampleQuery()
    {
        // <OverviewSampleQuerySyntax>
        List<int> numbers = [35, 44, 200, 84, 3987, 4, 199, 329, 446, 208];

        IEnumerable<IGrouping<int, int>> query = from number in numbers
                                                 group number by number % 2;

        foreach (var group in query)
        {
            Console.WriteLine(group.Key == 0 ? "\nEven numbers:" : "\nOdd numbers:");
            foreach (int i in group)
            {
                Console.WriteLine(i);
            }
        }
        // </OverviewSampleQuerySyntax>
    }

    private static void OverviewSampleMethod()
    {
        // <OverviewSampleMethodSyntax>
        List<int> numbers = [35, 44, 200, 84, 3987, 4, 199, 329, 446, 208];

        IEnumerable<IGrouping<int, int>> query = numbers
            .GroupBy(number => number % 2);

        foreach (var group in query)
        {
            Console.WriteLine(group.Key == 0 ? "\nEven numbers:" : "\nOdd numbers:");
            foreach (int i in group)
            {
                Console.WriteLine(i);
            }
        }
        // </OverviewSampleMethodSyntax>
    }
}
