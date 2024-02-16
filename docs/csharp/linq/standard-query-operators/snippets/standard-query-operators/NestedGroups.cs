namespace StandardQueryOperators;

public static class NestedGroups
{
    private static readonly IEnumerable<Student> students = Sources.Students;

    public static void RunAllSnippets()
    {
        Console.WriteLine("Nested Group Query Syntax");
        NestedGroupQuery();
        Console.WriteLine("Nested Group Method Syntax");
        NestedGroupMethod();
    }

    private static void NestedGroupQuery()
    {
        // <NestedGroupsQuerySyntax>
        var nestedGroupsQuery =
            from student in students
            group student by student.Year into newGroup1
            from newGroup2 in
            from student in newGroup1
            group student by student.LastName
            group newGroup2 by newGroup1.Key;

        foreach (var outerGroup in nestedGroupsQuery)
        {
            Console.WriteLine($"DataClass.Student Level = {outerGroup.Key}");
            foreach (var innerGroup in outerGroup)
            {
                Console.WriteLine($"\tNames that begin with: {innerGroup.Key}");
                foreach (var innerGroupElement in innerGroup)
                {
                    Console.WriteLine($"\t\t{innerGroupElement.LastName} {innerGroupElement.FirstName}");
                }
            }
        }
        // </NestedGroupsQuerySyntax>
    }
    private static void NestedGroupMethod()
    {
        // <NestedGroupsMethodSyntax>
        var nestedGroupsQuery =
            students
            .GroupBy(student => student.Year)
            .Select(newGroup1 => new
            {
                newGroup1.Key,
                NestedGroup = newGroup1
                    .GroupBy(student => student.LastName)
            });

        foreach (var outerGroup in nestedGroupsQuery)
        {
            Console.WriteLine($"DataClass.Student Level = {outerGroup.Key}");
            foreach (var innerGroup in outerGroup.NestedGroup)
            {
                Console.WriteLine($"\tNames that begin with: {innerGroup.Key}");
                foreach (var innerGroupElement in innerGroup)
                {
                    Console.WriteLine($"\t\t{innerGroupElement.LastName} {innerGroupElement.FirstName}");
                }
            }
        }
        // </NestedGroupsMethodSyntax>
    }
}
