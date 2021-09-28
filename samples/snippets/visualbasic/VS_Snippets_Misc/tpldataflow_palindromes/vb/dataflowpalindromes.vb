' <snippet1> 
Imports System.Net.Http
Imports System.Threading.Tasks.Dataflow

' Demonstrates how to create a basic dataflow pipeline.
' This program downloads the book "The Iliad of Homer" by Homer from the Web 
' and finds all reversed words that appear in that book.
Module DataflowReversedWords

    Sub Main()
        ' <snippet3>
        '
        ' Create the members of the pipeline.
        ' 

        ' Downloads the requested resource as a string.
        Dim downloadString = New TransformBlock(Of String, String)(
            Async Function(uri)
                Console.WriteLine("Downloading '{0}'...", uri)

                Return Await New HttpClient().GetStringAsync(uri)
            End Function)

        ' Separates the specified text into an array of words.
        Dim createWordList = New TransformBlock(Of String, String())(
           Function(text)
               Console.WriteLine("Creating word list...")

             ' Remove common punctuation by replacing all non-letter characters 
             ' with a space character.
             Dim tokens() As Char = text.Select(Function(c) If(Char.IsLetter(c), c, " "c)).ToArray()
               text = New String(tokens)

             ' Separate the text into an array of words.
             Return text.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)
           End Function)

        ' Removes short words and duplicates.
        Dim filterWordList = New TransformBlock(Of String(), String())(
           Function(words)
               Console.WriteLine("Filtering word list...")

               Return words.Where(Function(word) word.Length > 3).Distinct().ToArray()
           End Function)

        ' Finds all words in the specified collection whose reverse also 
        ' exists in the collection.
        Dim findReversedWords = New TransformManyBlock(Of String(), String)(
           Function(words)

               Dim wordsSet = New HashSet(Of String)(words)

               Return From word In words.AsParallel()
                      Let reverse = New String(word.Reverse().ToArray())
                      Where word <> reverse AndAlso wordsSet.Contains(reverse)
                      Select word
           End Function)

        ' Prints the provided reversed words to the console.    
        Dim printReversedWords = New ActionBlock(Of String)(
           Sub(reversedWord)
               Console.WriteLine("Found reversed words {0}/{1}", reversedWord, New String(reversedWord.Reverse().ToArray()))
           End Sub)
        ' </snippet3>

        ' <snippet4>
        '
        ' Connect the dataflow blocks to form a pipeline.
        '

        Dim linkOptions = New DataflowLinkOptions With {.PropagateCompletion = True}

        downloadString.LinkTo(createWordList, linkOptions)
        createWordList.LinkTo(filterWordList, linkOptions)
        filterWordList.LinkTo(findReversedWords, linkOptions)
        findReversedWords.LinkTo(printReversedWords, linkOptions)
        ' </snippet4>

        ' <snippet6>
        ' Process "The Iliad of Homer" by Homer.
        downloadString.Post("http://www.gutenberg.org/cache/epub/16452/pg16452.txt")
        ' </snippet6>

        ' <snippet7>
        ' Mark the head of the pipeline as complete.
        downloadString.Complete()
        ' </snippet7>

        ' <snippet8>
        ' Wait for the last block in the pipeline to process all messages.
        printReversedWords.Completion.Wait()
        ' </snippet8>
    End Sub

End Module

' Sample output:
'Downloading 'http://www.gutenberg.org/cache/epub/16452/pg16452.txt'...
'Creating word list...
'Filtering word list...
'Finding reversed words...
'Found reversed words aera/area
'Found reversed words doom/mood
'Found reversed words draw/ward
'Found reversed words live/evil
'Found reversed words seat/taes
'Found reversed words area/aera
'Found reversed words port/trop
'Found reversed words sleek/keels
'Found reversed words tops/spot
'Found reversed words evil/live
'Found reversed words speed/deeps
'Found reversed words mood/doom
'Found reversed words moor/room
'Found reversed words spot/tops
'Found reversed words spots/stops
'Found reversed words trop/port
'Found reversed words stops/spots
'Found reversed words reed/deer
'Found reversed words deeps/speed
'Found reversed words deer/reed
'Found reversed words taes/seat
'Found reversed words keels/sleek
'Found reversed words room/moor
'Found reversed words ward/draw
' </snippet1> 
