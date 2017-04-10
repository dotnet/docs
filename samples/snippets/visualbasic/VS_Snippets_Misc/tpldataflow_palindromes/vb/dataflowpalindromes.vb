' <snippet1> 
Imports System
Imports System.Collections.Concurrent
Imports System.Linq
Imports System.Net
Imports System.Threading.Tasks
Imports System.Threading.Tasks.Dataflow

' Demonstrates how to create a basic dataflow pipeline.
' This program downloads the book "The Iliad of Homer" by Homer from the Web 
' and finds all reversed words that appear in that book.
Friend Class DataflowReversedWords

   Shared Sub Main(ByVal args() As String)
      ' <snippet3>
      '
      ' Create the members of the pipeline.
      ' 

      ' Downloads the requested resource as a string.
      Dim downloadString = New TransformBlock(Of String, String)(Function(uri)
                                                                    Console.WriteLine("Downloading '{0}'...", uri)
                                                                    Return New WebClient().DownloadString(uri)
                                                                 End Function)

      ' Separates the specified text into an array of words.
      Dim createWordList = New TransformBlock(Of String, String())(Function(text)
                                                                      ' Remove common punctuation by replacing all non-letter characters 
                                                                      ' with a space character to.
                                                                      ' Separate the text into an array of words.
                                                                      Console.WriteLine("Creating word list...")
                                                                      Dim tokens() As Char = text.ToArray()
                                                                      For i As Integer = 0 To tokens.Length - 1
                                                                         If Not Char.IsLetter(tokens(i)) Then
                                                                            tokens(i) = " "c
                                                                         End If
                                                                      Next i
                                                                      text = New String(tokens)
                                                                      Return text.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)
                                                                   End Function)

      ' Removes short words, orders the resulting words alphabetically, 
      ' and then remove duplicates.
      Dim filterWordList = New TransformBlock(Of String(), String())(Function(words)
                                                                        Console.WriteLine("Filtering word list...")
                                                                        Return words.Where(Function(word) word.Length > 3).OrderBy(Function(word) word).Distinct().ToArray()
                                                                     End Function)

      ' Finds all words in the specified collection whose reverse also 
      ' exists in the collection.
      Dim findReversedWords = New TransformManyBlock(Of String(), String)(Function(words)
                                                                             ' Holds reversed words.
                                                                             ' Add each word in the original collection to the result whose 
                                                                             ' reverse also exists in the collection.
                                                                             ' Reverse the work.
                                                                             ' Enqueue the word if the reversed version also exists
                                                                             ' in the collection.
                                                                             Console.WriteLine("Finding reversed words...")
                                                                             Dim reversedWords = New ConcurrentQueue(Of String)()
                                                                             Parallel.ForEach(words, Sub(word)
                                                                                                        Dim reverse As New String(word.Reverse().ToArray())
                                                                                                        If Array.BinarySearch(Of String)(words, reverse) >= 0 AndAlso word <> reverse Then
                                                                                                           reversedWords.Enqueue(word)
                                                                                                        End If
                                                                                                     End Sub)
                                                                             Return reversedWords
                                                                          End Function)

      ' Prints the provided reversed words to the console.    
      Dim printReversedWords = New ActionBlock(Of String)(Sub(reversedWord) Console.WriteLine("Found reversed words {0}/{1}", reversedWord, New String(reversedWord.Reverse().ToArray())))
      ' </snippet3>

      ' <snippet4>
      '
      ' Connect the dataflow blocks to form a pipeline.
      '

      downloadString.LinkTo(createWordList)
      createWordList.LinkTo(filterWordList)
      filterWordList.LinkTo(findReversedWords)
      findReversedWords.LinkTo(printReversedWords)
      ' </snippet4>
      ' <snippet5>
      '
      ' For each completion task in the pipeline, create a continuation task
      ' that marks the next block in the pipeline as completed.
      ' A completed dataflow block processes any buffered elements, but does
      ' not accept new elements.
      '

      downloadString.Completion.ContinueWith(Sub(t)
                                                If t.IsFaulted Then
                                                   CType(createWordList, IDataflowBlock).Fault(t.Exception)
                                                Else
                                                   createWordList.Complete()
                                                End If
                                             End Sub)
      createWordList.Completion.ContinueWith(Sub(t)
                                                If t.IsFaulted Then
                                                   CType(filterWordList, IDataflowBlock).Fault(t.Exception)
                                                Else
                                                   filterWordList.Complete()
                                                End If
                                             End Sub)
      filterWordList.Completion.ContinueWith(Sub(t)
                                                If t.IsFaulted Then
                                                   CType(findReversedWords, IDataflowBlock).Fault(t.Exception)
                                                Else
                                                   findReversedWords.Complete()
                                                End If
                                             End Sub)
      findReversedWords.Completion.ContinueWith(Sub(t)
                                                   If t.IsFaulted Then
                                                      CType(printReversedWords, IDataflowBlock).Fault(t.Exception)
                                                   Else
                                                      printReversedWords.Complete()
                                                   End If
                                                End Sub)

      ' </snippet5>

      ' <snippet6>
      ' Process "The Iliad of Homer" by Homer.
      downloadString.Post("http://www.gutenberg.org/files/6130/6130-0.txt")
      ' </snippet6>

      ' <snippet7>
      ' Mark the head of the pipeline as complete. The continuation tasks 
      ' propagate completion through the pipeline as each part of the 
      ' pipeline finishes.
      downloadString.Complete()
      ' </snippet7>

      ' <snippet8>
      ' Wait for the last block in the pipeline to process all messages.
      printReversedWords.Completion.Wait()
      ' </snippet8>
   End Sub

End Class

' Sample output:
'Downloading 'http://www.gutenberg.org/files/6130/6130-0.txt'...
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

'
Namespace shell1
   ' <snippet2> 
   Imports System.Collections.Concurrent
   Imports System.Linq
   Imports System.Net
   Imports System.Threading.Tasks
   Imports System.Threading.Tasks.Dataflow

   ' Demonstrates how to create a basic dataflow pipeline.
   ' This program downloads the book "The Iliad of Homer" by Homer from the Web 
   ' and finds all palindromes that appear in that book.
   Class Program
      Private Shared Sub Main(args As String())
      End Sub
   End Class
   ' </snippet2> 

End Namespace

