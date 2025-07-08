namespace StandardQueryOperators;

public class GroupQueryResults
{
    private static readonly IEnumerable<Student> students = Sources.Students;

    public static void RunAllSnippets()
    {
        Console.WriteLine("Group ByProperty Results");
        GroupByPropertyQuery();
        Console.WriteLine("Group ByProperty Results Method");
        GroupByPropertyMethod();
        Console.WriteLine("Group ByValue Results");
        GroupByValueQuery();
        Console.WriteLine("Group ByValue Results Method");
        GroupByValueMethod();
        Console.WriteLine("Group ByRange Results");
        GroupByRangeQuery();
        Console.WriteLine("Group ByRange Results Method");
        GroupByRangeMethod ();
        Console.WriteLine("Group ByBoolean Results");
        GroupByBooleanQuery();
        Console.WriteLine("Group ByBoolean Results Method");
        GroupByBooleanMethod();
        Console.WriteLine("Group ByCompoundKey Results");
        GroupByCompoundKeyQuery();
        Console.WriteLine("Group ByCompoundKey Results Method");
        GroupByCompoundKeyMethod();
    }

    public static void GroupByPropertyQuery()
    {
        // <GroupByPropertyQuery>
        var groupByYearQuery =
            from student in students
            group student by student.Year into newGroup
            orderby newGroup.Key
            select newGroup;

        foreach (var yearGroup in groupByYearQuery)
        {
            Console.WriteLine($"Key: {yearGroup.Key}");
            foreach (var student in yearGroup)
            {
                Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
            }
        }
        // </GroupByPropertyQuery>
    }

    public static void GroupByPropertyMethod()
    {
        // <GroupByPropertyMethod>
        // Variable groupByYearQuery is an IEnumerable<IGrouping<GradeLevel,
        // DataClass.Student>>.
        var groupByYearQuery = students
            .GroupBy(student => student.Year)
            .OrderBy(newGroup => newGroup.Key);

        foreach (var yearGroup in groupByYearQuery)
        {
            Console.WriteLine($"Key: {yearGroup.Key}");
            foreach (var student in yearGroup)
            {
                Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
            }
        }
        // </GroupByPropertyMethod>
    }

    public static void GroupByValueQuery()
    {
        // <GroupByValueQuery>
        var groupByFirstLetterQuery =
            from student in students
            let firstLetter = student.LastName[0]
            group student by firstLetter;

        foreach (var studentGroup in groupByFirstLetterQuery)
        {
            Console.WriteLine($"Key: {studentGroup.Key}");
            foreach (var student in studentGroup)
            {
                Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
            }
        }

        // </GroupByValueQuery>
    }

    public static void GroupByValueMethod()
    {
        // <GroupByValueMethod>
        var groupByFirstLetterQuery = students
            .GroupBy(student => student.LastName[0]);

        foreach (var studentGroup in groupByFirstLetterQuery)
        {
            Console.WriteLine($"Key: {studentGroup.Key}");
            foreach (var student in studentGroup)
            {
                Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
            }
        }
        // </GroupByValueMethod>
    }

    public static void GroupByRangeQuery()
    {
        // <GroupByRangeQuery>
        static int GetPercentile(Student s)
        {
            double avg = s.Scores.Average();
            return avg > 0 ? (int)avg / 10 : 0;
        }

        var groupByPercentileQuery =
            from student in students
            let percentile = GetPercentile(student)
            group new
            {
                student.FirstName,
                student.LastName
            } by percentile into percentGroup
            orderby percentGroup.Key
            select percentGroup;

        foreach (var studentGroup in groupByPercentileQuery)
        {
            Console.WriteLine($"Key: {studentGroup.Key * 10}");
            foreach (var item in studentGroup)
            {
                Console.WriteLine($"\t{item.LastName}, {item.FirstName}");
            }
        }

        // </GroupByRangeQuery>
    }

