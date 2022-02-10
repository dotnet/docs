{
    // <index>
    // Specify the data source.
    int[] scores = new int[] { 97, 92, 81, 60 };

    // Define the query expression.
    IEnumerable<int> scoreQuery =
        from score in scores
        where score > 80
        select score;

    // Execute the query.
    foreach (int i in scoreQuery)
    {
        Console.Write(i + " ");
    }

    // Output: 97 92 81
    // </index>

    // <query-expression-basics_1>
    IEnumerable<int> highScoresQuery =
        from score in scores
        where score > 80
        orderby score descending
        select score;
    // </query-expression-basics_1>

    // <query-expression-basics_2>
    IEnumerable<string> highScoresQuery2 =
        from score in scores
        where score > 80
        orderby score descending
        select $"The score is {score}";
    // </query-expression-basics_2>

    // <query-expression-basics_3>
    int highScoreCount =
        (from score in scores
         where score > 80
         select score)
         .Count();
    // </query-expression-basics_3>

    // <query-expression-basics_4>
    IEnumerable<int> highScoresQuery3 =
        from score in scores
        where score > 80
        select score;

    int scoreCount = highScoresQuery3.Count();
    // </query-expression-basics_4>
}

{
    // <query-expression-basics_5>
    // Data source.
    int[] scores = { 90, 71, 82, 93, 75, 82 };

    // Query Expression.
    IEnumerable<int> scoreQuery = //query variable
        from score in scores //required
        where score > 80 // optional
        orderby score descending // optional
        select score; //must end with select or group

    // Execute the query to produce the results
    foreach (int testScore in scoreQuery)
    {
        Console.WriteLine(testScore);
    }

    // Outputs: 93 90 82 82
    // </query-expression-basics_5>
}

var cities = new List<City>();

// <query-expression-basics_6>
//Query syntax
IEnumerable<City> queryMajorCities =
    from city in cities
    where city.Population > 100000
    select city;

// Method-based syntax
IEnumerable<City> queryMajorCities2 = cities.Where(c => c.Population > 100000);
// </query-expression-basics_6>

var countries = new List<Country>();
{
    int[] scores = new int[] { 97, 92, 81, 60 };

    // <query-expression-basics_7>
    int highestScore =
        (from score in scores
         select score)
        .Max();

    // or split the expression
    IEnumerable<int> scoreQuery =
        from score in scores
        select score;

    int highScore = scoreQuery.Max();
    // the following returns the same result
    highScore = scores.Max();

    List<City> largeCitiesList =
        (from country in countries
         from city in country.Cities
         where city.Population > 10000
         select city)
           .ToList();

    // or split the expression
    IEnumerable<City> largeCitiesQuery =
        from country in countries
        from city in country.Cities
        where city.Population > 10000
        select city;

    List<City> largeCitiesList2 = largeCitiesQuery.ToList();
    // </query-expression-basics_7>
}

// <query-expression-basics_8>
// Use of var is optional here and in all queries.
// queryCities is an IEnumerable<City> just as
// when it is explicitly typed.
var queryCities =
    from city in cities
    where city.Population > 100000
    select city;
// </query-expression-basics_8>

// <query-expression-basics_9>
IEnumerable<Country> countryAreaQuery =
    from country in countries
    where country.Area > 500000 //sq km
    select country;
// </query-expression-basics_9>

// <query-expression-basics_10>
IEnumerable<City> cityQuery =
    from country in countries
    from city in country.Cities
    where city.Population > 10000
    select city;
// </query-expression-basics_10>

// <query-expression-basics_11>
var queryCountryGroups =
    from country in countries
    group country by country.Name[0];
// </query-expression-basics_11>

// <query-expression-basics_12>
IEnumerable<Country> sortedQuery =
    from country in countries
    orderby country.Area
    select country;
// </query-expression-basics_12>

// <query-expression-basics_13>
// Here var is required because the query
// produces an anonymous type.
var queryNameAndPop =
    from country in countries
    select new { Name = country.Name, Pop = country.Population };
// </query-expression-basics_13>

