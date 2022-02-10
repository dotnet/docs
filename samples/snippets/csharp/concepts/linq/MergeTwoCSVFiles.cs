namespace LinqSamples.MergeTwoCSVFiles;

record Student(string FirstName, string LastName, int ID, List<int> ExamScores);

public static class Samples
{
    public static void MergeTwoCSVFiles()
    {
        // <custom-join-operations_2>
        // See section Compiling the Code for information about the data files.
        string[] names = File.ReadAllLines(@"../../../names.csv");
        string[] scores = File.ReadAllLines(@"../../../scores.csv");

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
                x[0], x[1], int.Parse(x[2]), (
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
        // </custom-join-operations_2>
    }
}
