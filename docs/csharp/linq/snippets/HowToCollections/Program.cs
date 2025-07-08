using System.Collections;

Console.WriteLine("SetDifferences");
SetDifferences();
Console.WriteLine();
Console.WriteLine("CombineCompareStringCollections");
CombineCompareStringCollections();
Console.WriteLine();
Console.WriteLine("PopulateCollection");
PopulateCollection();
Console.WriteLine();
Console.WriteLine("ArghArrayList");
ArghArrayList();

static void SetDifferences()
{
    // <SnippetSetDifferences>
    // Create the IEnumerable data sources.
    string[] names1 = File.ReadAllLines("names1.txt");
    string[] names2 = File.ReadAllLines("names2.txt");

    // Create the query. Note that method syntax must be used here.
    var differenceQuery = names1.Except(names2);

    // Execute the query.
    Console.WriteLine("The following lines are in names1.txt but not names2.txt");
    foreach (string s in differenceQuery)
        Console.WriteLine(s);
    /* Output:
     The following lines are in names1.txt but not names2.txt
     Potra, Cristina
     Noriega, Fabricio
     Aw, Kam Foo
     Toyoshima, Tim
     Guy, Wey Yuan
     Garcia, Debra
     */
    // </SnippetSetDifferences>
}

static void CombineCompareStringCollections()
{
    // <CombineCompareStringCollections>
    //Put text files in your solution folder
    string[] fileA = File.ReadAllLines("names1.txt");
    string[] fileB = File.ReadAllLines("names2.txt");

    //Simple concatenation and sort. Duplicates are preserved.
    var concatQuery = fileA.Concat(fileB).OrderBy(s => s);

    // Pass the query variable to another function for execution.
    OutputQueryResults(concatQuery, "Simple concatenate and sort. Duplicates are preserved:");

    // Concatenate and remove duplicate names based on
    // default string comparer.
    var uniqueNamesQuery = fileA.Union(fileB).OrderBy(s => s);
    OutputQueryResults(uniqueNamesQuery, "Union removes duplicate names:");

    // Find the names that occur in both files (based on
    // default string comparer).
    var commonNamesQuery = fileA.Intersect(fileB);
    OutputQueryResults(commonNamesQuery, "Merge based on intersect:");

    // Find the matching fields in each list. Merge the two
    // results by using Concat, and then
    // sort using the default string comparer.
    string nameMatch = "Garcia";

    var tempQuery1 = from name in fileA
                     let n = name.Split(',')
                     where n[0] == nameMatch
                     select name;

    var tempQuery2 = from name2 in fileB
                     let n2 = name2.Split(',')
                     where n2[0] == nameMatch
                     select name2;

    var nameMatchQuery = tempQuery1.Concat(tempQuery2).OrderBy(s => s);
    OutputQueryResults(nameMatchQuery, $"""Concat based on partial name match "{nameMatch}":""");

    static void OutputQueryResults(IEnumerable<string> query, string message)
    {
        Console.WriteLine(Environment.NewLine + message);
        foreach (string item in query)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine($"{query.Count()} total names in list");
    }
    /* Output:
        Simple concatenate and sort. Duplicates are preserved:
        Aw, Kam Foo
        Bankov, Peter
        Bankov, Peter
        Beebe, Ann
        Beebe, Ann
        El Yassir, Mehdi
        Garcia, Debra
        Garcia, Hugo
        Garcia, Hugo
        Giakoumakis, Leo
        Gilchrist, Beth
        Guy, Wey Yuan
        Holm, Michael
        Holm, Michael
        Liu, Jinghao
        McLin, Nkenge
        Myrcha, Jacek
        Noriega, Fabricio 
        Potra, Cristina
        Toyoshima, Tim
        20 total names in list

        Union removes duplicate names:
        Aw, Kam Foo
        Bankov, Peter
        Beebe, Ann
        El Yassir, Mehdi
        Garcia, Debra
        Garcia, Hugo
        Giakoumakis, Leo
        Gilchrist, Beth
        Guy, Wey Yuan
        Holm, Michael
        Liu, Jinghao
        McLin, Nkenge
        Myrcha, Jacek
        Noriega, Fabricio
        Potra, Cristina
        Toyoshima, Tim
        16 total names in list

        Merge based on intersect:
        Bankov, Peter
        Holm, Michael
        Garcia, Hugo
        Beebe, Ann
        4 total names in list

        Concat based on partial name match "Garcia":
        Garcia, Debra
        Garcia, Hugo
        Garcia, Hugo
        3 total names in list
    */
    // </CombineCompareStringCollections>
}

