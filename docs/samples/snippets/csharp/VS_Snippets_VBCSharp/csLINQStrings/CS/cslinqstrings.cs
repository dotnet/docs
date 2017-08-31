
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
namespace LINQStrings
{
    //<snippet1>
    class QueryAString
    {
        static void Main()
        {
            string aString = "ABCDE99F-J74-12-89A";

            // Select only those characters that are numbers
            IEnumerable<char> stringQuery =
              from ch in aString
              where Char.IsDigit(ch)
              select ch;

            // Execute the query
            foreach (char c in stringQuery)
                Console.Write(c + " ");

            // Call the Count method on the existing query.
            int count = stringQuery.Count();
            Console.WriteLine("Count = {0}", count);

            // Select all characters before the first '-'
            IEnumerable<char> stringQuery2 = aString.TakeWhile(c => c != '-');

            // Execute the second query
            foreach (char c in stringQuery2)
                Console.Write(c);

            Console.WriteLine(System.Environment.NewLine + "Press any key to exit");
            Console.ReadKey();
        }
    }
    /* Output:
      Output: 9 9 7 4 1 2 8 9
      Count = 8
      ABCDE99F
    */
    //</snippet1>


    //<snippet2>
    class MergeStrings
    {
        static void Main(string[] args)
        {
            //Put text files in your solution folder
            string[] fileA = System.IO.File.ReadAllLines(@"../../../names1.txt");
            string[] fileB = System.IO.File.ReadAllLines(@"../../../names2.txt");

            //Simple concatenation and sort. Duplicates are preserved.
            IEnumerable<string> concatQuery =
                fileA.Concat(fileB).OrderBy(s => s);

            // Pass the query variable to another function for execution.
            OutputQueryResults(concatQuery, "Simple concatenate and sort. Duplicates are preserved:");

            // Concatenate and remove duplicate names based on
            // default string comparer.
            IEnumerable<string> uniqueNamesQuery =
                fileA.Union(fileB).OrderBy(s => s);
            OutputQueryResults(uniqueNamesQuery, "Union removes duplicate names:");

            // Find the names that occur in both files (based on
            // default string comparer).
            IEnumerable<string> commonNamesQuery =
                fileA.Intersect(fileB);
            OutputQueryResults(commonNamesQuery, "Merge based on intersect:");

            // Find the matching fields in each list. Merge the two 
            // results by using Concat, and then
            // sort using the default string comparer.
            string nameMatch = "Garcia";

            IEnumerable<String> tempQuery1 =
                from name in fileA
                let n = name.Split(',')
                where n[0] == nameMatch
                select name;

            IEnumerable<string> tempQuery2 =
                from name2 in fileB
                let n2 = name2.Split(',')
                where n2[0] == nameMatch
                select name2;

            IEnumerable<string> nameMatchQuery =
                tempQuery1.Concat(tempQuery2).OrderBy(s => s);
            OutputQueryResults(nameMatchQuery, String.Format("Concat based on partial name match \"{0}\":", nameMatch));

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        static void OutputQueryResults(IEnumerable<string> query, string message)
        {
            Console.WriteLine(System.Environment.NewLine + message);
            foreach (string item in query)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("{0} total names in list", query.Count());
        }
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
    //</snippet2>

    //<snippet12>
    class JoinStrings
    {
        static void Main()
        {
            // Join content from dissimilar files that contain
            // related information. File names.csv contains the student
            // name plus an ID number. File scores.csv contains the ID 
            // and a set of four test scores. The following query joins
            // the scores to the student names by using ID as a
            // matching key.

            string[] names = System.IO.File.ReadAllLines(@"../../../names.csv");
            string[] scores = System.IO.File.ReadAllLines(@"../../../scores.csv");
            

            // Name:    Last[0],       First[1],  ID[2]
            //          Omelchenko,    Svetlana,  11
            // Score:   StudentID[0],  Exam1[1]   Exam2[2],  Exam3[3],  Exam4[4]
            //          111,           97,        92,        81,        60

            // This query joins two dissimilar spreadsheets based on common ID value.
            // Multiple from clauses are used instead of a join clause
            // in order to store results of id.Split.
            IEnumerable<string> scoreQuery1 =
                from name in names
                let nameFields = name.Split(',')
                from id in scores
                let scoreFields = id.Split(',')
                where nameFields[2] == scoreFields[0]
                select nameFields[0] + "," + scoreFields[1] + "," + scoreFields[2] 
                       + "," + scoreFields[3] + "," + scoreFields[4];

            // Pass a query variable to a method and execute it
            // in the method. The query itself is unchanged.
            OutputQueryResults(scoreQuery1, "Merge two spreadsheets:");

            // Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        static void OutputQueryResults(IEnumerable<string> query, string message)
        {
            Console.WriteLine(System.Environment.NewLine + message);
            foreach (string item in query)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("{0} total names in list", query.Count());
        }
    }
    /* Output:
    Merge two spreadsheets:
    Adams, 99, 82, 81, 79
    Fakhouri, 99, 86, 90, 94
    Feng, 93, 92, 80, 87
    Garcia, 97, 89, 85, 82
    Garcia, 35, 72, 91, 70
    Garcia, 92, 90, 83, 78
    Mortensen, 88, 94, 65, 91
    O'Donnell, 75, 84, 91, 39
    Omelchenko, 97, 92, 81, 60
    Tucker, 68, 79, 88, 92
    Tucker, 94, 92, 91, 91
    Zabokritski, 96, 85, 91, 60
    12 total names in list
     */
    //</snippet12>

    //<snippet3>
    class CompareLists
    {        
        static void Main()
        {
            // Create the IEnumerable data sources.
            string[] names1 = System.IO.File.ReadAllLines(@"../../../names1.txt");
            string[] names2 = System.IO.File.ReadAllLines(@"../../../names2.txt");

            // Create the query. Note that method syntax must be used here.
            IEnumerable<string> differenceQuery =
              names1.Except(names2);

            // Execute the query.
            Console.WriteLine("The following lines are in names1.txt but not names2.txt");
            foreach (string s in differenceQuery)
                Console.WriteLine(s);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
    /* Output:
         The following lines are in names1.txt but not names2.txt
        Potra, Cristina
        Noriega, Fabricio
        Aw, Kam Foo
        Toyoshima, Tim
        Guy, Wey Yuan
        Garcia, Debra
         */
        
    //</snippet3>


    //<snippet4>
    class CountWords
    {
        static void Main()
        {
            string text = @"Historically, the world of data and the world of objects" +
              @" have not been well integrated. Programmers work in C# or Visual Basic" +
              @" and also in SQL or XQuery. On the one side are concepts such as classes," +
              @" objects, fields, inheritance, and .NET Framework APIs. On the other side" +
              @" are tables, columns, rows, nodes, and separate languages for dealing with" +
              @" them. Data types often require translation between the two worlds; there are" +
              @" different standard functions. Because the object world has no notion of query, a" +
              @" query can only be represented as a string without compile-time type checking or" +
              @" IntelliSense support in the IDE. Transferring data from SQL tables or XML trees to" +
              @" objects in memory is often tedious and error-prone.";

            string searchTerm = "data";

            //Convert the string into an array of words
            string[] source = text.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

            // Create the query.  Use ToLowerInvariant to match "data" and "Data" 
            var matchQuery = from word in source
                             where word.ToLowerInvariant() == searchTerm.ToLowerInvariant()
                             select word;

            // Count the matches, which executes the query.
            int wordCount = matchQuery.Count();
            Console.WriteLine("{0} occurrences(s) of the search term \"{1}\" were found.", wordCount, searchTerm);

            // Keep console window open in debug mode
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
    /* Output:
       3 occurrences(s) of the search term "data" were found.
    */
    //</snippet4>



    class AlphabetizeLists
    {
        static void Main(string[] args)
        {

            //<snippet5>
            List<string> names = new List<string>();
            using (System.IO.StreamReader sr = new System.IO.StreamReader(@"C:\names.txt"))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    names.Add(s);
                }
            }
            //</snippet5>

            //<snippet6>
            IEnumerable<String> nameQuery =
                from name in names
                orderby name ascending
                select name;
            //</snippet6>

            //<snippet7>
            foreach (string str in nameQuery)
            {
                Console.WriteLine(str);
            }
            //</snippet7>

            //<snippet8>
            IEnumerable<String> nameQuery2 =
                from name in names
                let n = name.Split(' ')
                orderby n[1] ascending
                select name;
            //</snippet8>
            
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }


    }
    //<snippet9>
    class CSVFiles
    {
        static void Main(string[] args)
        {
            // Create the IEnumerable data source
            string[] lines = System.IO.File.ReadAllLines(@"../../../spreadsheet1.csv");

            // Create the query. Put field 2 first, then
            // reverse and combine fields 0 and 1 from the old field
            IEnumerable<string> query =
                from line in lines
                let x = line.Split(',')
                orderby x[2]
                select x[2] + ", " + (x[1] + " " + x[0]);

            // Execute the query and write out the new file. Note that WriteAllLines
            // takes a string[], so ToArray is called on the query.
            System.IO.File.WriteAllLines(@"../../../spreadsheet2.csv", query.ToArray());

            Console.WriteLine("Spreadsheet2.csv written to disk. Press any key to exit");
            Console.ReadKey();
        }
    }
    /* Output to spreadsheet2.csv:
    111, Svetlana Omelchenko
    112, Claire O'Donnell
    113, Sven Mortensen
    114, Cesar Garcia
    115, Debra Garcia
    116, Fadi Fakhouri
    117, Hanying Feng
    118, Hugo Garcia
    119, Lance Tucker
    120, Terry Adams
    121, Eugene Zabokritski
    122, Michael Tucker
     */
    //</snippet9>

    //<snippet10>
    class FindSentences
    {
        static void Main()
        {
            string text = @"Historically, the world of data and the world of objects " +
            @"have not been well integrated. Programmers work in C# or Visual Basic " +
            @"and also in SQL or XQuery. On the one side are concepts such as classes, " +
            @"objects, fields, inheritance, and .NET Framework APIs. On the other side " +
            @"are tables, columns, rows, nodes, and separate languages for dealing with " +
            @"them. Data types often require translation between the two worlds; there are " +
            @"different standard functions. Because the object world has no notion of query, a " +
            @"query can only be represented as a string without compile-time type checking or " +
            @"IntelliSense support in the IDE. Transferring data from SQL tables or XML trees to " +
            @"objects in memory is often tedious and error-prone.";

            // Split the text block into an array of sentences.
            string[] sentences = text.Split(new char[] { '.', '?', '!' });

            // Define the search terms. This list could also be dynamically populated at runtime.
            string[] wordsToMatch = { "Historically", "data", "integrated" };

            // Find sentences that contain all the terms in the wordsToMatch array.
            // Note that the number of terms to match is not specified at compile time.
            var sentenceQuery = from sentence in sentences
                                let w = sentence.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' },
                                                        StringSplitOptions.RemoveEmptyEntries)
                                where w.Distinct().Intersect(wordsToMatch).Count() == wordsToMatch.Count()
                                select sentence;

            // Execute the query. Note that you can explicitly type
            // the iteration variable here even though sentenceQuery
            // was implicitly typed. 
            foreach (string str in sentenceQuery)
            {
                Console.WriteLine(str);
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
    /* Output:
    Historically, the world of data and the world of objects have not been well integrated
    */
    //</snippet10>

    //<snippet11>
    class SplitWithGroups
    {
        static void Main()
        {
            string[] fileA = System.IO.File.ReadAllLines(@"../../../names1.txt");
            string[] fileB = System.IO.File.ReadAllLines(@"../../../names2.txt");

            // Concatenate and remove duplicate names based on
            // default string comparer
            var mergeQuery = fileA.Union(fileB);

            // Group the names by the first letter in the last name.
            var groupQuery = from name in mergeQuery
                             let n = name.Split(',')
                             group name by n[0][0] into g
                             orderby g.Key
                             select g;

            // Create a new file for each group that was created
            // Note that nested foreach loops are required to access
            // individual items with each group.
            foreach (var g in groupQuery)
            {
                // Create the new file name.
                string fileName = @"../../../testFile_" + g.Key + ".txt";

                // Output to display.
                Console.WriteLine(g.Key);

                // Write file.
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName))
                {
                    foreach (var item in g)
                    {
                        sw.WriteLine(item);
                        // Output to console for example purposes.
                        Console.WriteLine("   {0}", item);
                    }
                }
            }
            // Keep console window open in debug mode.
            Console.WriteLine("Files have been written. Press any key to exit");
            Console.ReadKey();
        }
    }
    /* Output: 
        A
           Aw, Kam Foo
        B
           Bankov, Peter
           Beebe, Ann
        E
           El Yassir, Mehdi
        G
           Garcia, Hugo
           Guy, Wey Yuan
           Garcia, Debra
           Gilchrist, Beth
           Giakoumakis, Leo
        H
           Holm, Michael
        L
           Liu, Jinghao
        M
           Myrcha, Jacek
           McLin, Nkenge
        N
           Noriega, Fabricio
        P
           Potra, Cristina
        T
           Toyoshima, Tim
     */
    //</snippet11>

    //<snippet13>
    public class SortLines
    {
        static void Main()
        {
            // Create an IEnumerable data source
            string[] scores = System.IO.File.ReadAllLines(@"../../../scores.csv");

            // Change this to any value from 0 to 4.
            int sortField = 1;

            Console.WriteLine("Sorted highest to lowest by field [{0}]:", sortField);

            // Demonstrates how to return query from a method.
            // The query is executed here.
            foreach (string str in RunQuery(scores, sortField))
            {
                Console.WriteLine(str);
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        // Returns the query variable, not query results!
        static IEnumerable<string> RunQuery(IEnumerable<string> source, int num)
        {
            // Split the string and sort on field[num]
            var scoreQuery = from line in source
                             let fields = line.Split(',')
                             orderby fields[num] descending
                             select line;

            return scoreQuery;
        }
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
    //</snippet13>
}

//Now To: Combine LINQ With Regular Expressions
namespace RegEx
{
    //<snippet14>
    class QueryWithRegEx
    {
        public static void Main()
        {
            // Modify this path as necessary so that it accesses your version of Visual Studio.
            string startFolder = @"c:\program files\Microsoft Visual Studio 9.0\";
            // One of the following paths may be more appropriate on your computer.
            //string startFolder = @"c:\program files (x86)\Microsoft Visual Studio 9.0\";
            //string startFolder = @"c:\program files\Microsoft Visual Studio 10.0\";
            //string startFolder = @"c:\program files (x86)\Microsoft Visual Studio 10.0\";

            // Take a snapshot of the file system.
            IEnumerable<System.IO.FileInfo> fileList = GetFiles(startFolder);

            // Create the regular expression to find all things "Visual".
            System.Text.RegularExpressions.Regex searchTerm =
                new System.Text.RegularExpressions.Regex(@"Visual (Basic|C#|C\+\+|J#|SourceSafe|Studio)");

            // Search the contents of each .htm file.
            // Remove the where clause to find even more matchedValues!
            // This query produces a list of files where a match
            // was found, and a list of the matchedValues in that file.
            // Note: Explicit typing of "Match" in select clause.
            // This is required because MatchCollection is not a 
            // generic IEnumerable collection.
            var queryMatchingFiles =
                from file in fileList
                where file.Extension == ".htm"
                let fileText = System.IO.File.ReadAllText(file.FullName)
                let matches = searchTerm.Matches(fileText)
                where matches.Count > 0
                select new
                {
                    name = file.FullName,
                    matchedValues = from System.Text.RegularExpressions.Match match in matches
                                    select match.Value
                };

            // Execute the query.
            Console.WriteLine("The term \"{0}\" was found in:", searchTerm.ToString());

            foreach (var v in queryMatchingFiles)
            {
                // Trim the path a bit, then write 
                // the file name in which a match was found.
                string s = v.name.Substring(startFolder.Length - 1);
                Console.WriteLine(s);

                // For this file, write out all the matching strings
                foreach (var v2 in v.matchedValues)
                {
                    Console.WriteLine("  " + v2);
                }
            }

            // Keep the console window open in debug mode
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        // This method assumes that the application has discovery 
        // permissions for all folders under the specified path.
        static IEnumerable<System.IO.FileInfo> GetFiles(string path)
        {
            if (!System.IO.Directory.Exists(path))
                throw new System.IO.DirectoryNotFoundException();

            string[] fileNames = null;
            List<System.IO.FileInfo> files = new List<System.IO.FileInfo>();

            fileNames = System.IO.Directory.GetFiles(path, "*.*", System.IO.SearchOption.AllDirectories);
            foreach (string name in fileNames)
            {
                files.Add(new System.IO.FileInfo(name));
            }
            return files;
        }
    }
    //</snippet14>

    //<snippet15>
    class SumColumns
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"../../../scores.csv");

            // Specifies the column to compute.
            int exam = 3;

            // Spreadsheet format:
            // Student ID    Exam#1  Exam#2  Exam#3  Exam#4
            // 111,          97,     92,     81,     60

            // Add one to exam to skip over the first column,
            // which holds the student ID.
            SingleColumn(lines, exam + 1);
            Console.WriteLine();
            MultiColumns(lines);

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        static void SingleColumn(IEnumerable<string> strs, int examNum)
        {
            Console.WriteLine("Single Column Query:");

            // Parameter examNum specifies the column to 
            // run the calculations on. This value could be
            // passed in dynamically at runtime.             

            // Variable columnQuery is an IEnumerable<int>.
            // The following query performs two steps:
            // 1) use Split to break each row (a string) into an array 
            //    of strings, 
            // 2) convert the element at position examNum to an int
            //    and select it.
            var columnQuery =
                from line in strs
                let elements = line.Split(',')
                select Convert.ToInt32(elements[examNum]);

            // Execute the query and cache the results to improve
            // performance. This is helpful only with very large files.
            var results = columnQuery.ToList();

            // Perform aggregate calculations Average, Max, and
            // Min on the column specified by examNum.
            double average = results.Average();
            int max = results.Max();
            int min = results.Min();

            Console.WriteLine("Exam #{0}: Average:{1:##.##} High Score:{2} Low Score:{3}",
                     examNum, average, max, min);
        }

        static void MultiColumns(IEnumerable<string> strs)
        {
            Console.WriteLine("Multi Column Query:");

            // Create a query, multiColQuery. Explicit typing is used
            // to make clear that, when executed, multiColQuery produces 
            // nested sequences. However, you get the same results by
            // using 'var'.

            // The multiColQuery query performs the following steps:
            // 1) use Split to break each row (a string) into an array 
            //    of strings, 
            // 2) use Skip to skip the "Student ID" column, and store the 
            //    rest of the row in scores.
            // 3) convert each score in the current row from a string to
            //    an int, and select that entire sequence as one row 
            //    in the results.
            IEnumerable<IEnumerable<int>> multiColQuery =
                from line in strs
                let elements = line.Split(',')
                let scores = elements.Skip(1)
                select (from str in scores
                        select Convert.ToInt32(str));

            // Execute the query and cache the results to improve
            // performance. 
            // ToArray could be used instead of ToList.
            var results = multiColQuery.ToList();

            // Find out how many columns you have in results.
            int columnCount = results[0].Count();

            // Perform aggregate calculations Average, Max, and
            // Min on each column.            
            // Perform one iteration of the loop for each column 
            // of scores.
            // You can use a for loop instead of a foreach loop 
            // because you already executed the multiColQuery 
            // query by calling ToList.
            for (int column = 0; column < columnCount; column++)
            {
                var results2 = from row in results
                               select row.ElementAt(column);
                double average = results2.Average();
                int max = results2.Max();
                int min = results2.Min();

                // Add one to column because the first exam is Exam #1,
                // not Exam #0.
                Console.WriteLine("Exam #{0} Average: {1:##.##} High Score: {2} Low Score: {3}",
                              column + 1, average, max, min);
            }
        }
    }
    /* Output:
        Single Column Query:
        Exam #4: Average:76.92 High Score:94 Low Score:39

        Multi Column Query:
        Exam #1 Average: 86.08 High Score: 99 Low Score: 35
        Exam #2 Average: 86.42 High Score: 94 Low Score: 72
        Exam #3 Average: 84.75 High Score: 91 Low Score: 65
        Exam #4 Average: 76.92 High Score: 94 Low Score: 39
     */
    //</snippet15>

    //<snippet16>
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public List<int> ExamScores { get; set; }
    }

    class PopulateCollection
    {
        static void Main()
        {
            // These data files are defined in How to: Join Content from 
            // Dissimilar Files (LINQ).

            // Each line of names.csv consists of a last name, a first name, and an
            // ID number, separated by commas. For example, Omelchenko,Svetlana,111
            string[] names = System.IO.File.ReadAllLines(@"../../../names.csv");

            // Each line of scores.csv consists of an ID number and four test 
            // scores, separated by commas. For example, 111, 97, 92, 81, 60
            string[] scores = System.IO.File.ReadAllLines(@"../../../scores.csv");

            // Merge the data sources using a named type.
            // var could be used instead of an explicit type. Note the dynamic
            // creation of a list of ints for the ExamScores member. We skip 
            // the first item in the split string because it is the student ID, 
            // not an exam score.
            IEnumerable<Student> queryNamesScores =
                from nameLine in names
                let splitName = nameLine.Split(',')
                from scoreLine in scores
                let splitScoreLine = scoreLine.Split(',')
                where splitName[2] == splitScoreLine[0]
                select new Student()
                {
                    FirstName = splitName[0],
                    LastName = splitName[1],
                    ID = Convert.ToInt32(splitName[2]),
                    ExamScores = (from scoreAsText in splitScoreLine.Skip(1)
                                  select Convert.ToInt32(scoreAsText)).
                                  ToList()
                };

            // Optional. Store the newly created student objects in memory
            // for faster access in future queries. This could be useful with
            // very large data files.
            List<Student> students = queryNamesScores.ToList();

            // Display each student's name and exam score average.
            foreach (var student in students)
            {
                Console.WriteLine("The average score of {0} {1} is {2}.",
                    student.FirstName, student.LastName,
                    student.ExamScores.Average());
            }

            //Keep console window open in debug mode
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
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
    //</snippet16>        

    // For the anonymous type
    class PopulateCollections2
    {
        static void Main()
        {
            // These data files are defined in How to: Join Content from Dissimilar Files (LINQ) 
            string[] names = System.IO.File.ReadAllLines(@"../../../names.csv");
            string[] scores = System.IO.File.ReadAllLines(@"../../../scores.csv");

            //<snippet17>
            // Merge the data sources by using an anonymous type.
            // Note the dynamic creation of a list of ints for the
            // ExamScores member. We skip 1 because the first string
            // in the array is the student ID, not an exam score.
            var queryNamesScores2 =
                from nameLine in names
                let splitName = nameLine.Split(',')
                from scoreLine in scores
                let splitScoreLine = scoreLine.Split(',')
                where splitName[2] == splitScoreLine[0]
                select new
                {
                    First = splitName[0],
                    Last = splitName[1],
                    ExamScores = (from scoreAsText in splitScoreLine.Skip(1)
                                  select Convert.ToInt32(scoreAsText))
                                  .ToList()
                };

            // Display each student's name and exam score average.
            foreach (var student in queryNamesScores2)
            {
                Console.WriteLine("The average score of {0} {1} is {2}.",
                    student.First, student.Last, student.ExamScores.Average());
            }
            //</snippet17>
            //Keep console window open in debug mode
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

    //not used. moved example into PopulateCollections2
    class MergeCSVData2
    {
        static void Method2(List<string> names, List<int[]> scores)
        {
            
            //Merge the data sources using an anonymous type
            var queryNamesWithScores =
                from name in names
                from score in scores
                where score[0].ToString() == name.Substring(name.Length - 3, 3)
                select new { Name = name, TestScores = score.Skip(1).ToList() };

            foreach (var item in queryNamesWithScores)
            {
                Console.WriteLine("Name and ID: {0}, Average Score: {1}", item.Name, item.TestScores.Average());
            }
            

            //Keep console window open in debug mode
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    

}
    // This doesn't seem to be used anywhere
    public class FileList
    {
        static void Main(string[] args)
        {
            //FileList2 fileList = new FileList2();
            //List<FileInfo> list = fileList.GetFiles(args[0]);
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        public static List<System.IO.FileInfo> GetFiles(string root)
        {
            // A list to store each file. An array, dictionary, 
            // or tree could also be used. 
            List<System.IO.FileInfo> files = new List<System.IO.FileInfo>();

            // Data structure to hold names of subfolders to be
            // examined for files.
            Stack<string> dirs = new Stack<string>(20);

            if (!System.IO.Directory.Exists(root))
                throw new ArgumentException();
            dirs.Push(root);


            while (dirs.Count > 0)
            {
                string s = dirs.Pop();
                string[] newDirs;
                try
                {
                    newDirs = System.IO.Directory.GetDirectories(s);
                }
                // We expect to see Access Denied because we do not have
                // discovery permission on some system folders. 
                // It is acceptable to simply ignore those folders and continue
                // enumerating the rest of them. It is also possible to raise a 
                // DirectoryNotFound exception, so we handle that similarly. The choice
                // of which exceptions to catch depends on how much you
                // know with certainty about the systems on which this code will run.
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (System.IO.DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                // Perform the required action on each file here.
                // Modify this block to perform your required task.
                foreach (string file in System.IO.Directory.GetFiles(s))
                {
                    try
                    {
                        // Add the file to the list 
                        System.IO.FileInfo fi = new System.IO.FileInfo(file);
                        files.Add(fi);
                    }
                    catch (System.IO.FileNotFoundException e)
                    {
                        // If file was deleted by a separate thread
                        // since our call to GetFiles()
                        // then just continue.
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }

                foreach (string str in newDirs)
                    dirs.Push(str);

            }

            return files;
        }
    }
    public class StudentClass
    {
        #region data
        protected enum GradeLevel { FirstYear = 1, SecondYear, ThirdYear, FourthYear };
        protected class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int ID { get; set; }
            public GradeLevel Year;
            public List<int> ExamScores;
        }

        protected static List<Student> students = new List<Student>
        {
            new Student {FirstName = "Terry", LastName = "Adams", ID = 120, Year = GradeLevel.SecondYear, ExamScores = new List<int>{ 99, 82, 81, 79}},
            new Student {FirstName = "Fadi", LastName = "Fakhouri", ID = 116, Year = GradeLevel.ThirdYear,ExamScores = new List<int>{ 99, 86, 90, 94}},
            new Student {FirstName = "Hanying", LastName = "Feng", ID = 117, Year = GradeLevel.FirstYear, ExamScores = new List<int>{ 93, 92, 80, 87}},
            new Student {FirstName = "Cesar", LastName = "Garcia", ID = 114, Year = GradeLevel.FourthYear,ExamScores = new List<int>{ 97, 89, 85, 82}},
            new Student {FirstName = "Debra", LastName = "Garcia", ID = 115, Year = GradeLevel.ThirdYear, ExamScores = new List<int>{ 35, 72, 91, 70}},
            new Student {FirstName = "Hugo", LastName = "Garcia", ID = 118, Year = GradeLevel.SecondYear, ExamScores = new List<int>{ 92, 90, 83, 78}},
            new Student {FirstName = "Sven", LastName = "Mortensen", ID = 113, Year = GradeLevel.FirstYear, ExamScores = new List<int>{ 88, 94, 65, 91}},
            new Student {FirstName = "Claire", LastName = "O'Donnell", ID = 112, Year = GradeLevel.FourthYear, ExamScores = new List<int>{ 75, 84, 91, 39}},
            new Student {FirstName = "Svetlana", LastName = "Omelchenko", ID = 111, Year = GradeLevel.SecondYear, ExamScores = new List<int>{ 97, 92, 81, 60}},
            new Student {FirstName = "Lance", LastName = "Tucker", ID = 119, Year = GradeLevel.ThirdYear, ExamScores = new List<int>{ 68, 79, 88, 92}},
            new Student {FirstName = "Michael", LastName = "Tucker", ID = 122, Year = GradeLevel.FirstYear, ExamScores = new List<int>{ 94, 92, 91, 91}},
            new Student {FirstName = "Eugene", LastName = "Zabokritski", ID = 121, Year = GradeLevel.FourthYear, ExamScores = new List<int>{ 96, 85, 91, 60}}
        };
        #endregion

        //Helper method
        protected static int GetPercentile(Student s)
        {
            double avg = s.ExamScores.Average();
            return avg > 0 ? (int)avg / 10 : 0;
        }

        

        static void QueryHighScores(int exam, int score)
        {
            var highScores = from student in students
                             where student.ExamScores[exam] > score
                             select new { Name = student.FirstName, Score = student.ExamScores[exam] };

            foreach (var item in highScores)
            {
                Console.WriteLine("{0,-15}{1}", item.Name, item.Score);
            }
        }
    }
