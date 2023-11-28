using static LinqSamples.Student;

namespace LinqSamples;

public static class SubqueryOnGroup
{
    public static void SubqueryOnGroup1()
    {
        // <subquery_on_group_1>
        var queryGroupMax =
            from student in students
            group student by student.Year into studentGroup
            select new
            {
                Level = studentGroup.Key,
                HighestScore = (
                    from student2 in studentGroup
                    select student2.ExamScores.Average()
                ).Max()
            };

        var count = queryGroupMax.Count();
        Console.WriteLine($"Number of groups = {count}");

        foreach (var item in queryGroupMax)
        {
            Console.WriteLine($"  {item.Level} Highest Score={item.HighestScore}");
        }

        // </subquery_on_group_1>
    }

    public static void SubqueryOnGroup2()
    {
        // <subquery_on_group_2>
        var queryGroupMax =
            students
                .GroupBy(student => student.Year)
                .Select(studentGroup => new
                {
                    Level = studentGroup.Key,
                    HighestScore = studentGroup
                        //.Select(student2 => student2.ExamScores.Average())    // fold into single method call
                        //.Max()
                        .Max(student2 => student2.ExamScores.Average())
                });

        var count = queryGroupMax.Count();
        Console.WriteLine($"Number of groups = {count}");

        foreach (var item in queryGroupMax)
        {
            Console.WriteLine($"  {item.Level} Highest Score={item.HighestScore}");
        }
        // </subquery_on_group_2>
    }
}
