using static LinqSamples.Student;

namespace LinqSamples;

public static class GroupQueryResults
{
    /// <summary>Group by a single property in an object</summary>
    public static void GroupQueryResults1()
    {
        // <group_query_results_1>
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
        // </group_query_results_1>
    }

    /// <summary>Group by something other than a property of the object</summary>
    public static void GroupQueryResults2()
    {
        // <group_query_results_2>
        var groupByFirstLetterQuery =
            from student in students
            group student by student.LastName[0];

        foreach (var studentGroup in groupByFirstLetterQuery)
        {
            Console.WriteLine($"Key: {studentGroup.Key}");
            // Nested foreach is required to access group items.
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
        // </group_query_results_2>
    }

    /// <summary>Group by numeric range and project into a new anonymous type</summary>
    public static void GroupQueryResults3()
    {
        // <group_query_results_3>
        int GetPercentile(Student s)
        {
            double avg = s.ExamScores.Average();
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

        // Nested foreach required to iterate over groups and group items.
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
        // </group_query_results_3>
    }

    /// <summary>
    /// Group by a Boolean into two groups with string keys
    /// "True" and "False" and project into a new anonymous type
    /// </summary>
    public static void GroupQueryResults4()
    {
        // <group_query_results_4>
        var groupByHighAverageQuery =
            from student in students
            group new
            {
                student.FirstName,
                student.LastName
            } by student.ExamScores.Average() > 75 into studentGroup
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
        // </group_query_results_4>
    }

    /// <summary>Group and order by a compound key</summary>
    public static void GroupQueryResults5()
    {
        // <group_query_results_5>
        var groupByCompoundKey =
            from student in students
            group student by new
            {
                FirstLetterOfLastName = student.LastName[0],
                IsScoreOver85 = student.ExamScores[0] > 85
            } into studentGroup
            orderby studentGroup.Key.FirstLetterOfLastName
            select studentGroup;

        foreach (var scoreGroup in groupByCompoundKey)
        {
            string s = scoreGroup.Key.IsScoreOver85 == true ? "more than 85" : "less than 85";
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
        // </group_query_results_5>
    }
}
