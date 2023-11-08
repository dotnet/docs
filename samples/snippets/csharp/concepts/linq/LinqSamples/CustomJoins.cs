using LinqSamples.Joins;

namespace LinqSamples;

public static class CustomJoins
{
    public static void CustomJoins1()
    {
        // <cross_join>
        List<Category> categories =
        [
            new(Name: "Beverages", ID: 001),
            new("Condiments", 002),
            new("Vegetables", 003)
        ];

        List<Product> products =
        [
            new(Name: "Tea", CategoryID: 001),
            new("Mustard", 002),
            new("Pickles", 002),
            new("Carrots", 003),
            new("Bok Choy", 003),
            new("Peaches", 005),
            new("Melons", 005),
            new("Ice Cream", 007),
            new("Mackerel", 012)
        ];

        var crossJoinQuery =
            from c in categories
            from p in products
            select new
            {
                c.ID,
                p.Name
            };

        Console.WriteLine("Cross Join Query:");
        foreach (var v in crossJoinQuery)
        {
            Console.WriteLine($"{v.ID,-5}{v.Name}");
        }
        /* Output:
            Cross Join Query:
            1    Tea
            1    Mustard
            1    Pickles
            1    Carrots
            1    Bok Choy
            1    Peaches
            1    Melons
            1    Ice Cream
            1    Mackerel
            2    Tea
            2    Mustard
            2    Pickles
            2    Carrots
            2    Bok Choy
            2    Peaches
            2    Melons
            2    Ice Cream
            2    Mackerel
            3    Tea
            3    Mustard
            3    Pickles
            3    Carrots
            3    Bok Choy
            3    Peaches
            3    Melons
            3    Ice Cream
            3    Mackerel
        */
        // </cross_join>

        // <non_equijoin>
        var nonEquijoinQuery =
            from p in products
            let catIds =
                from c in categories
                select c.ID
            where catIds.Contains(p.CategoryID) == true
            select new
            {
                Product = p.Name,
                p.CategoryID
            };

        Console.WriteLine("Non-equijoin query:");
        foreach (var v in nonEquijoinQuery)
        {
            Console.WriteLine($"{v.CategoryID,-5}{v.Product}");
        }

        /* Output:
            Non-equijoin query:
            1    Tea
            2    Mustard
            2    Pickles
            3    Carrots
            3    Bok Choy
        */
        // </non_equijoin>
    }

    public static void MergeCsvFiles()
    {
        // <merge_csv_files>
        string[] names = File.ReadAllLines(@"csv/names.csv");
        string[] scores = File.ReadAllLines(@"csv/scores.csv");

        // Merge the data sources using a named type.
        // You could use var instead of an explicit type for the query.
        IEnumerable<Student> queryNamesScores =
            // Split each line in the data files into an array of strings.
            from name in names
            let x = name.Split(',')
            from score in scores
            let s = score.Split(',')
            // Look for matching IDs from the two data files.
            where x[2] == s[0]
            // If the IDs match, build a Student object.
            select new Student(
                FirstName: x[0],
                LastName: x[1],
                StudentID: int.Parse(x[2]),
                ExamScores: (
                    from scoreAsText in s.Skip(1)
                    select int.Parse(scoreAsText)
                ).ToList()
            );

        // Optional. Store the newly created student objects in memory
        // for faster access in future queries
        List<Student> students = queryNamesScores.ToList();

        foreach (var student in students)
        {
            Console.WriteLine($"The average score of {student.FirstName} {student.LastName} is {student.ExamScores.Average()}.");
        }

        /* Output:
            The average score of Omelchenko Svetlana is 82.5.
            The average score of O'Donnell Claire is 72.25.
            The average score of Mortensen Sven is 84.5.
            The average score of Garcia Cesar is 88.25.
            The average score of Garcia Debra is 67.
            The average score of Fakhouri Fadi is 92.25.
            The average score of Feng Hanying is 88.
            The average score of Garcia Hugo is 85.75.
            The average score of Tucker Lance is 81.75.
            The average score of Adams Terry is 85.25.
            The average score of Zabokritski Eugene is 83.
            The average score of Tucker Michael is 92.
         */
        // </merge_csv_files>
    }

}
