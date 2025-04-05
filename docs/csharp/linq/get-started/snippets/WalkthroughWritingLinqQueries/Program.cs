// <CreateSequence>
using WalkthroughWritingLinqQueries;

// Create a data source by using a collection initializer.
IEnumerable<Student> students =
[
    new Student(First: "Svetlana", Last: "Omelchenko", ID: 111, Scores: [97, 92, 81, 60]),
    new Student(First: "Claire",   Last: "O'Donnell",  ID: 112, Scores: [75, 84, 91, 39]),
    new Student(First: "Sven",     Last: "Mortensen",  ID: 113, Scores: [88, 94, 65, 91]),
    new Student(First: "Cesar",    Last: "Garcia",     ID: 114, Scores: [97, 89, 85, 82]),
    new Student(First: "Debra",    Last: "Garcia",     ID: 115, Scores: [35, 72, 91, 70]),
    new Student(First: "Fadi",     Last: "Fakhouri",   ID: 116, Scores: [99, 86, 90, 94]),
    new Student(First: "Hanying",  Last: "Feng",       ID: 117, Scores: [93, 92, 80, 87]),
    new Student(First: "Hugo",     Last: "Garcia",     ID: 118, Scores: [92, 90, 83, 78]),

    new Student("Lance",   "Tucker",      119, [68, 79, 88, 92]),
    new Student("Terry",   "Adams",       120, [99, 82, 81, 79]),
    new Student("Eugene",  "Zabokritski", 121, [96, 85, 91, 60]),
    new Student("Michael", "Tucker",      122, [94, 92, 91, 91])
];
// </CreateSequence>

// <DefineFirstQuery>
// Create the query.
// The first line could also be written as "var studentQuery ="
IEnumerable<Student> studentQuery =
    from student in students
    where student.Scores[0] > 90
    select student;
// </DefineFirstQuery>

Console.WriteLine("\nRunning Query 1.............");
// <RunFirstQuery>
// Execute the query.
// var could be used here also.
foreach (Student student in studentQuery)
{
    Console.WriteLine($"{student.Last}, {student.First}");
}

// Output:
// Omelchenko, Svetlana
// Garcia, Cesar
// Fakhouri, Fadi
// Feng, Hanying
// Garcia, Hugo
// Adams, Terry
// Zabokritski, Eugene
// Tucker, Michael
//</RunFirstQuery>

Console.WriteLine("\nRunning OrderBy Query.............");
OrderByQuery();

Console.WriteLine("\nRunning Group Query.............");
GroupQuery();

Console.WriteLine("\nRunning Group Var Query.............");
GroupVarQuery();

Console.WriteLine("\nRunning Ordered Group Query.............");
OrderedGroupQuery();

Console.WriteLine("\nRunning Group Query With Let.............");
QueryWithLetVariable();

Console.WriteLine("\nRunning Compute Average.............");
ComputeAverage();

Console.WriteLine("\nRunning Select projection.............");
SelectProjection();

void OrderByQuery()
{
    // Create the query.
    // The first line could also be written as "var studentQuery ="
    IEnumerable<Student> studentQuery =
        from student in students
        where student.Scores[0] > 90
        // <OrderByLast>
        orderby student.Last ascending
        // </OrderByLast>
        // <OrderByScore>
        orderby student.Scores[0] descending
        // </OrderByScore>
        select student;

    Console.WriteLine("\nRunning Query 1.............");
    // Execute the query.
    // var could be used here also.
    foreach (Student student in studentQuery)
    {
        // <WriteFirstScore>
        Console.WriteLine($"{student.Last}, {student.First} {student.Scores[0]}");
        // </WriteFirstScore>
    }
}

void GroupQuery()
{
    //<CreateGroupQuery>
    IEnumerable<IGrouping<char, Student>> studentQuery =
        from student in students
        group student by student.Last[0];
    //</CreateGroupQuery>

    //<RunGroupQuery>
    foreach (IGrouping<char, Student> studentGroup in studentQuery)
    {
        Console.WriteLine(studentGroup.Key);
        foreach (Student student in studentGroup)
        {
            Console.WriteLine($"   {student.Last}, {student.First}");
        }
    }
    // Output:
    // O
    //   Omelchenko, Svetlana
    //   O'Donnell, Claire
    // M
    //   Mortensen, Sven
    // G
    //   Garcia, Cesar
    //   Garcia, Debra
    //   Garcia, Hugo
    // F
    //   Fakhouri, Fadi
    //   Feng, Hanying
    // T
    //   Tucker, Lance
    //   Tucker, Michael
    // A
    //   Adams, Terry
    // Z
    //   Zabokritski, Eugene
    // </RunGroupQuery>
}

