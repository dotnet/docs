'<snippet06>
' How to: Use Parallel.Invoke to Execute Parallel Operations
Option Explicit On
Option Strict On

Imports System.Threading.Tasks
Imports System.Net

Module ParallelTasks

    Sub Main()
        ' Retrieve Darwin's "Origin of the Species" from Gutenberg.org.
        Dim words As String() = CreateWordArray("http://www.gutenberg.org/files/2009/2009.txt")

        '#Region "ParallelTasks"
        ' Perform three tasks in parallel on the source array
        Parallel.Invoke(Sub()
                            Console.WriteLine("Begin first task...")
                            GetLongestWord(words)
                            ' close first Action
                        End Sub,
            Sub()
                Console.WriteLine("Begin second task...")
                GetMostCommonWords(words)
                'close second Action
            End Sub,
            Sub()
                Console.WriteLine("Begin third task...")
                GetCountForWord(words, "species")
                'close third Action
            End Sub)
        'close parallel.invoke
        Console.WriteLine("Returned from Parallel.Invoke")
        '#End Region

        Console.WriteLine("Press any key to exit")
        Console.ReadKey()
    End Sub

#Region "HelperMethods"
    Sub GetCountForWord(ByVal words As String(), ByVal term As String)
        Dim findWord = From word In words _
            Where word.ToUpper().Contains(term.ToUpper()) _
            Select word

        Console.WriteLine("Task 3 -- The word ""{0}"" occurs {1} times.", term, findWord.Count())
    End Sub

    Sub GetMostCommonWords(ByVal words As String())
        Dim frequencyOrder = From word In words _
            Where word.Length > 6 _
            Group By word
            Into wordGroup = Group, Count()
            Order By wordGroup.Count() Descending _
            Select wordGroup

        Dim commonWords = From grp In frequencyOrder
                          Select grp
                          Take (10)

        Dim s As String
        s = "Task 2 -- The most common words are:" & vbCrLf
        For Each v In commonWords
            s = s & v(0) & vbCrLf
        Next
        Console.WriteLine(s)
    End Sub

    Function GetLongestWord(ByVal words As String()) As String
        Dim longestWord = (From w In words _
            Order By w.Length Descending _
            Select w).First()

        Console.WriteLine("Task 1 -- The longest word is {0}", longestWord)
        Return longestWord
    End Function


    ' An http request performed synchronously for simplicity.
    Function CreateWordArray(ByVal uri As String) As String()
        Console.WriteLine("Retrieving from {0}", uri)

        ' Download a web page the easy way.
        Dim s As String = New WebClient().DownloadString(uri)

        ' Separate string into an array of words, removing some common punctuation.
        Return s.Split(New Char() {" "c, ControlChars.Lf, ","c, "."c, ";"c, ":"c, _
        "-"c, "_"c, "/"c}, StringSplitOptions.RemoveEmptyEntries)
    End Function
#End Region


    ' Output (May vary on each execution):
    ' Retrieving from http://www.gutenberg.org/dirs/etext99/otoos610.txt
    ' Response stream received.
    ' Begin first task...
    ' Begin second task...
    ' Task 2 -- The most common words are:
    ' species
    ' selection
    ' varieties
    ' natural
    ' animals
    ' between
    ' different
    ' distinct
    ' several
    ' conditions
    '
    ' Begin third task...
    ' Task 1 -- The longest word is characteristically
    ' Task 3 -- The word "species" occurs 1927 times.
    ' Returned from Parallel.Invoke
    ' Press any key to exit 
    ' 
End Module
'</snippet06>