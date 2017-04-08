' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Threading
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim tasks(4) As Task
      For ctr As Integer = 0 To 4
         Dim factor As Integer = ctr
         tasks(ctr) = Task.Run(Sub() Thread.Sleep(factor * 250 + 50))
      Next
      Dim index As Integer = Task.WaitAny(tasks)

      Console.WriteLine("Wait ended because task #{0} completed.",
                        tasks(index).Id)
      Console.WriteLine()
      Console.WriteLine("Current Status of Tasks:")
      For Each t In tasks
         Console.WriteLine("   Task {0}: {1}", t.Id, t.Status)
      Next
   End Sub
End Module
' The example displays output like the following:
'       Wait ended because task #1 completed.
'
'       Current Status of Tasks:
'          Task 1: RanToCompletion
'          Task 2: Running
'          Task 3: Running
'          Task 4: Running
'          Task 5: Running
' </Snippet1>
