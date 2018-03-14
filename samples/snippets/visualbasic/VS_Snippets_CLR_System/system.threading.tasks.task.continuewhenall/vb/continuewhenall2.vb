' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Collections.Generic
Imports System.IO
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim filenames() As String= { "chapter1.txt", "chapter2.txt", 
                                   "chapter3.txt", "chapter4.txt",
                                   "chapter5.txt" }
      Dim pattern As String = "\b\w+\b"
      Dim tasks As New List(Of Task)()  
      Dim source As New CancellationTokenSource()
      Dim token As CancellationToken = source.Token
      Dim totalWords As Integer = 0
        
      ' Determine the number of words in each file.
      For Each filename In filenames
         tasks.Add( Task.Factory.StartNew( Sub(obj As Object)
                                              Dim fn As String = CStr(obj)
                                              token.ThrowIfCancellationRequested() 
                                              If Not File.Exists(fn) Then 
                                                 source.Cancel()
                                                 token.ThrowIfCancellationRequested()
                                              End If        
                                                   
                                              Dim sr As New StreamReader(fn.ToString())
                                              Dim content As String = sr.ReadToEnd()
                                              sr.Close()
                                              Dim words As Integer = Regex.Matches(content, pattern).Count
                                              Interlocked.Add(totalWords, words) 
                                              Console.WriteLine("{0,-25} {1,6:N0} words", fn, words) 
                                           End Sub, filename, token))
      Next
      
      Dim finalTask As Task = Task.Factory.ContinueWhenAll(tasks.ToArray(), 
                                                           Sub(wordCountTasks As Task())
                                                              If Not token.IsCancellationRequested Then 
                                                                 Console.WriteLine("\n{0,-25} {1,6} total words\n", 
                                                                                   String.Format("{0} files", wordCountTasks.Length), 
                                                                                   totalWords)
                                                              End If                      
                                                           End Sub, token) 
      Try                                                    
         finalTask.Wait()
      Catch ae As AggregateException 
         For Each inner In ae.InnerExceptions
            Console.WriteLine()
            If TypeOf inner Is TaskCanceledException
               Console.WriteLine("Failure to determine total word count: a task was cancelled.")
            Else
               Console.WriteLine("Failure caused by {0}", inner.GetType().Name)
            End If 
         Next           
      Finally
         source.Dispose()
      End Try                                                                     
   End Sub
End Module
' The example displays output like the following:
'       chapter2.txt               1,585 words
'       chapter1.txt               4,012 words
'       
'       Failure to determine total word count: a task was cancelled.
' </Snippet2>
