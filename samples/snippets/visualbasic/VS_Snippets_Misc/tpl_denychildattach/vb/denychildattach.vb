' <snippet1> 
Imports System
Imports System.Diagnostics
Imports System.Threading
Imports System.Threading.Tasks

' Defines functionality that is provided by a third-party.
' In a real-world scenario, this would likely be provided
' in a separate code file or assembly.
Namespace Contoso
   Public Class Widget
      Public Function Run() As Task
         ' Create a long-running task that is attached to the 
         ' parent in the task hierarchy.
         Return Task.Factory.StartNew(Sub() Thread.Sleep(5000), TaskCreationOptions.AttachedToParent)
            ' Simulate a lengthy operation.
      End Function
   End Class
End Namespace

' Demonstrates how to prevent a child task from attaching to the parent.
Friend Class DenyChildAttach
   Private Shared Sub RunWidget(ByVal widget As Contoso.Widget, ByVal parentTaskOptions As TaskCreationOptions)
      ' Record the time required to run the parent
      ' and child tasks.
      Dim stopwatch As New Stopwatch()
      stopwatch.Start()

      Console.WriteLine("Starting widget as a background task...")

      ' Run the widget task in the background.
      Dim runWidget As Task(Of Task) = Task.Factory.StartNew(Function()
            ' Perform other work while the task runs...
          Dim widgetTask As Task = widget.Run()
          Thread.Sleep(1000)
          Return widgetTask
      End Function, parentTaskOptions)

      ' Wait for the parent task to finish.
      Console.WriteLine("Waiting for parent task to finish...")
      runWidget.Wait()
      Console.WriteLine("Parent task has finished. Elapsed time is {0} ms.", stopwatch.ElapsedMilliseconds)

      ' Perform more work...
      Console.WriteLine("Performing more work on the main thread...")
      Thread.Sleep(2000)
      Console.WriteLine("Elapsed time is {0} ms.", stopwatch.ElapsedMilliseconds)

      ' Wait for the child task to finish.
      Console.WriteLine("Waiting for child task to finish...")
      runWidget.Result.Wait()
      Console.WriteLine("Child task has finished. Elapsed time is {0} ms.", stopwatch.ElapsedMilliseconds)
   End Sub

   Shared Sub Main(ByVal args() As String)
      Dim w As New Contoso.Widget()

      ' Perform the same operation two times. The first time, the operation
      ' is performed by using the default task creation options. The second
      ' time, the operation is performed by using the DenyChildAttach option
      ' in the parent task.

      Console.WriteLine("Demonstrating parent/child tasks with default options...")
      RunWidget(w, TaskCreationOptions.None)

      Console.WriteLine()

      Console.WriteLine("Demonstrating parent/child tasks with the DenyChildAttach option...")
      RunWidget(w, TaskCreationOptions.DenyChildAttach)
   End Sub
End Class

' Sample output:
'Demonstrating parent/child tasks with default options...
'Starting widget as a background task...
'Waiting for parent task to finish...
'Parent task has finished. Elapsed time is 5014 ms.
'Performing more work on the main thread...
'Elapsed time is 7019 ms.
'Waiting for child task to finish...
'Child task has finished. Elapsed time is 7019 ms.
'
'Demonstrating parent/child tasks with the DenyChildAttach option...
'Starting widget as a background task...
'Waiting for parent task to finish...
'Parent task has finished. Elapsed time is 1007 ms.
'Performing more work on the main thread...
'Elapsed time is 3015 ms.
'Waiting for child task to finish...
'Child task has finished. Elapsed time is 5015 ms.
'
' </snippet1>