{
    // <query-expression-basics_14>
    // percentileQuery is an IEnumerable<IGrouping<int, Country>>
    var percentileQuery =
        from country in countries
        let percentile = (int)country.Population / 10_000_000
        group country by percentile into countryGroup
        where countryGroup.Key >= 20
        orderby countryGroup.Key
        select countryGroup;

    // grouping is an IGrouping<int, Country>
    foreach (var grouping in percentileQuery)
    {
        Console.WriteLine(grouping.Key);
        foreach (var country in grouping)
        {
            Console.WriteLine(country.Name + ":" + country.Population);
        }
    }
    // </query-expression-basics_14>
}

// <query-expression-basics_15>
IEnumerable<City> queryCityPop =
    from city in cities
    where city.Population < 200000 && city.Population > 100000
    select city;
// </query-expression-basics_15>

// <query-expression-basics_16>
IEnumerable<Country> querySortedCountries =
    from country in countries
    orderby country.Area, country.Population descending
    select country;
// </query-expression-basics_16>

var categories = new string[] { };
var products = new List<Product>();

// <query-expression-basics_17>
var categoryQuery =
    from cat in categories
    join prod in products on cat equals prod.Category
    select new { Category = cat, Name = prod.Name };
// </query-expression-basics_17>

{
    // <query-expression-basics_18>
    string[] names = { "Svetlana Omelchenko", "Claire O'Donnell", "Sven Mortensen", "Cesar Garcia" };
    IEnumerable<string> queryFirstNames =
        from name in names
        let firstName = name.Split(' ')[0]
        select firstName;

    foreach (string s in queryFirstNames)
    {
        Console.Write(s + " ");
    }

    //Output: Svetlana Claire Sven Cesar
    // </query-expression-basics_18>
}

// TODO replace this with a using static
var students = Student.students;

{
    // <query-expression-basics_19>
    var queryGroupMax =
        from student in students
        group student by student.Year into studentGroup
        select new {
            Level = studentGroup.Key,
            HighestScore = (
                from student2 in studentGroup
                select student2.ExamScores.Average()
            ).Max()
        };
    // </query-expression-basics_19>
}

{
    // <write-linq-queries_1>
    List<int> numbers = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

    // The query variables can also be implicitly typed by using var

    // Query #1.
    IEnumerable<int> filteringQuery =
        from num in numbers
        where num < 3 || num > 7
        select num;

    // Query #2.
    IEnumerable<int> orderingQuery =
        from num in numbers
        where num < 3 || num > 7
        orderby num ascending
        select num;

    // Query #3.
    string[] groupingQuery = { "carrots", "cabbage", "broccoli", "beans", "barley" };
    IEnumerable<IGrouping<char, string>> queryFoodGroups =
        from item in groupingQuery
        group item by item[0];
    // </write-linq-queries_1>
}

{
    // <write-linq-queries_2>
    List<int> numbers1 = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
    List<int> numbers2 = new List<int>() { 15, 14, 11, 13, 19, 18, 16, 17, 12, 10 };
    // Query #4.
    double average = numbers1.Average();

    // Query #5.
    IEnumerable<int> concatenationQuery = numbers1.Concat(numbers2);
    // </write-linq-queries_2>

    // <write-linq-queries_3>
    // Query #6.
    IEnumerable<int> largeNumbersQuery = numbers2.Where(c => c > 15);
    // </write-linq-queries_3>
}

{
    var numbers1 = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
    var numbers2 = new List<int>() { 15, 14, 11, 13, 19, 18, 16, 17, 12, 10 };

    // <write-linq-queries_4>
    // var is used for convenience in these queries
    var average = numbers1.Average();
    var concatenationQuery = numbers1.Concat(numbers2);
    var largeNumbersQuery = numbers2.Where(c => c > 15);
    // </write-linq-queries_4>
}

{
    var numbers1 = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
    var numbers2 = new List<int>() { 15, 14, 11, 13, 19, 18, 16, 17, 12, 10 };

    // <write-linq-queries_5>
    // Query #7.

    // Using a query expression with method syntax
    int numCount1 =
        (from num in numbers1
         where num < 3 || num > 7
         select num).Count();

    // Better: Create a new variable to store
    // the method call result
    IEnumerable<int> numbersQuery =
        from num in numbers1
        where num < 3 || num > 7
        select num;

    int numCount2 = numbersQuery.Count();
    // </write-linq-queries_5>
}

