namespace StandardQueryOperators;

public class SubqueryOnGroup
{
    private static readonly IEnumerable<Student> students = Sources.Students;

    public static void RunAllSnippets()
    {
        Console.WriteLine("Subquery on Group");
        SubqueryOnGroupQuery();
        Console.WriteLine("Subquery on Group Method");
        SubqueryOnGroupMethod();
    }

    private static void SubqueryOnGroupQuery()
    {
        // <SubQueryOnGroupQuerySyntax>
        var queryGroupMax =
            from student in students
            group student by student.Year into studentGroup
            select new
            {
                Level = studentGroup.Key,
                HighestScore = (
                    from student2 in studentGroup
                    select student2.Scores.Average()
                ).Max()
            };

        var count = queryGroupMax.Count();
        Console.WriteLine($"Number of groups = {count}");

        foreach (var item in queryGroupMax)
        {
            Console.WriteLine($"  {item.Level} Highest Score={item.HighestScore}");
        }

        // </SubQueryOnGroupQuerySyntax>
    }

    public static void SubqueryOnGroupMethod()
    {
        // <SubQueryOnGroupMethodSyntax>
        var queryGroupMax =
            students
                .GroupBy(student => student.Year)
                .Select(studentGroup => new
                {
                    Level = studentGroup.Key,
                    HighestScore = studentGroup.Max(student2 => student2.Scores.Average())
                });

        var count = queryGroupMax.Count();
        Console.WriteLine($"Number of groups = {count}");

        foreach (var item in queryGroupMax)
        {
            Console.WriteLine($"  {item.Level} Highest Score={item.HighestScore}");
        }
        // </SubQueryOnGroupMethodSyntax>
    }
}
