namespace StandardQueryOperators;

public class GroupQueryResults
{
    private static readonly IEnumerable<Student> students = Student.Students;

    public static void RunAllSnippets()
    {
        GroupByPropertyQuery();
        GroupByPropertyMethod();
        GroupByValueQuery();
        GroupByValueMethod();
        GroupByRangeQuery();
        GroupByRangeMethod ();
        GroupByBooleanQuery();
        GroupByBooleanMethod();
        GroupByCompoundKeyQuery();
        GroupByCompoundKeyMethod();
    }

    public static void GroupByPropertyQuery()
    {
        // <GroupByPropertyQuery>
        // Variable groupByLastNamesQuery is an IEnumerable<IGrouping<string,
        // DataClass.Student>>.
        var groupByLastNamesQuery =
            from student in students
            group student by student.LastName into newGroup
            orderby newGroup.Key
            select newGroup;

        foreach (var nameGroup in groupByLastNamesQuery)
        {
            Console.WriteLine($"Key: {nameGroup.Key}");
            foreach (var student in nameGroup)
            {
                Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
            }
        }

        /* Output:
            Key: Adams
                    Adams, Terry
            Key: Fakhouri
                    Fakhouri, Fadi
            Key: Feng
                    Feng, Hanying
            Key: Garcia
                    Garcia, Cesar
                    Garcia, Debra
                    Garcia, Hugo
            Key: Mortensen
                    Mortensen, Sven
            Key: O'Donnell
                    O'Donnell, Claire
            Key: Omelchenko
                    Omelchenko, Svetlana
            Key: Tucker
                    Tucker, Lance
                    Tucker, Michael
            Key: Zabokritski
                    Zabokritski, Eugene
        */
        // </GroupByPropertyQuery>
    }

    public static void GroupByPropertyMethod()
    {
        // <GroupByPropertyMethod>
        // Variable groupByLastNamesQuery is an IEnumerable<IGrouping<string,
        // DataClass.Student>>.
        var groupByLastNamesQuery = students
            .GroupBy(student => student.LastName)
            .OrderBy(newGroup => newGroup.Key);

        foreach (var nameGroup in groupByLastNamesQuery)
        {
            Console.WriteLine($"Key: {nameGroup.Key}");
            foreach (var student in nameGroup)
            {
                Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
            }
        }

        /* Output:
            Key: Adams
                    Adams, Terry
            Key: Fakhouri
                    Fakhouri, Fadi
            Key: Feng
                    Feng, Hanying
            Key: Garcia
                    Garcia, Cesar
                    Garcia, Debra
                    Garcia, Hugo
            Key: Mortensen
                    Mortensen, Sven
            Key: O'Donnell
                    O'Donnell, Claire
            Key: Omelchenko
                    Omelchenko, Svetlana
            Key: Tucker
                    Tucker, Lance
                    Tucker, Michael
            Key: Zabokritski
                    Zabokritski, Eugene
        */
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

        /* Output:
            Key: A
                    Adams, Terry
            Key: F
                    Fakhouri, Fadi
                    Feng, Hanying
            Key: G
                    Garcia, Cesar
                    Garcia, Debra
                    Garcia, Hugo
            Key: M
                    Mortensen, Sven
            Key: O
                    O'Donnell, Claire
                    Omelchenko, Svetlana
            Key: T
                    Tucker, Lance
                    Tucker, Michael
            Key: Z
                    Zabokritski, Eugene
        */
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

        /* Output:
            Key: A
                    Adams, Terry
            Key: F
                    Fakhouri, Fadi
                    Feng, Hanying
            Key: G
                    Garcia, Cesar
                    Garcia, Debra
                    Garcia, Hugo
            Key: M
                    Mortensen, Sven
            Key: O
                    O'Donnell, Claire
                    Omelchenko, Svetlana
            Key: T
                    Tucker, Lance
                    Tucker, Michael
            Key: Z
                    Zabokritski, Eugene
        */
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

        /* Output:
            Key: 60
                    Garcia, Debra
            Key: 70
                    O'Donnell, Claire
            Key: 80
                    Adams, Terry
                    Feng, Hanying
                    Garcia, Cesar
                    Garcia, Hugo
                    Mortensen, Sven
                    Omelchenko, Svetlana
                    Tucker, Lance
                    Zabokritski, Eugene
            Key: 90
                    Fakhouri, Fadi
                    Tucker, Michael
        */
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

        /* Output:
            Key: 60
                    Garcia, Debra
            Key: 70
                    O'Donnell, Claire
            Key: 80
                    Adams, Terry
                    Feng, Hanying
                    Garcia, Cesar
                    Garcia, Hugo
                    Mortensen, Sven
                    Omelchenko, Svetlana
                    Tucker, Lance
                    Zabokritski, Eugene
            Key: 90
                    Fakhouri, Fadi
                    Tucker, Michael
        */
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

        /* Output:
            Key: True
                    Terry Adams
                    Fadi Fakhouri
                    Hanying Feng
                    Cesar Garcia
                    Hugo Garcia
                    Sven Mortensen
                    Svetlana Omelchenko
                    Lance Tucker
                    Michael Tucker
                    Eugene Zabokritski
            Key: False
                    Debra Garcia
                    Claire O'Donnell
        */
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

        /* Output:
            Key: True
                    Terry Adams
                    Fadi Fakhouri
                    Hanying Feng
                    Cesar Garcia
                    Hugo Garcia
                    Sven Mortensen
                    Svetlana Omelchenko
                    Lance Tucker
                    Michael Tucker
                    Eugene Zabokritski
            Key: False
                    Debra Garcia
                    Claire O'Donnell
        */
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

        /* Output:
            Name starts with A who scored more than 85
                    Terry Adams
            Name starts with F who scored more than 85
                    Fadi Fakhouri
                    Hanying Feng
            Name starts with G who scored more than 85
                    Cesar Garcia
                    Hugo Garcia
            Name starts with G who scored less than 85
                    Debra Garcia
            Name starts with M who scored more than 85
                    Sven Mortensen
            Name starts with O who scored less than 85
                    Claire O'Donnell
            Name starts with O who scored more than 85
                    Svetlana Omelchenko
            Name starts with T who scored less than 85
                    Lance Tucker
            Name starts with T who scored more than 85
                    Michael Tucker
            Name starts with Z who scored more than 85
                    Eugene Zabokritski
        */
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

        /* Output:
            Name starts with A who scored more than 85
                    Terry Adams
            Name starts with F who scored more than 85
                    Fadi Fakhouri
                    Hanying Feng
            Name starts with G who scored more than 85
                    Cesar Garcia
                    Hugo Garcia
            Name starts with G who scored less than 85
                    Debra Garcia
            Name starts with M who scored more than 85
                    Sven Mortensen
            Name starts with O who scored less than 85
                    Claire O'Donnell
            Name starts with O who scored more than 85
                    Svetlana Omelchenko
            Name starts with T who scored less than 85
                    Lance Tucker
            Name starts with T who scored more than 85
                    Michael Tucker
            Name starts with Z who scored more than 85
                    Eugene Zabokritski
        */
        // </GroupByCompundKeyMethodSyntax>
    }
}