// <query-a-collection-of-objects_2>
void QueryHighScores(int exam, int score)
{
    var highScores = from student in students
                     where student.ExamScores[exam] > score
                     select new { Name = student.FirstName, Score = student.ExamScores[exam] };

    foreach (var item in highScores)
    {
        Console.WriteLine($"{item.Name,-15}{item.Score}");
    }
}

QueryHighScores(1, 90);
// </query-a-collection-of-objects_2>

// <how-to-return-a-query-from-a-method_1>
// QueryMethhod1 returns a query as its value.
IEnumerable<string> QueryMethod1(int[] ints) =>
    from i in ints
    where i > 4
    select i.ToString();

// QueryMethod2 returns a query as the value of the out parameter returnQ
void QueryMethod2(int[] ints, out IEnumerable<string> returnQ) =>
    returnQ =
        from i in ints
        where i < 4
        select i.ToString();

int[] nums = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

// QueryMethod1 returns a query as the value of the method.
var myQuery1 = QueryMethod1(nums);

// Query myQuery1 is executed in the following foreach loop.
Console.WriteLine("Results of executing myQuery1:");
// Rest the mouse pointer over myQuery1 to see its type.
foreach (var s in myQuery1)
{
    Console.WriteLine(s);
}

// You also can execute the query returned from QueryMethod1
// directly, without using myQuery1.
Console.WriteLine("\nResults of executing myQuery1 directly:");
// Rest the mouse pointer over the call to QueryMethod1 to see its
// return type.
foreach (var s in QueryMethod1(nums))
{
    Console.WriteLine(s);
}

IEnumerable<string> myQuery2;
// QueryMethod2 returns a query as the value of its out parameter.
QueryMethod2(nums, out myQuery2);

// Execute the returned query.
Console.WriteLine("\nResults of executing myQuery2:");
foreach (var s in myQuery2)
{
    Console.WriteLine(s);
}

// You can modify a query by using query composition. In this case, the
// previous query object is used to create a new query object; this new object
// will return different results than the original query object.
myQuery1 =
    from item in myQuery1
    orderby item descending
    select item;

// Execute the modified query.
Console.WriteLine("\nResults of executing modified myQuery1:");
foreach (var s in myQuery1)
{
    Console.WriteLine(s);
}
// </how-to-return-a-query-from-a-method_1>

{
    // <how-to-store-the-results-of-a-query-in-memory_1>
    List<int> numbers = new() { 1, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };

    IEnumerable<int> queryFactorsOfFour =
        from num in numbers
        where num % 4 == 0
        select num;

    // Store the results in a new variable
    // without executing a foreach loop.
    List<int> factorsofFourList = queryFactorsOfFour.ToList();

    // Read and write from the newly created list to demonstrate that it holds data.
    Console.WriteLine(factorsofFourList[2]);
    factorsofFourList[2] = 0;
    Console.WriteLine(factorsofFourList[2]);
    // </how-to-store-the-results-of-a-query-in-memory_1>
}

