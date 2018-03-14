' Example for Task.Run(Action) method
Option Strict On

' <Snippet1>
Imports System.Collections.Concurrent
Imports System.Collections.Generic
Imports System.IO
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim list As New ConcurrentBag(Of String)()
      Dim dirNames() As String = { ".", ".." }
      Dim tasks As New List(Of Task)()
      For Each dirName In dirNames 
         Dim t As New Task( Sub()
                               For Each path In Directory.GetFiles(dirName)
                                  list.Add(path)
                               Next
                            End Sub  )
         tasks.Add(t)
         t.Start()
      Next
      Task.WaitAll(tasks.ToArray())
      For Each t In tasks
         Console.WriteLine("Task {0} Status: {1}", t.Id, t.Status)
      Next   
      Console.WriteLine("Number of files read: {0}", list.Count)
   End Sub
End Module
' The example displays output like the following:
'       Task 1 Status: RanToCompletion
'       Task 2 Status: RanToCompletion
'       Number of files read: 23
' </Snippet1>