static void PopulateCollection()
{
    // <PopulateCollection>
    // Each line of names.csv consists of a last name, a first name, and an
    // ID number, separated by commas. For example, Omelchenko,Svetlana,111
    string[] names = File.ReadAllLines("names.csv");

    // Each line of scores.csv consists of an ID number and four test
    // scores, separated by commas. For example, 111, 97, 92, 81, 60
    string[] scores = File.ReadAllLines("scores.csv");

    // Merge the data sources using a named type.
    // var could be used instead of an explicit type. Note the dynamic
    // creation of a list of ints for the ExamScores member. The first item
    // is skipped in the split string because it is the student ID,
    // not an exam score.
    IEnumerable<Student> queryNamesScores = from nameLine in names
                                            let splitName = nameLine.Split(',')
                                            from scoreLine in scores
                                            let splitScoreLine = scoreLine.Split(',')
                                            where Convert.ToInt32(splitName[2]) == Convert.ToInt32(splitScoreLine[0])
                                            select new Student
                                            (
                                                FirstName: splitName[0],
                                                LastName: splitName[1],
                                                ID: Convert.ToInt32(splitName[2]),
                                                ExamScores: (from scoreAsText in splitScoreLine.Skip(1)
                                                             select Convert.ToInt32(scoreAsText)
                                                            ).ToArray()
                                            );

    // Optional. Store the newly created student objects in memory
    // for faster access in future queries. This could be useful with
    // very large data files.
    List<Student> students = queryNamesScores.ToList();

    // Display each student's name and exam score average.
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
    // </PopulateCollection>

    // <PopulateCollection2>
    // Merge the data sources by using an anonymous type.
    // Note the dynamic creation of a list of ints for the
    // ExamScores member. We skip 1 because the first string
    // in the array is the student ID, not an exam score.
    var queryNamesScores2 = from nameLine in names
                            let splitName = nameLine.Split(',')
                            from scoreLine in scores
                            let splitScoreLine = scoreLine.Split(',')
                            where Convert.ToInt32(splitName[2]) == Convert.ToInt32(splitScoreLine[0])
                            select (FirstName: splitName[0], 
                                    LastName: splitName[1], 
                                    ExamScores: (from scoreAsText in splitScoreLine.Skip(1)
                                                 select Convert.ToInt32(scoreAsText))
                                                 .ToList()
                                   );

    // Display each student's name and exam score average.
    foreach (var student in queryNamesScores2)
    {
        Console.WriteLine($"The average score of {student.FirstName} {student.LastName} is {student.ExamScores.Average()}.");
    }
    // </PopulateCollection2>
}

static void ArghArrayList()
{
    // <QueryArrayList>
    ArrayList arrList = new ArrayList();
    arrList.Add(
        new Student
        (
            FirstName: "Svetlana",
            LastName: "Omelchenko",
            ExamScores: new int[] { 98, 92, 81, 60 }
        ));
    arrList.Add(
        new Student
        (
            FirstName: "Claire",
            LastName: "O’Donnell",
            ExamScores: new int[] { 75, 84, 91, 39 }
        ));
    arrList.Add(
        new Student
        (
            FirstName: "Sven",
            LastName: "Mortensen",
            ExamScores: new int[] { 88, 94, 65, 91 }
        ));
    arrList.Add(
        new Student
        (
            FirstName: "Cesar",
            LastName: "Garcia",
            ExamScores: new int[] { 97, 89, 85, 82 }
        ));

    var query = from Student student in arrList
                where student.ExamScores[0] > 95
                select student;

    foreach (Student s in query)
        Console.WriteLine(s.LastName + ": " + s.ExamScores[0]);
    // </QueryArrayList>
}
public record Student(string FirstName, string LastName, int[] ExamScores, int ID=0);
