Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
'Imports System.Text

Module Module1

    ' How to: Query for Characters in a String
    '<snippet1>
    Class QueryAString

        Shared Sub Main()

            ' A string is an IEnumerable data source.
            Dim aString As String = "ABCDE99F-J74-12-89A"

            ' Select only those characters that are numbers
            Dim stringQuery = From ch In aString 
                              Where Char.IsDigit(ch) 
                              Select ch
            ' Execute the query
            For Each c As Char In stringQuery
                Console.Write(c & " ")
            Next

            ' Call the Count method on the existing query.
            Dim count As Integer = stringQuery.Count()
            Console.WriteLine(System.Environment.NewLine & "Count = " & count)

            ' Select all characters before the first '-'
            Dim stringQuery2 = aString.TakeWhile(Function(c) c <> "-")

            ' Execute the second query
            For Each ch In stringQuery2
                Console.Write(ch)
            Next

            Console.WriteLine(System.Environment.NewLine & "Press any key to exit")
            Console.ReadKey()
        End Sub
    End Class
    ' Output:
    ' 9 9 7 4 1 2 8 9 
    ' Count = 8
    ' ABCDE99F
    '</snippet1>

    '<snippet2>
    Class ConcatenateStrings
        Shared Sub Main()

            ' Create the IEnumerable data sources.
            Dim fileA As String() = System.IO.File.ReadAllLines("../../../names1.txt")
            Dim fileB As String() = System.IO.File.ReadAllLines("../../../names2.txt")

            ' Simple concatenation and sort.
            Dim concatQuery = fileA.Concat(fileB).OrderBy(Function(name) name)

            ' Pass the query variable to another function for execution
            OutputQueryResults(concatQuery, "Simple concatenation and sort. Duplicates are preserved:")

            ' New query. Concatenate files and remove duplicates
            Dim uniqueNamesQuery = fileA.Union(fileB).OrderBy(Function(name) name)
            OutputQueryResults(uniqueNamesQuery, "Union removes duplicate names:")

            ' New query. Find the names that occur in both files.
            Dim commonNamesQuery = fileA.Intersect(fileB)
            OutputQueryResults(commonNamesQuery, "Merge based on intersect: ")

            ' New query in three steps for better readability 
            ' First filter each list separately

            Dim nameToSearch As String = "Garcia"
            Dim mergeQueryA As IEnumerable(Of String) = From name In fileA 
                              Let n = name.Split(New Char() {","}) 
                              Where n(0) = nameToSearch 
                              Select name

            Dim mergeQueryB = From name In fileB 
                              Let n = name.Split(New Char() {","}) 
                              Where n(0) = nameToSearch 
                              Select name

            ' Create a new query to concatenate and sort results. Duplicates are removed in Union.
            ' Note that none of the queries actually executed until the call to OutputQueryResults.
            Dim mergeSortQuery = mergeQueryA.Union(mergeQueryB).OrderBy(Function(str) str)

            ' Now execute mergeSortQuery
            OutputQueryResults(mergeSortQuery, "Concat based on partial name match """ & nameToSearch & """ from each list:")

            ' Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit.")
            Console.ReadKey()

        End Sub

        Shared Sub OutputQueryResults(ByVal query As IEnumerable(Of String), ByVal message As String)

            Console.WriteLine(System.Environment.NewLine & message)
            For Each item As String In query
                Console.WriteLine(item)
            Next
            Console.WriteLine(query.Count & " total names in list")

        End Sub
    End Class
    ' Output:

    ' Simple concatenation and sort. Duplicates are preserved:
    ' Aw, Kam Foo
    ' Bankov, Peter
    ' Bankov, Peter
    ' Beebe, Ann
    ' Beebe, Ann
    ' El Yassir, Mehdi
    ' Garcia, Debra
    ' Garcia, Hugo
    ' Garcia, Hugo
    ' Giakoumakis, Leo
    ' Gilchrist, Beth
    ' Guy, Wey Yuan
    ' Holm, Michael
    ' Holm, Michael
    ' Liu, Jinghao
    ' McLin, Nkenge
    ' Myrcha, Jacek
    ' Noriega, Fabricio
    ' Potra, Cristina
    ' Toyoshima, Tim
    ' 20 total names in list

    ' Union removes duplicate names:
    ' Aw, Kam Foo
    ' Bankov, Peter
    ' Beebe, Ann
    ' El Yassir, Mehdi
    ' Garcia, Debra
    ' Garcia, Hugo
    ' Giakoumakis, Leo
    ' Gilchrist, Beth
    ' Guy, Wey Yuan
    ' Holm, Michael
    ' Liu, Jinghao
    ' McLin, Nkenge
    ' Myrcha, Jacek
    ' Noriega, Fabricio
    ' Potra, Cristina
    ' Toyoshima, Tim
    ' 16 total names in list

    ' Merge based on intersect:
    ' Bankov, Peter
    ' Holm, Michael
    ' Garcia, Hugo
    ' Beebe, Ann
    ' 4 total names in list

    ' Concat based on partial name match "Garcia" from each list:
    ' Garcia, Debra
    ' Garcia, Hugo
    ' 2 total names in list
    '</snippet2>


    '<snippet3>
    Class CompareLists

        Shared Sub Main()

            ' Create the IEnumerable data sources.
            Dim names1 As String() = System.IO.File.ReadAllLines("../../../names1.txt")
            Dim names2 As String() = System.IO.File.ReadAllLines("../../../names2.txt")

            ' Create the query. Note that method syntax must be used here.
            Dim differenceQuery = names1.Except(names2)
            Console.WriteLine("The following lines are in names1.txt but not names2.txt")

            ' Execute the query.
            For Each name As String In differenceQuery
                Console.WriteLine(name)
            Next

            ' Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit.")
            Console.ReadKey()
        End Sub
    End Class
    ' Output:
    ' The following lines are in names1.txt but not names2.txt
    ' Potra, Cristina
    ' Noriega, Fabricio
    ' Aw, Kam Foo
    ' Toyoshima, Tim
    ' Guy, Wey Yuan
    ' Garcia, Debra
    '</snippet3>

    '<snippet4>
    Class CountWords

        Shared Sub Main()

            Dim text As String = "Historically, the world of data and the world of objects" & 
                      " have not been well integrated. Programmers work in C# or Visual Basic" & 
                      " and also in SQL or XQuery. On the one side are concepts such as classes," & 
                      " objects, fields, inheritance, and .NET Framework APIs. On the other side" & 
                      " are tables, columns, rows, nodes, and separate languages for dealing with" & 
                      " them. Data types often require translation between the two worlds; there are" & 
                      " different standard functions. Because the object world has no notion of query, a" & 
                      " query can only be represented as a string without compile-time type checking or" & 
                      " IntelliSense support in the IDE. Transferring data from SQL tables or XML trees to" & 
                      " objects in memory is often tedious and error-prone."

            Dim searchTerm As String = "data"

            ' Convert the string into an array of words.
            Dim dataSource As String() = text.Split(New Char() {" ", ",", ".", ";", ":"}, 
                                                     StringSplitOptions.RemoveEmptyEntries)

            ' Create and execute the query. It executes immediately 
            ' because a singleton value is produced.
            ' Use ToLower to match "data" and "Data" 
            Dim matchQuery = From word In dataSource 
                          Where word.ToLowerInvariant() = searchTerm.ToLowerInvariant() 
                          Select word

            ' Count the matches.
            Dim count As Integer = matchQuery.Count()
            Console.WriteLine(count & " occurrence(s) of the search term """ & 
                              searchTerm & """ were found.")

            ' Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit.")
            Console.ReadKey()
        End Sub
    End Class
    ' Output:
    ' 3 occurrence(s) of the search term "data" were found.
    '</snippet4>

    ' This snippet is not used because we have another example that shows how to find
    ' a sentences that contain specified keywords.
    Class UnusedSnippet
        Sub FindTerms()

            Dim text As String = "Historically, the world of data and the world of objects" & 
                      " have not been well integrated. Programmers work in C# or Visual Basic" & 
                      " and also in SQL or XQuery."

            Dim count As Int32 = 0
            Dim searchTerm As String = "data"

            ' Convert the string into an array of sentences.
            Dim dataSource2 As String() = text.Split(New Char() {".", "?", "!"})

            ' Find all sentences that contain searchTerm and also "SQL" or "XML."
            Dim searchTerm2 As String = "XML"
            Dim searchTerm3 As String = "SQL"

            Dim sentenceQuery = From sentence In dataSource2 
                                Let s = sentence.ToLowerInvariant() 
                                Where s.Contains(searchTerm.ToLowerInvariant()) And 
                                  (s.Contains(searchTerm2.ToLowerInvariant()) Or
                                   s.Contains(searchTerm3.ToLowerInvariant())) 
                                Select sentence

            ' Count the matches
            count = sentenceQuery.Count()
            Console.WriteLine(count & " occurrence(s) of the search term """ & searchTerm & 
                              """ were found in the same sentence with """ & searchTerm2 & 
                              """ or """ & searchTerm3 & """")
        End Sub

    End Class 'class UnusedSnippet


    Class AlphabetizeLists

        Shared Sub Main()
            '<snippet5>
            Dim names As New List(Of String)
            Dim sr As New System.IO.StreamReader("../../names.txt")

            Do While sr.Peek >= 0
                names.Add(sr.ReadLine())
            Loop
            sr.Close()
            '</snippet5>

            '<snippet6>
            Dim nameQuery = From name In names 
                            Order By name Ascending 
                            Select name
            '</snippet6>

            '<snippet7>
            For Each str As String In nameQuery
                Console.WriteLine(str)
            Next
            '</snippet7>

            '<snippet8>
            Dim nameQuery2 = From name In names 
                             Let n = name.Split(New Char() {" "}) 
                             Order By n(1) Ascending 
                             Select name
            '</snippet8>
        End Sub
    End Class

    '<snippet9>
    Class CSVFiles

        Shared Sub Main()

            ' Create the IEnumerable data source.
            Dim lines As String() = System.IO.File.ReadAllLines("../../../spreadsheet1.csv")

            ' Execute the query. Put field 2 first, then
            ' reverse and combine fields 0 and 1 from the old field
            Dim lineQuery = From line In lines 
                            Let x = line.Split(New Char() {","}) 
                            Order By x(2) 
                            Select x(2) & ", " & (x(1) & " " & x(0))

            ' Execute the query and write out the new file. Note that WriteAllLines
            ' takes a string array, so ToArray is called on the query.
            System.IO.File.WriteAllLines("../../../spreadsheet2.csv", lineQuery.ToArray())

            ' Keep console window open in debug mode.
            Console.WriteLine("Spreadsheet2.csv written to disk. Press any key to exit")
            Console.ReadKey()
        End Sub
    End Class
    ' Output to spreadsheet2.csv:
    ' 111, Svetlana Omelchenko
    ' 112, Claire O'Donnell
    ' 113, Sven Mortensen
    ' 114, Cesar Garcia
    ' 115, Debra Garcia
    ' 116, Fadi Fakhouri
    ' 117, Hanying Feng
    ' 118, Hugo Garcia
    ' 119, Lance Tucker
    ' 120, Terry Adams
    ' 121, Eugene Zabokritski
    ' 122, Michael Tucker
    '</snippet9>

    '<snippet10>
    Class FindSentences

        Shared Sub Main()
            Dim text As String = "Historically, the world of data and the world of objects " & 
            "have not been well integrated. Programmers work in C# or Visual Basic " & 
            "and also in SQL or XQuery. On the one side are concepts such as classes, " & 
            "objects, fields, inheritance, and .NET Framework APIs. On the other side " & 
            "are tables, columns, rows, nodes, and separate languages for dealing with " & 
            "them. Data types often require translation between the two worlds; there are " & 
            "different standard functions. Because the object world has no notion of query, a " & 
            "query can only be represented as a string without compile-time type checking or " & 
            "IntelliSense support in the IDE. Transferring data from SQL tables or XML trees to " & 
            "objects in memory is often tedious and error-prone."

            ' Split the text block into an array of sentences.
            Dim sentences As String() = text.Split(New Char() {".", "?", "!"})

            ' Define the search terms. This list could also be dynamically populated at runtime
            Dim wordsToMatch As String() = {"Historically", "data", "integrated"}

            ' Find sentences that contain all the terms in the wordsToMatch array
            ' Note that the number of terms to match is not specified at compile time
            Dim sentenceQuery = From sentence In sentences 
                                Let w = sentence.Split(New Char() {" ", ",", ".", ";", ":"}, 
                                                       StringSplitOptions.RemoveEmptyEntries) 
                                Where w.Distinct().Intersect(wordsToMatch).Count = wordsToMatch.Count() 
                                Select sentence

            ' Execute the query
            For Each str As String In sentenceQuery
                Console.WriteLine(str)
            Next

            ' Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit.")
            Console.ReadKey()
        End Sub
        
    End Class
    ' Output:
    ' Historically, the world of data and the world of objects have not been well integrated
    '</snippet10>

    '<snippet11>
    Class SplitWithGroups

        Shared Sub Main()

            Dim fileA As String() = System.IO.File.ReadAllLines("../../../names1.txt")
            Dim fileB As String() = System.IO.File.ReadAllLines("../../../names2.txt")

            ' Concatenate and remove duplicate names based on
            Dim mergeQuery As IEnumerable(Of String) = fileA.Union(fileB)

            ' Group the names by the first letter in the last name
            Dim groupQuery = From name In mergeQuery 
                         Let n = name.Split(New Char() {","}) 
                         Order By n(0) 
                         Group By groupKey = n(0)(0) 
                         Into groupName = Group

            ' Create a new file for each group that was created
            ' Note that nested foreach loops are required to access
            ' individual items with each group.
            For Each gGroup In groupQuery
                Dim fileName As String = "..'..'..'testFile_" & gGroup.groupKey & ".txt"
                Dim sw As New System.IO.StreamWriter(fileName)
                Console.WriteLine(gGroup.groupKey)
                For Each item In gGroup.groupName
                    Console.WriteLine("   " & item.name)
                    sw.WriteLine(item.name)
                Next
                sw.Close()
            Next

            ' Keep console window open in debug mode.
            Console.WriteLine("Files have been written. Press any key to exit.")
            Console.ReadKey()

        End Sub
    End Class
    ' Console Output:
    ' A
    '    Aw, Kam Foo
    ' B
    '    Bankov, Peter
    '    Beebe, Ann
    ' E
    '    El Yassir, Mehdi
    ' G
    '    Garcia, Hugo
    '    Garcia, Debra
    '    Giakoumakis, Leo
    '    Gilchrist, Beth
    '    Guy, Wey Yuan
    ' H
    '    Holm, Michael
    ' L
    '    Liu, Jinghao
    ' M
    '    McLin, Nkenge
    '    Myrcha, Jacek
    ' N
    '    Noriega, Fabricio
    ' P
    '    Potra, Cristina
    ' T
    '    Toyoshima, Tim
    '</snippet11>

    '<snippet12>
    Class JoinStrings

        Shared Sub Main()

            ' Join content from spreadsheet files that contain
            ' related information. names.csv contains the student name
            ' plus an ID number. scores.csv contains the ID and a 
            ' set of four test scores. The following query joins
            ' the scores to the student names by using ID as a
            ' matching key.

            Dim names As String() = System.IO.File.ReadAllLines("../../../names.csv")
            Dim scores As String() = System.IO.File.ReadAllLines("../../../scores.csv")

            ' Name:    Last[0],       First[1],  ID[2],     Grade Level[3]
            '          Omelchenko,    Svetlana,  111,       2
            ' Score:   StudentID[0],  Exam1[1]   Exam2[2],  Exam3[3],  Exam4[4]
            '          111,           97,        92,        81,        60

            ' This query joins two dissimilar spreadsheets based on common ID value.
            ' Multiple from clauses are used instead of a join clause
            ' in order to store results of id.Split.
            Dim scoreQuery1 = From name In names 
                             Let n = name.Split(New Char() {","}) 
                                From id In scores 
                                Let n2 = id.Split(New Char() {","}) 
                                Where n(2) = n2(0) 
                                Select n(0) & "," & n(1) & "," & n2(0) & "," & n2(1) & "," &
                                  n2(2) & "," & n2(3)

            ' Pass a query variable to a Sub and execute it there.
            ' The query itself is unchanged.
            OutputQueryResults(scoreQuery1, "Merge two spreadsheets:")

            ' Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit.")
            Console.ReadKey()
        End Sub

        Shared Sub OutputQueryResults(ByVal query As IEnumerable(Of String), ByVal message As String)

            Console.WriteLine(System.Environment.NewLine & message)
            For Each item As String In query
                Console.WriteLine(item)
            Next
            Console.WriteLine(query.Count & " total names in list")

        End Sub
    End Class
    ' Output:
    'Merge two spreadsheets:
    'Adams,Terry,120, 99, 82, 81
    'Fakhouri,Fadi,116, 99, 86, 90
    'Feng,Hanying,117, 93, 92, 80
    'Garcia,Cesar,114, 97, 89, 85
    'Garcia,Debra,115, 35, 72, 91
    'Garcia,Hugo,118, 92, 90, 83
    'Mortensen,Sven,113, 88, 94, 65
    'O'Donnell,Claire,112, 75, 84, 91
    'Omelchenko,Svetlana,111, 97, 92, 81
    'Tucker,Lance,119, 68, 79, 88
    'Tucker,Michael,122, 94, 92, 91
    'Zabokritski,Eugene,121, 96, 85, 91
    '12 total names in list
    '</snippet12>

    '<snippet13>
    Class SortLines

        Shared Sub Main()
            Dim scores As String() = System.IO.File.ReadAllLines("../../../scores.csv")

            ' Change this to any value from 0 to 4
            Dim sortField As Integer = 1

            Console.WriteLine("Sorted highest to lowest by field " & sortField)

            ' Demonstrates how to return query from a method.
            ' The query is executed here.
            For Each str As String In SortQuery(scores, sortField)
                Console.WriteLine(str)
            Next

            ' Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit.")
            Console.ReadKey()

        End Sub

        Shared Function SortQuery(
            ByVal source As IEnumerable(Of String), 
            ByVal num As Integer) As IEnumerable(Of String)

            Dim scoreQuery = From line In source 
                             Let fields = line.Split(New Char() {","}) 
                             Order By fields(num) Descending 
                             Select line

            Return scoreQuery
        End Function
    End Class
    ' Output:
    ' Sorted highest to lowest by field 1
    ' 116, 99, 86, 90, 94
    ' 120, 99, 82, 81, 79
    ' 111, 97, 92, 81, 60
    ' 114, 97, 89, 85, 82
    ' 121, 96, 85, 91, 60
    ' 122, 94, 92, 91, 91
    ' 117, 93, 92, 80, 87
    ' 118, 92, 90, 83, 78
    ' 113, 88, 94, 65, 91
    ' 112, 75, 84, 91, 39
    ' 119, 68, 79, 88, 92
    ' 115, 35, 72, 91, 70
    '</snippet13>

    '<snippet14>
    Class LinqRegExVB

        Shared Sub Main()

            ' Root folder to query, along with all subfolders.
            ' Modify this path as necessary so that it accesses your Visual Studio folder.
            Dim startFolder As String = "C:\program files\Microsoft Visual Studio 9.0\"
            ' One of the following paths may be more appropriate on your computer.
            'string startFolder = @"c:\program files (x86)\Microsoft Visual Studio 9.0\";
            'string startFolder = @"c:\program files\Microsoft Visual Studio 10.0\";
            'string startFolder = @"c:\program files (x86)\Microsoft Visual Studio 10.0\";

            ' Take a snapshot of the file system.
            Dim fileList As IEnumerable(Of System.IO.FileInfo) = GetFiles(startFolder)

            ' Create a regular expression to find all things "Visual".
            Dim searchTerm As System.Text.RegularExpressions.Regex = 
                New System.Text.RegularExpressions.Regex("Visual (Basic|C#|C\+\+|J#|SourceSafe|Studio)")

            ' Search the contents of each .htm file.
            ' Remove the where clause to find even more matches!
            ' This query produces a list of files where a match
            ' was found, and a list of the matches in that file.
            ' Note: Explicit typing of "Match" in select clause.
            ' This is required because MatchCollection is not a 
            ' generic IEnumerable collection.
            Dim queryMatchingFiles = From afile In fileList
                                    Where afile.Extension = ".htm"
                                    Let fileText = System.IO.File.ReadAllText(afile.FullName)
                                    Let matches = searchTerm.Matches(fileText)
                                    Where (matches.Count > 0)
                                    Select Name = afile.FullName,
                                           Matches = From match As System.Text.RegularExpressions.Match In matches
                                                     Select match.Value

            ' Execute the query.
            Console.WriteLine("The term " & searchTerm.ToString() & " was found in:")

            For Each fileMatches In queryMatchingFiles
                ' Trim the path a bit, then write 
                ' the file name in which a match was found.
                Dim s = fileMatches.Name.Substring(startFolder.Length - 1)
                Console.WriteLine(s)

                ' For this file, write out all the matching strings
                For Each match In fileMatches.Matches
                    Console.WriteLine("  " + match)
                Next
            Next

            ' Keep the console window open in debug mode
            Console.WriteLine("Press any key to exit")
            Console.ReadKey()
        End Sub

        ' Function to retrieve a list of files. Note that this is a copy
        ' of the file information.
        Shared Function GetFiles(ByVal root As String) As IEnumerable(Of System.IO.FileInfo)
            Return From file In My.Computer.FileSystem.GetFiles(
                       root, FileIO.SearchOption.SearchAllSubDirectories, "*.*") 
                   Select New System.IO.FileInfo(file)
        End Function

    End Class
    '</snippet14>

    '<snippet15>
    Class SumColumns

        Public Shared Sub Main()

            Dim lines As String() = System.IO.File.ReadAllLines("../../../scores.csv")

            ' Specifies the column to compute
            ' This value could be passed in at runtime.
            Dim exam = 3

            ' Spreadsheet format:
            ' Student ID    Exam#1  Exam#2  Exam#3  Exam#4
            ' 111,          97,     92,     81,     60
            ' one is added to skip over the first column
            ' which holds the student ID.
            SumColumn(lines, exam + 1)
            Console.WriteLine()
            MultiColumns(lines)

            ' Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit...")
            Console.ReadKey()

        End Sub

        Shared Sub SumColumn(ByVal lines As IEnumerable(Of String), ByVal col As Integer)

            ' This query performs two steps:
            ' split the string into a string array
            ' convert the specified element to
            ' integer and select it.
            Dim columnQuery = From line In lines 
                               Let x = line.Split(",") 
                               Select Convert.ToInt32(x(col))

            ' Execute and cache the results for performance.
            ' Only needed with very large files.
            Dim results = columnQuery.ToList()

            ' Perform aggregate calculations 
            ' on the column specified by col.
            Dim avgScore = Aggregate score In results Into Average(score)
            Dim minScore = Aggregate score In results Into Min(score)
            Dim maxScore = Aggregate score In results Into Max(score)

            Console.WriteLine("Single Column Query:")
            Console.WriteLine("Exam #{0}: Average:{1:##.##} High Score:{2} Low Score:{3}", 
                         col, avgScore, maxScore, minScore)


        End Sub

        Shared Sub MultiColumns(ByVal lines As IEnumerable(Of String))

            Console.WriteLine("Multi Column Query:")

            ' Create the query. It will produce nested sequences. 
            ' multiColQuery performs these steps:
            ' 1) convert the string to a string array
            ' 2) skip over the "Student ID" column and take the rest
            ' 3) convert each field to an int and select that 
            '    entire sequence as one row in the results.
            Dim multiColQuery = From line In lines 
                                Let fields = line.Split(",") 
                                Select From str In fields Skip 1 
                                            Select Convert.ToInt32(str)

            Dim results = multiColQuery.ToList()

            ' Find out how many columns we have.
            Dim columnCount = results(0).Count()

            ' Perform aggregate calculations on each column.            
            ' One loop for each score column in scores.
            ' We can use a for loop because we have already
            ' executed the multiColQuery in the call to ToList.

            For j As Integer = 0 To columnCount - 1
                Dim column = j
                Dim res2 = From row In results 
                           Select row.ElementAt(column)

                ' Perform aggregate calculations 
                ' on the column specified by col.
                Dim avgScore = Aggregate score In res2 Into Average(score)
                Dim minScore = Aggregate score In res2 Into Min(score)
                Dim maxScore = Aggregate score In res2 Into Max(score)

                ' Add 1 to column numbers because exams in this course start with #1
                Console.WriteLine("Exam #{0} Average: {1:##.##} High Score: {2} Low Score: {3}", 
                                  column + 1, avgScore, maxScore, minScore)

            Next
        End Sub

    End Class
    ' Output:
    ' Single Column Query:
    ' Exam #4: Average:76.92 High Score:94 Low Score:39

    ' Multi Column Query:
    ' Exam #1 Average: 86.08 High Score: 99 Low Score: 35
    ' Exam #2 Average: 86.42 High Score: 94 Low Score: 72
    ' Exam #3 Average: 84.75 High Score: 91 Low Score: 65
    ' Exam #4 Average: 76.92 High Score: 94 Low Score: 39

    '</snippet15>

    '<snippet16>
    Class Student
        Public FirstName As String
        Public LastName As String
        Public ID As Integer
        Public ExamScores As List(Of Integer)
    End Class

    Class PopulateCollection

        Shared Sub Main()

            ' Merge content from spreadsheets into a list of Student objects.

            ' These data files are defined in How to: Join Content from 
            ' Dissimilar Files (LINQ).

            ' Each line of names.csv consists of a last name, a first name, and an
            ' ID number, separated by commas. For example, Omelchenko,Svetlana,111
            Dim names As String() = System.IO.File.ReadAllLines("../../../names.csv")

            ' Each line of scores.csv consists of an ID number and four test 
            ' scores, separated by commas. For example, 111, 97, 92, 81, 60
            Dim scores As String() = System.IO.File.ReadAllLines("../../../scores.csv")

            ' The following query merges the content of two dissimilar spreadsheets 
            ' based on common ID values.
            ' Multiple From clauses are used instead of a Join clause
            ' in order to store the results of scoreLine.Split.
            ' Note the dynamic creation of a list of integers for the
            ' ExamScores member. We skip the first item in the split string 
            ' because it is the student ID, not an exam score.
            Dim queryNamesScores = From nameLine In names
                              Let splitName = nameLine.Split(New Char() {","})
                              From scoreLine In scores
                              Let splitScoreLine = scoreLine.Split(New Char() {","})
                              Where splitName(2) = splitScoreLine(0)
                              Select New Student() With {
                                   .FirstName = splitName(0), .LastName = splitName(1), .ID = splitName(2),
                                   .ExamScores = (From scoreAsText In splitScoreLine Skip 1
                                                 Select Convert.ToInt32(scoreAsText)).ToList()}

            ' Optional. Store the query results for faster access in future
            ' queries. This could be useful with very large data files.
            Dim students As List(Of Student) = queryNamesScores.ToList()

            ' Display each student's name and exam score average.
            For Each s In students
                Console.WriteLine("The average score of " & s.FirstName & " " &
                                  s.LastName & " is " & s.ExamScores.Average())
            Next

            ' Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit.")
            Console.ReadKey()
        End Sub
    End Class

    ' Output: 
    ' The average score of Omelchenko Svetlana is 82.5
    ' The average score of O'Donnell Claire is 72.25
    ' The average score of Mortensen Sven is 84.5
    ' The average score of Garcia Cesar is 88.25
    ' The average score of Garcia Debra is 67
    ' The average score of Fakhouri Fadi is 92.25
    ' The average score of Feng Hanying is 88
    ' The average score of Garcia Hugo is 85.75
    ' The average score of Tucker Lance is 81.75
    ' The average score of Adams Terry is 85.25
    ' The average score of Zabokritski Eugene is 83
    ' The average score of Tucker Michael is 92
    '</snippet16>

    ' This is used to show the anonymous type version
    Class PopulateCollections2

        Shared Sub Main()

            ' Join content from spreadsheets into a list of Student objectss.
            ' names.csv contains the student name
            ' plus an ID number. scores.csv contains the ID and a 
            ' set of four test scores. The following query joins
            ' the scores to the student names by using ID as a
            ' matching key, and then projects the results into a new type.

            Dim names As String() = System.IO.File.ReadAllLines("../../../names.csv")
            Dim scores As String() = System.IO.File.ReadAllLines("../../../scores.csv")


            ' Name:    Last[0],       First[1],  ID[2],     Grade Level[3]
            '          Omelchenko,    Svetlana,  111,       2
            ' Score:   StudentID[0],  Exam1[1]   Exam2[2],  Exam3[3],  Exam4[4]
            '          111,           97,        92,        81,        60

            '<snippet17>
            ' Merge the data by using an anonymous type. 
            ' Note the dynamic creation of a list of integers for the
            ' ExamScores member. We skip 1 because the first string
            ' in the array is the student ID, not an exam score.
            Dim queryNamesScores2 =
                From nameLine In names
                Let splitName = nameLine.Split(New Char() {","})
                From scoreLine In scores
                Let splitScoreLine = scoreLine.Split(New Char() {","})
                Where splitName(2) = splitScoreLine(0)
                Select New With
                       {.Last = splitName(0),
                        .First = splitName(1),
                        .ExamScores = (From scoreAsText In splitScoreLine Skip 1
                                       Select Convert.ToInt32(scoreAsText)).ToList()}

            ' Display each student's name and exam score average.
            For Each s In queryNamesScores2
                Console.WriteLine("The average score of " & s.First & " " &
                                  s.Last & " is " & s.ExamScores.Average())
            Next
            '</snippet17>

            ' Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit.")
            Console.ReadKey()
        End Sub
    End Class

End Module