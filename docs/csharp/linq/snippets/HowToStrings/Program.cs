
Console.WriteLine("Chars in a string");
CharsInAString();
Console.WriteLine();
Console.WriteLine("Count words in a string");
CountWordsInAString();
Console.WriteLine();
Console.WriteLine("Sort strings");
SortStrings();
Console.WriteLine();
Console.WriteLine("Find sentences");
FindSentences();
QueryWithRegEx();

static void CharsInAString()
{
    // <CharsInAString>
    string aString = "ABCDE99F-J74-12-89A";

    // Select only those characters that are numbers
    var stringQuery = from ch in aString
                      where Char.IsDigit(ch)
                      select ch;

    // Execute the query
    foreach (char c in stringQuery)
        Console.Write(c + " ");

    // Call the Count method on the existing query.
    int count = stringQuery.Count();
    Console.WriteLine($"Count = {count}");

    // Select all characters before the first '-'
    var stringQuery2 = aString.TakeWhile(c => c != '-');

    // Execute the second query
    foreach (char c in stringQuery2)
        Console.Write(c);
    /* Output:
      Output: 9 9 7 4 1 2 8 9
      Count = 8
      ABCDE99F
    */
    // </CharsInAString>
}

static void CountWordsInAString()
{
    // <CountWordsInAString>
    string text = """
        Historically, the world of data and the world of objects 
        have not been well integrated. Programmers work in C# or Visual Basic 
        and also in SQL or XQuery. On the one side are concepts such as classes, 
        objects, fields, inheritance, and .NET APIs. On the other side 
        are tables, columns, rows, nodes, and separate languages for dealing with 
        them. Data types often require translation between the two worlds; there are 
        different standard functions. Because the object world has no notion of query, a 
        query can only be represented as a string without compile-time type checking or 
        IntelliSense support in the IDE. Transferring data from SQL tables or XML trees to 
        objects in memory is often tedious and error-prone. 
        """;

    string searchTerm = "data";

    //Convert the string into an array of words
    char[] separators = ['.', '?', '!', ' ', ';', ':', ','];
    string[] source = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

    // Create the query.  Use the InvariantCultureIgnoreCase comparison to match "data" and "Data"
    var matchQuery = from word in source
                     where word.Equals(searchTerm, StringComparison.InvariantCultureIgnoreCase)
                     select word;

    // Count the matches, which executes the query.
    int wordCount = matchQuery.Count();
    Console.WriteLine($"""{wordCount} occurrences(s) of the search term "{searchTerm}" were found.""");
    /* Output:
       3 occurrences(s) of the search term "data" were found.
    */
    // </CountWordsInAString>
}

static void SortStrings()
{
    // <SortStrings>
    // Create an IEnumerable data source
    string[] scores = File.ReadAllLines("scores.csv");

    // Change this to any value from 0 to 4.
    int sortField = 1;

    Console.WriteLine($"Sorted highest to lowest by field [{sortField}]:");

    // Split the string and sort on field[num]
    var scoreQuery = from line in scores
                     let fields = line.Split(',')
                     orderby fields[sortField] descending
                     select line;

    foreach (string str in scoreQuery)
    {
        Console.WriteLine(str);
    }
    /* Output (if sortField == 1):
       Sorted highest to lowest by field [1]:
        116, 99, 86, 90, 94
        120, 99, 82, 81, 79
        111, 97, 92, 81, 60
        114, 97, 89, 85, 82
        121, 96, 85, 91, 60
        122, 94, 92, 91, 91
        117, 93, 92, 80, 87
        118, 92, 90, 83, 78
        113, 88, 94, 65, 91
        112, 75, 84, 91, 39
        119, 68, 79, 88, 92
        115, 35, 72, 91, 70
     */
    // </SortStrings>
}

static void FindSentences()
{
    // <FindSentences>
    string text = """
    Historically, the world of data and the world of objects 
    have not been well integrated. Programmers work in C# or Visual Basic 
    and also in SQL or XQuery. On the one side are concepts such as classes, 
    objects, fields, inheritance, and .NET APIs. On the other side 
    are tables, columns, rows, nodes, and separate languages for dealing with 
    them. Data types often require translation between the two worlds; there are 
    different standard functions. Because the object world has no notion of query, a 
    query can only be represented as a string without compile-time type checking or 
    IntelliSense support in the IDE. Transferring data from SQL tables or XML trees to 
    objects in memory is often tedious and error-prone.
    """;

    // Split the text block into an array of sentences.
    string[] sentences = text.Split(['.', '?', '!']);

    // Define the search terms. This list could also be dynamically populated at run time.
    string[] wordsToMatch = [ "Historically", "data", "integrated" ];

    // Find sentences that contain all the terms in the wordsToMatch array.
    // Note that the number of terms to match is not specified at compile time.
    char[] separators = ['.', '?', '!', ' ', ';', ':', ','];
    var sentenceQuery = from sentence in sentences
                        let w = sentence.Split(separators,StringSplitOptions.RemoveEmptyEntries)
                        where w.Distinct().Intersect(wordsToMatch).Count() == wordsToMatch.Count()
                        select sentence;

    foreach (string str in sentenceQuery)
    {
        Console.WriteLine(str);
    }
    /* Output:
    Historically, the world of data and the world of objects have not been well integrated
    */
    // </FindSentences>
}

static void QueryWithRegEx()
{
    // <QueryWithRegEx>
    string startFolder = """C:\Program Files\dotnet\sdk""";
    // Or
    // string startFolder = "/usr/local/share/dotnet/sdk";

    // Take a snapshot of the file system.
    var fileList = from file in Directory.GetFiles(startFolder, "*.*", SearchOption.AllDirectories)
                    let fileInfo = new FileInfo(file)
                    select fileInfo;

    // Create the regular expression to find all things "Visual".
    System.Text.RegularExpressions.Regex searchTerm =
        new System.Text.RegularExpressions.Regex(@"microsoft.net.(sdk|workload)");

    // Search the contents of each .htm file.
    // Remove the where clause to find even more matchedValues!
    // This query produces a list of files where a match
    // was found, and a list of the matchedValues in that file.
    // Note: Explicit typing of "Match" in select clause.
    // This is required because MatchCollection is not a
    // generic IEnumerable collection.
    var queryMatchingFiles =
        from file in fileList
        where file.Extension == ".txt"
        let fileText = File.ReadAllText(file.FullName)
        let matches = searchTerm.Matches(fileText)
        where matches.Count > 0
        select new
        {
            name = file.FullName,
            matchedValues = from System.Text.RegularExpressions.Match match in matches
                            select match.Value
        };

    // Execute the query.
    Console.WriteLine($"""The term "{searchTerm}" was found in:""");

    foreach (var v in queryMatchingFiles)
    {
        // Trim the path a bit, then write
        // the file name in which a match was found.
        string s = v.name.Substring(startFolder.Length - 1);
        Console.WriteLine(s);

        // For this file, write out all the matching strings
        foreach (var v2 in v.matchedValues)
        {
            Console.WriteLine($"  {v2}");
        }
    }
    // </QueryWithRegEx>
}
