' Visual Basic .NET Document
'Option Strict On

' <Snippet1>
Imports System.Collections.Generic
Imports System.IO
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Text.RegularExpressions

Module Example
   Dim totalWords As Integer = 0
   
   Public Sub Main()
      Dim filenames() As String = { "chapter1.txt", "chapter2.txt", 
                                    "chapter3.txt", "chapter4.txt",
                                    "chapter5.txt" }
      Dim pattern As String = "\b\w+\b"
      Dim tasks As New List(Of Task)()  
        
      ' Determine the number of words in each file.
      For Each filename In filenames 
         tasks.Add(Task.Factory.StartNew( Sub(fn)
                                             If Not File.Exists(filename)
                                                Throw New FileNotFoundException("{0} does not exist.", filename)
                                             End If
                                             
                                             Dim sr As New StreamReader(fn.ToString())
                                             Dim content As String = sr.ReadToEnd()
                                             sr.Close()
                                             Dim words As Integer = Regex.Matches(content, pattern).Count
                                             Interlocked.Add(totalWords, words) 
                                             Console.WriteLine("{0,-25} {1,6:N0} words", fn, words)
                                          End Sub, filename))
      Next
      
      Dim finalTask As Task = Task.Factory.ContinueWhenAll(tasks.ToArray(), 
                                                           Sub(wordCountTasks As Task() )
                                                              Dim nSuccessfulTasks As Integer = 0
                                                              Dim nFailed As Integer = 0
                                                              Dim nFileNotFound As Integer = 0
                                                              For Each t In wordCountTasks
                                                                 If t.Status = TaskStatus.RanToCompletion Then _ 
                                                                    nSuccessfulTasks += 1
                                                       
                                                                 If t.Status = TaskStatus.Faulted Then
                                                                    nFailed += 1  
                                                                    t.Exception.Handle(Function(e As Exception) 
                                                                                          If TypeOf e Is FileNotFoundException Then
                                                                                             nFileNotFound += 1
                                                                                          End If   
                                                                                          Return True   
                                                                                       End Function)                       
                                                                 End If 
                                                              Next   
                                                              Console.WriteLine()
                                                              Console.WriteLine("{0,-25} {1,6} total words", 
                                                                                String.Format("{0} files", nSuccessfulTasks), 
                                                                                totalWords) 
                                                              If nFailed > 0 Then
                                                                 Console.WriteLine()
                                                                 Console.WriteLine("{0} tasks failed for the following reasons:", nFailed)
                                                                 Console.WriteLine("   File not found:    {0}", nFileNotFound)
                                                                 If nFailed <> nFileNotFound Then
                                                                    Console.WriteLine("   Other:          {0}", nFailed - nFileNotFound)
                                                                 End If 
                                                              End If
                                                           End Sub)
      finalTask.Wait()                                                                  
   End Sub
   
   Private Sub DisplayResult(wordCountTasks As Task())
   End Sub
End Module
' The example displays output like the following:
'       chapter2.txt               1,585 words
'       chapter1.txt               4,012 words
'       chapter5.txt               4,660 words
'       chapter3.txt               7,481 words
'       
'       4 files                    17738 total words
'       
'       1 tasks failed for the following reasons:
'          File not found:    1
' </Snippet1>
