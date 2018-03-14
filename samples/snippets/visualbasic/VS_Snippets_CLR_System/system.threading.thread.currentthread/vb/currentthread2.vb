' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Imports System.Collections.Generic
Imports System.Threading
Imports System.Threading.Tasks

Module Example
   Private lockObj As New Object()
   Private rndLock As New Object()
   
   Public Sub Main()
      Dim rnd As New Random()
      Dim tasks As New List(Of Task)
      ShowThreadInformation("Application")

      Dim t As Task(Of Double) = Task.Run( Function()
                                        ShowThreadInformation("Main Task(Task #" + Task.CurrentId.ToString() + ")")
                                        For ctr As Integer = 1 To 20
                                           tasks.Add(Task.Factory.StartNew( Function()
                                                                     ShowThreadInformation("Task #" + Task.CurrentId.ToString())
                                                                     Dim s As Long = 0
                                                                     For n As Integer = 0 To 999999
                                                                        SyncLock rndLock
                                                                           s += rnd.Next(1, 1000001)
                                                                        End SyncLock
                                                                     Next
                                                                     Return s/1000000
                                                                  End Function))
                                        Next

                                        Task.WaitAll(tasks.ToArray())
                                        Dim grandTotal As Double
                                        Console.WriteLine("Means of each task: ")
                                        For Each t In tasks
                                           Console.WriteLine("   {0}", t.Result)
                                           grandTotal += t.Result
                                        Next
                                        Console.WriteLine()
                                        Return grandTotal / 20
                                   End Function )
      Console.WriteLine("Mean of Means: {0}", t.Result)
   End Sub
   
   Private Sub ShowThreadInformation(taskName As String)
      Dim msg As String = Nothing
      Dim thread As Thread = Thread.CurrentThread
      SyncLock lockObj
         msg = String.Format("{0} thread information", taskName) + vbCrLf +
               String.Format("   Background: {0}", thread.IsBackground) + vbCrLf +
               String.Format("   Thread Pool: {0}", thread.IsThreadPoolThread) + vbCrLf +
               String.Format("   Thread ID: {0}", thread.ManagedThreadId) + vbCrLf
      End SyncLock
      Console.WriteLine(msg)
   End Sub
End Module
' The example displays output like the following:
'       Application thread information
'          Background: False
'          Thread Pool: False
'          Thread ID: 1
'
'       Main Task(Task #1) thread information
'          Background: True
'          Thread Pool: True
'          Thread ID: 3
'
'       Task #2 thread information
'          Background: True
'          Thread Pool: True
'          Thread ID: 4
'
'       Task #4 thread information
'          Background: True
'          Thread Pool: True
'          Thread ID: 10
'
'       Task #3 thread information
'          Background: True
'          Thread Pool: True
'          Thread ID: 9
'
'       Task #5 thread information
'          Background: True
'          Thread Pool: True
'          Thread ID: 3
'
'       Task #7 thread information
'          Background: True
'          Thread Pool: True
'          Thread ID: 5
'
'       Task #6 thread information
'          Background: True
'          Thread Pool: True
'          Thread ID: 7
'
'       Task #8 thread information
'          Background: True
'          Thread Pool: True
'          Thread ID: 6
'
'       Task #9 thread information
'          Background: True
'          Thread Pool: True
'          Thread ID: 8
'
'       Task #10 thread information
'          Background: True
'          Thread Pool: True
'          Thread ID: 9
'
'       Task #11 thread information
'          Background: True
'          Thread Pool: True
'          Thread ID: 10
'
'       Task #12 thread information
'          Background: True
'          Thread Pool: True
'          Thread ID: 6
'
'       Task #13 thread information
'          Background: True
'          Thread Pool: True
'          Thread ID: 4
'
'       Task #14 thread information
'          Background: True
'          Thread Pool: True
'          Thread ID: 3
'
'       Task #15 thread information
'          Background: True
'          Thread Pool: True
'          Thread ID: 7
'
'       Task #16 thread information
'          Background: True
'          Thread Pool: True
'          Thread ID: 5
'
'       Task #17 thread information
'          Background: True
'          Thread Pool: True
'          Thread ID: 8
'
'       Task #18 thread information
'          Background: True
'          Thread Pool: True
'          Thread ID: 9
'
'       Task #19 thread information
'          Background: True
'          Thread Pool: True
'          Thread ID: 10
'
'       Task #20 thread information
'          Background: True
'          Thread Pool: True
'          Thread ID: 4
'
'       Task #21 thread information
'          Background: True
'          Thread Pool: True
'          Thread ID: 7
'
'       Means of each task:
'          500038.740584
'          499810.422703
'          500217.558077
'          499868.534688
'          499295.505866
'          499893.475772
'          499601.454469
'          499828.532502
'          499606.183978
'          499700.276056
'          500415.894952
'          500005.874751
'          500042.237016
'          500092.764753
'          499998.798267
'          499623.054718
'          500018.784823
'          500286.865993
'          500052.68285
'          499764.363303
'
'       Mean of Means: 499908.10030605/
' </Snippet1>
