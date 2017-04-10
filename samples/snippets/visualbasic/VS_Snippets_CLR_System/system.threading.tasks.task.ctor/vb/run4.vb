' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Collections.Generic
Imports System.IO
Imports System.Threading
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim tokenSource As New CancellationTokenSource()
      Dim token As CancellationToken = tokenSource.Token
      Dim files As New List(Of Tuple(Of String, String, Long, Date))()
      Dim t As New Task(Sub()
                           Dim dir As String = "C:\Windows\System32\"
                           Dim obj As New Object()
                           If Directory.Exists(dir)Then
                              Parallel.ForEach(Directory.GetFiles(dir), 
                                 Sub(f)
                                    If token.IsCancellationRequested Then
                                       token.ThrowIfCancellationRequested()
                                    End If  
                                    Dim fi As New FileInfo(f)
                                    SyncLock(obj)
                                       files.Add(Tuple.Create(fi.Name, fi.DirectoryName, fi.Length, fi.LastWriteTimeUtc))          
                                    End SyncLock
                                 End Sub)
                           End If
                        End Sub, token)
      t.Start()
      tokenSource.Cancel()
      Try
         t.Wait() 
         Console.WriteLine("Retrieved information for {0} files.", files.Count)
      Catch e As AggregateException
         Console.WriteLine("Exception messages:")
         For Each ie As Exception In e.InnerExceptions
            Console.WriteLine("   {0}:{1}", ie.GetType().Name, ie.Message)
         Next
         Console.WriteLine()
         Console.WriteLine("Task status: {0}", t.Status)       
      Finally
         tokenSource.Dispose()
      End Try
   End Sub
End Module
' The example displays the following output:
'       Exception messages:
'          TaskCanceledException: A task was canceled.
'       
'       Task status: Canceled
' </Snippet4>
