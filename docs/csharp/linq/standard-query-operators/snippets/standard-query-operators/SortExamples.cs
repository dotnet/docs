namespace StandardQueryOperators;

internal class SortExamples
{
    private static readonly IEnumerable<Teacher> teachers = Teacher.Teachers;
    public static void RunAllSnippets()
    {
        AscendingSortQuerySyntax();
        AscendingSortMethodSyntax();
        DescendingSortQuerySyntax();
        DescendingSortMethodSyntax();
        SecondaryAscendingSortQuerySyntax();
        SecondaryAscendingSortMethodSyntax();
        SecondaryDescendingSortQuerySyntax();
        SecondaryDescendingSortMethodSyntax();
    }

    private static void AscendingSortQuerySyntax()
    {
        // <PrimaryAscendingSortQuery>
        IEnumerable<string> query = from teacher in teachers
                                    orderby teacher.Last
                                    select teacher.Last;

        foreach (string str in query)
            Console.WriteLine(str);

        /* This code produces the following output:

            the
            fox
            quick
            brown
            jumps
        */
        // </PrimaryAscendingSortQuery>
    }

    private static void AscendingSortMethodSyntax()
    {
        // <PrimaryAscendingSortMethod>
        IEnumerable<string> query = teachers
            .OrderBy(teacher => teacher.Last)
            .Select(teacher => teacher.Last);

        foreach (string str in query)
            Console.WriteLine(str);

        /* This code produces the following output:

            the
            fox
            quick
            brown
            jumps
        */
        // </PrimaryAscendingSortMethod>
    }

    private static void DescendingSortQuerySyntax()
    {
        // <PrimaryDescendingSortQuery>
        IEnumerable<string> query = from teacher in teachers
                                    orderby teacher.Last descending
                                    select teacher.Last;

        foreach (string str in query)
            Console.WriteLine(str);

        /* This code produces the following output:

            the
            quick
            jumps
            fox
            brown
        */
        // </PrimaryDescendingSortQuery>
    }

    private static void DescendingSortMethodSyntax()
    {
        // <PrimaryDescendingSortMethod>
        IEnumerable<string> query = teachers
            .OrderByDescending(teacher => teacher.Last)
            .Select(teacher => teacher.Last);

        foreach (string str in query)
            Console.WriteLine(str);

        /* This code produces the following output:

            the
            fox
            quick
            brown
            jumps
        */
        // </PrimaryDescendingSortMethod>
    }

    private static void SecondaryAscendingSortQuerySyntax()
    {
        // <SecondaryAscendingSortQuery>
        IEnumerable<string> query = from teacher in teachers
                                    orderby teacher.City, teacher.Last
                                    select teacher.Last;

        foreach (string str in query)
            Console.WriteLine(str);

        /* This code produces the following output:

            fox
            the
            brown
            jumps
            quick
        */
        // </SecondaryAscendingSortQuery>
    }

    private static void SecondaryAscendingSortMethodSyntax()
    {
        // <SecondaryAscendingSortMethod>
        IEnumerable<string> query = teachers
            .OrderBy(teacher => teacher.City)
            .ThenBy(teacher => teacher.Last)
            .Select(teacher => teacher.Last);

        foreach (string str in query)
            Console.WriteLine(str);

        /* This code produces the following output:

            fox
            the
            brown
            jumps
            quick
        */
        // </SecondaryAscendingSortMethod>
    }

    private static void SecondaryDescendingSortQuerySyntax()
    {
        // <SecondaryDescendingSortQuery>
        IEnumerable<string> query = from teacher in teachers
                                    orderby teacher.City, teacher.Last descending
                                    select teacher.Last;

        foreach (string str in query)
            Console.WriteLine(str);

        /* This code produces the following output:

            the
            fox
            quick
            jumps
            brown
        */
        // </SecondaryDescendingSortQuery>
    }
    private static void SecondaryDescendingSortMethodSyntax()
    {
        // <SecondaryDescendingSortMethod>
        IEnumerable<string> query = teachers
            .OrderBy(teacher => teacher.City)
            .ThenByDescending(teacher => teacher.Last)
            .Select(teacher => teacher.Last);

        foreach (string str in query)
            Console.WriteLine(str);

        /* This code produces the following output:

            fox
            the
            brown
            jumps
            quick
        */
        // </SecondaryDescendingSortMethod>
    }
}