    public static void GroupByRangeMethod()
    {
        // <GroupByRangeMethod>
        static int GetPercentile(Student s)
        {
            double avg = s.Scores.Average();
            return avg > 0 ? (int)avg / 10 : 0;
        }

        var groupByPercentileQuery = students
            .Select(student => new { student, percentile = GetPercentile(student) })
            .GroupBy(student => student.percentile)
            .Select(percentGroup => new
            {
                percentGroup.Key,
                Students = percentGroup.Select(s => new { s.student.FirstName, s.student.LastName })
            })
            .OrderBy(percentGroup => percentGroup.Key);

        foreach (var studentGroup in groupByPercentileQuery)
        {
            Console.WriteLine($"Key: {studentGroup.Key * 10}");
            foreach (var item in studentGroup.Students)
            {
                Console.WriteLine($"\t{item.LastName}, {item.FirstName}");
            }
        }
        // </GroupByRangeMethod>
    }

    public static void GroupByBooleanQuery()
    {
        // <GroupByBooleanQuerySyntax>
        var groupByHighAverageQuery =
            from student in students
            group new
            {
                student.FirstName,
                student.LastName
            } by student.Scores.Average() > 75 into studentGroup
            select studentGroup;

        foreach (var studentGroup in groupByHighAverageQuery)
        {
            Console.WriteLine($"Key: {studentGroup.Key}");
            foreach (var student in studentGroup)
            {
                Console.WriteLine($"\t{student.FirstName} {student.LastName}");
            }
        }
        // </GroupByBooleanQuerySyntax>
    }

    public static void GroupByBooleanMethod()
    {
        // <GroupByBooleanMethodSyntax>
        var groupByHighAverageQuery = students
            .GroupBy(student => student.Scores.Average() > 75)
            .Select(group => new
            {
                group.Key,
                Students = group.AsEnumerable().Select(s => new { s.FirstName, s.LastName })
            });

        foreach (var studentGroup in groupByHighAverageQuery)
        {
            Console.WriteLine($"Key: {studentGroup.Key}");
            foreach (var student in studentGroup.Students)
            {
                Console.WriteLine($"\t{student.FirstName} {student.LastName}");
            }
        }
        // </GroupByBooleanMethodSyntax>
    }

    public static void GroupByCompoundKeyQuery()
    {
        // <GroupByCompundKeyQuerySyntax>
        var groupByCompoundKey =
            from student in students
            group student by new
            {
                FirstLetterOfLastName = student.LastName[0],
                IsScoreOver85 = student.Scores[0] > 85
            } into studentGroup
            orderby studentGroup.Key.FirstLetterOfLastName
            select studentGroup;

        foreach (var scoreGroup in groupByCompoundKey)
        {
            var s = scoreGroup.Key.IsScoreOver85 ? "more than 85" : "less than 85";
            Console.WriteLine($"Name starts with {scoreGroup.Key.FirstLetterOfLastName} who scored {s}");
            foreach (var item in scoreGroup)
            {
                Console.WriteLine($"\t{item.FirstName} {item.LastName}");
            }
        }
        // </GroupByCompundKeyQuerySyntax>
    }

    public static void GroupByCompoundKeyMethod()
    {
        // <GroupByCompundKeyMethodSyntax>
        var groupByCompoundKey = students
            .GroupBy(student => new
            {
                FirstLetterOfLastName = student.LastName[0],
                IsScoreOver85 = student.Scores[0] > 85
            })
            .OrderBy(studentGroup => studentGroup.Key.FirstLetterOfLastName);

        foreach (var scoreGroup in groupByCompoundKey)
        {
            var s = scoreGroup.Key.IsScoreOver85 ? "more than 85" : "less than 85";
            Console.WriteLine($"Name starts with {scoreGroup.Key.FirstLetterOfLastName} who scored {s}");
            foreach (var item in scoreGroup)
            {
                Console.WriteLine($"\t{item.FirstName} {item.LastName}");
            }
        }
        // </GroupByCompundKeyMethodSyntax>
    }
}