void GroupVarQuery()
{
    //<VarGroupQuery>
    IEnumerable<IGrouping<char, Student>> studentQuery =
        from student in students
        group student by student.Last[0];

    foreach (IGrouping<char, Student> studentGroup in studentQuery)
    {
        Console.WriteLine(studentGroup.Key);
        foreach (Student student in studentGroup)
        {
            Console.WriteLine($"   {student.Last}, {student.First}");
        }
    }
    // </VarGroupQuery>
}

void OrderedGroupQuery()
{
    //<OrderedGroupQuery>
    var studentQuery4 =
        from student in students
        group student by student.Last[0] into studentGroup
        orderby studentGroup.Key
        select studentGroup;

    foreach (var groupOfStudents in studentQuery4)
    {
        Console.WriteLine(groupOfStudents.Key);
        foreach (var student in groupOfStudents)
        {
            Console.WriteLine($"   {student.Last}, {student.First}");
        }
    }

    // Output:
    //A
    //   Adams, Terry
    //F
    //   Fakhouri, Fadi
    //   Feng, Hanying
    //G
    //   Garcia, Cesar
    //   Garcia, Debra
    //   Garcia, Hugo
    //M
    //   Mortensen, Sven
    //O
    //   Omelchenko, Svetlana
    //   O'Donnell, Claire
    //T
    //   Tucker, Lance
    //   Tucker, Michael
    //Z
    //   Zabokritski, Eugene
    //</OrderedGroupQuery>
}

void QueryWithLetVariable()
{
    // <QueryWithLet>
    // This query returns those students whose
    // first test score was higher than their
    // average score.
    var studentQuery5 =
        from student in students
        let totalScore = student.Scores[0] + student.Scores[1] +
            student.Scores[2] + student.Scores[3]
        where totalScore / 4 < student.Scores[0]
        select $"{student.Last}, {student.First}";

    foreach (string s in studentQuery5)
    {
        Console.WriteLine(s);
    }

    // Output:
    // Omelchenko, Svetlana
    // O'Donnell, Claire
    // Mortensen, Sven
    // Garcia, Cesar
    // Fakhouri, Fadi
    // Feng, Hanying
    // Garcia, Hugo
    // Adams, Terry
    // Zabokritski, Eugene
    // Tucker, Michael
    // </QueryWithLet>
}

void ComputeAverage()
{
    // <ComputeAverage>
    var studentQuery =
        from student in students
        let totalScore = student.Scores[0] + student.Scores[1] +
            student.Scores[2] + student.Scores[3]
        select totalScore;

    double averageScore = studentQuery.Average();
    Console.WriteLine($"Class average score = {averageScore}");

    // Output:
    // Class average score = 334.166666666667
    // </ComputeAverage>

    // <BetterThanMost>
    var aboveAverageQuery =
        from student in students
        let x = student.Scores[0] + student.Scores[1] +
            student.Scores[2] + student.Scores[3]
        where x > averageScore
        select new { id = student.ID, score = x };

    foreach (var item in aboveAverageQuery)
    {
        Console.WriteLine("Student ID: {0}, Score: {1}", item.id, item.score);
    }

    // Output:
    // Student ID: 113, Score: 338
    // Student ID: 114, Score: 353
    // Student ID: 116, Score: 369
    // Student ID: 117, Score: 352
    // Student ID: 118, Score: 343
    // Student ID: 120, Score: 341
    // Student ID: 122, Score: 368
    // </BetterThanMost>
}

void SelectProjection()
{
    // <SelectProjection>
    IEnumerable<string> studentQuery =
        from student in students
        where student.Last == "Garcia"
        select student.First;

    Console.WriteLine("The Garcias in the class are:");
    foreach (string s in studentQuery)
    {
        Console.WriteLine(s);
    }

    // Output:
    // The Garcias in the class are:
    // Cesar
    // Debra
    // Hugo
    // </SelectProjection>
}