{
    // <group-query-results_2>
    Console.WriteLine("Group by a single property in an object:");

    // Variable queryLastNames is an IEnumerable<IGrouping<string,
    // DataClass.Student>>.
    var queryLastNames =
        from student in students
        group student by student.LastName into newGroup
        orderby newGroup.Key
        select newGroup;

    foreach (var nameGroup in queryLastNames)
    {
        Console.WriteLine($"Key: {nameGroup.Key}");
        foreach (var student in nameGroup)
        {
            Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
        }
    }

    /* Output:
        Group by a single property in an object:
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
    // </group-query-results_2>
}

{
    // <group-query-results_3>
    Console.WriteLine("\r\nGroup by something other than a property of the object:");

    var queryFirstLetters =
        from student in students
        group student by student.LastName[0];

    foreach (var studentGroup in queryFirstLetters)
    {
        Console.WriteLine($"Key: {studentGroup.Key}");
        // Nested foreach is required to access group items.
        foreach (var student in studentGroup)
        {
            Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
        }
    }

    /* Output:
        Group by something other than a property of the object:
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
    // </group-query-results_3>
}

{
    // <group-query-results_4>
    int GetPercentile(Student s)
    {
        double avg = s.ExamScores.Average();
        return avg > 0 ? (int)avg / 10 : 0;
    }
    // </group-query-results_4>

    // <group-query-results_5>
    Console.WriteLine("\r\nGroup by numeric range and project into a new anonymous type:");

    var queryNumericRange =
        from student in students
        let percentile = GetPercentile(student)
        group new { student.FirstName, student.LastName } by percentile into percentGroup
        orderby percentGroup.Key
        select percentGroup;

    // Nested foreach required to iterate over groups and group items.
    foreach (var studentGroup in queryNumericRange)
    {
        Console.WriteLine($"Key: {studentGroup.Key * 10}");
        foreach (var item in studentGroup)
        {
            Console.WriteLine($"\t{item.LastName}, {item.FirstName}");
        }
    }

    /* Output:
        Group by numeric range and project into a new anonymous type:
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
    // </group-query-results_5>
}

{
    // <group-query-results_6>
    Console.WriteLine("\r\nGroup by a Boolean into two groups with string keys");
    Console.WriteLine("\"True\" and \"False\" and project into a new anonymous type:");
    var queryGroupByAverages =
        from student in students
        group new { student.FirstName, student.LastName }
            by student.ExamScores.Average() > 75 into studentGroup
        select studentGroup;

    foreach (var studentGroup in queryGroupByAverages)
    {
        Console.WriteLine($"Key: {studentGroup.Key}");
        foreach (var student in studentGroup)
        {
            Console.WriteLine($"\t{student.FirstName} {student.LastName}");
        }
    }

    /* Output:
        Group by a Boolean into two groups with string keys
        "True" and "False" and project into a new anonymous type:
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
    // </group-query-results_6>
}

{
    // <group-query-results_7>
    var queryHighScoreGroups =
        from student in students
        group student by new {
            FirstLetter = student.LastName[0],
            Score = student.ExamScores[0] > 85
        } into studentGroup
        orderby studentGroup.Key.FirstLetter
        select studentGroup;

    Console.WriteLine("\r\nGroup and order by a compound key:");
    foreach (var scoreGroup in queryHighScoreGroups)
    {
        string s = scoreGroup.Key.Score == true ? "more than" : "less than";
        Console.WriteLine($"Name starts with {scoreGroup.Key.FirstLetter} who scored {s} 85");
        foreach (var item in scoreGroup)
        {
            Console.WriteLine($"\t{item.FirstName} {item.LastName}");
        }
    }

    /* Output:
        Group and order by a compound key:
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
    // </group-query-results_7>
}

{
    // <create-a-nested-group_1>
    var queryNestedGroups =
        from student in students
        group student by student.Year into newGroup1
        from newGroup2 in
            (from student in newGroup1
             group student by student.LastName)
        group newGroup2 by newGroup1.Key;

    // Three nested foreach loops are required to iterate
    // over all elements of a grouped group. Hover the mouse
    // cursor over the iteration variables to see their actual type.
    foreach (var outerGroup in queryNestedGroups)
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
    // </create-a-nested-group_1>
}

{
    // <perform-a-subquery-on-a-grouping-operation_1>
    var queryGroupMax =
        from student in students
        group student by student.Year into studentGroup
        select new {
            Level = studentGroup.Key,
            HighestScore = (
                from student2 in studentGroup
                select student2.ExamScores.Average()
            ).Max()
        };

    int count = queryGroupMax.Count();
    Console.WriteLine($"Number of groups = {count}");

    foreach (var item in queryGroupMax)
    {
        Console.WriteLine($"  {item.Level} Highest Score={item.HighestScore}");
    }
    // </perform-a-subquery-on-a-grouping-operation_1>
}

{
    // <perform-a-subquery-on-a-grouping-operation_2>
    var queryGroupMax =
        students
            .GroupBy(student => student.Year)
            .Select(studentGroup => new {
                Level = studentGroup.Key,
                HighestScore = studentGroup.Select(student2 => student2.ExamScores.Average()).Max()
            });

    int count = queryGroupMax.Count();
    Console.WriteLine($"Number of groups = {count}");

    foreach (var item in queryGroupMax)
    {
        Console.WriteLine($"  {item.Level} Highest Score={item.HighestScore}");
    }
    // </perform-a-subquery-on-a-grouping-operation_2>
}

{
    // <dynamically-specify-predicate-filters-at-runtime_1>
    int[] ids = { 111, 114, 112 };

    var queryNames =
        from student in students
        where ids.Contains(student.ID)
        select new { student.LastName, student.ID };

    foreach (var name in queryNames)
    {
        Console.WriteLine($"{name.LastName}: {name.ID}");
    }
    // <dynamically-specify-predicate-filters-at-runtime_1>
}

{
    // <dynamically-specify-predicate-filters-at-runtime_2>
    void QueryByYear(GradeLevel level)
    {
        IEnumerable<Student> studentQuery = level switch
        {
            GradeLevel.FirstYear =>
                from student in students
                where student.Year == GradeLevel.FirstYear
                select student,
            GradeLevel.SecondYear =>
                from student in students
                where student.Year == GradeLevel.SecondYear
                select student,
            GradeLevel.ThirdYear =>
                from student in students
                where student.Year == GradeLevel.ThirdYear
                select student,
            GradeLevel.FourthYear =>
                from student in students
                where student.Year == GradeLevel.FourthYear
                select student,
            _ => throw new ArgumentException("Not a valid GradeLevel")
        };
        if (studentQuery is null) { return; }

        Console.WriteLine($"The following students are at level {(int)level}");
        foreach (Student name in studentQuery)
        {
            Console.WriteLine($"{name.LastName}: {name.ID}");
        }
    }
    // </dynamically-specify-predicate-filters-at-runtime_2>
}

{
    // <handle-exceptions-in-query-expressions_1>
    // A data source that is very likely to throw an exception!
    IEnumerable<int> GetData() => throw new InvalidOperationException();

    // DO THIS with a datasource that might
    // throw an exception. It is easier to deal with
    // outside of the query expression.
    IEnumerable<int>? dataSource = null;
    try
    {
        dataSource = GetData();
    }
    catch (InvalidOperationException)
    {
        // Handle (or don't handle) the exception
        // in the way that is appropriate for your application.
        Console.WriteLine("Invalid operation");
    }

    if (dataSource is not null)
    {
        // If we get here, it is safe to proceed.
        var query = 
            from i in dataSource
            select i * i;

        foreach (var i in query)
        {
            Console.WriteLine(i.ToString());
        }
    }
    // </handle-exceptions-in-query-expressions_1>
}

{
    // <handle-exceptions-in-query-expressions_2>
    // Not very useful as a general purpose method.
    string SomeMethodThatMightThrow(string s) =>
        s[4] == 'C' ?
            throw new InvalidOperationException() :
            @"C:\newFolder\" + s;

    // Data source.
    string[] files = { "fileA.txt", "fileB.txt", "fileC.txt" };

    // Demonstration query that throws.
    var exceptionDemoQuery =
        from file in files
        let n = SomeMethodThatMightThrow(file)
        select n;

    // The runtime exception will only be thrown when the query is executed.
    // Therefore they must be handled in the foreach loop.
    try
    {
        foreach (var item in exceptionDemoQuery)
        {
            Console.WriteLine($"Processing {item}");
        }
    }

    // Catch whatever exception you expect to raise
    // and/or do any necessary cleanup in a finally block
    catch (InvalidOperationException e)
    {
        Console.WriteLine(e.Message);
    }

    /* Output:
        Processing C:\newFolder\fileA.txt
        Processing C:\newFolder\fileB.txt
        Operation is not valid due to the current state of the object.
     */
    // </handle-exceptions-in-query-expressions_2>
}
