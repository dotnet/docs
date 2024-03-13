using System.Collections.Generic;

namespace StandardQueryOperators;

internal class SortExamples
{
    private static readonly IEnumerable<Teacher> teachers = Sources.Teachers;
    public static void RunAllSnippets()
    {
        Console.WriteLine("Ascending Query");
        AscendingSortQuerySyntax();
        Console.WriteLine("Ascending Method");
        AscendingSortMethodSyntax();
        Console.WriteLine("Descending Query");
        DescendingSortQuerySyntax();
        Console.WriteLine("Descending Method");
        DescendingSortMethodSyntax();
        Console.WriteLine("Ascending Secondary Query");
        SecondaryAscendingSortQuerySyntax();
        Console.WriteLine("Ascending Secondary Method");
        SecondaryAscendingSortMethodSyntax();
        Console.WriteLine("Descending Secondary Query");
        SecondaryDescendingSortQuerySyntax();
        Console.WriteLine("Descending Secondary Method");
        SecondaryDescendingSortMethodSyntax();
    }

    private static void AscendingSortQuerySyntax()
    {
        // <PrimaryAscendingSortQuery>
        IEnumerable<string> query = from teacher in teachers
                                    orderby teacher.Last
                                    select teacher.Last;

        foreach (string str in query)
        {
            Console.WriteLine(str);
        }
        // </PrimaryAscendingSortQuery>
    }

    private static void AscendingSortMethodSyntax()
    {
        // <PrimaryAscendingSortMethod>
        IEnumerable<string> query = teachers
            .OrderBy(teacher => teacher.Last)
            .Select(teacher => teacher.Last);

        foreach (string str in query)
        {
            Console.WriteLine(str);
        }
        // </PrimaryAscendingSortMethod>
    }

    private static void DescendingSortQuerySyntax()
    {
        // <PrimaryDescendingSortQuery>
        IEnumerable<string> query = from teacher in teachers
                                    orderby teacher.Last descending
                                    select teacher.Last;

        foreach (string str in query)
        {
            Console.WriteLine(str);
        }
        // </PrimaryDescendingSortQuery>
    }

    private static void DescendingSortMethodSyntax()
    {
        // <PrimaryDescendingSortMethod>
        IEnumerable<string> query = teachers
            .OrderByDescending(teacher => teacher.Last)
            .Select(teacher => teacher.Last);

        foreach (string str in query)
        {
            Console.WriteLine(str);
        }
        // </PrimaryDescendingSortMethod>
    }

    private static void SecondaryAscendingSortQuerySyntax()
    {
        // <SecondaryAscendingSortQuery>
        IEnumerable<(string, string)> query = from teacher in teachers
                                    orderby teacher.City, teacher.Last
                                    select (teacher.Last, teacher.City);

        foreach ((string last, string city) in query)
        {
            Console.WriteLine($"City: {city}, Last Name: {last}");
        }
        // </SecondaryAscendingSortQuery>
    }

    private static void SecondaryAscendingSortMethodSyntax()
    {
        // <SecondaryAscendingSortMethod>
        IEnumerable<(string, string)> query = teachers
            .OrderBy(teacher => teacher.City)
            .ThenBy(teacher => teacher.Last)
            .Select(teacher => (teacher.Last, teacher.City));

        foreach ((string last, string city) in query)
        {
            Console.WriteLine($"City: {city}, Last Name: {last}");
        }
        // </SecondaryAscendingSortMethod>
    }

    private static void SecondaryDescendingSortQuerySyntax()
    {
        // <SecondaryDescendingSortQuery>
        IEnumerable<(string, string)> query = from teacher in teachers
                                    orderby teacher.City, teacher.Last descending
                                    select (teacher.Last, teacher.City);

        foreach ((string last, string city) in query)
        {
            Console.WriteLine($"City: {city}, Last Name: {last}");
        }
        // </SecondaryDescendingSortQuery>
    }
    private static void SecondaryDescendingSortMethodSyntax()
    {
        // <SecondaryDescendingSortMethod>
        IEnumerable<(string, string)> query = teachers
            .OrderBy(teacher => teacher.City)
            .ThenByDescending(teacher => teacher.Last)
            .Select(teacher => (teacher.Last, teacher.City));

        foreach ((string last, string city) in query)
        {
            Console.WriteLine($"City: {city}, Last Name: {last}");
        }
        // </SecondaryDescendingSortMethod>
    }
}
