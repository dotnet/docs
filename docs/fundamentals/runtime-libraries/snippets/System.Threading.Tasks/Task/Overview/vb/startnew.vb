'<snippet01>
Imports System.Threading
Imports System.Threading.Tasks

Module Example2
    Public Sub Main()
        Dim action As Action(Of Object) =
              Sub(obj As Object)
                  Console.WriteLine("Task={0}, obj={1}, Thread={2}",
                 Task.CurrentId, obj,
                 Thread.CurrentThread.ManagedThreadId)
              End Sub

        ' Construct an unstarted task
        Dim t1 As New Task(action, "alpha")

        ' Construct a started task
        Dim t2 As Task = Task.Factory.StartNew(action, "beta")
        ' Block the main thread to demonstrate that t2 is executing
        t2.Wait()

        ' Launch t1 
        t1.Start()
        Console.WriteLine("t1 has been launched. (Main Thread={0})",
                          Thread.CurrentThread.ManagedThreadId)
        ' Wait for the task to finish.
        t1.Wait()

        ' Construct a started task using Task.Run.
        Dim taskData As String = "delta"
        Dim t3 As Task = Task.Run(Sub()
                                      Console.WriteLine("Task={0}, obj={1}, Thread={2}",
                                     Task.CurrentId, taskData,
                                     Thread.CurrentThread.ManagedThreadId)
                                  End Sub)
        ' Wait for the task to finish.
        t3.Wait()

        ' Construct an unstarted task
        Dim t4 As New Task(action, "gamma")
        ' Run it synchronously
        t4.RunSynchronously()
        ' Although the task was run synchronously, it is a good practice
        ' to wait for it in the event exceptions were thrown by the task.
        t4.Wait()
    End Sub
End Module
' The example displays output like the following:
'       Task=1, obj=beta, Thread=3
'       t1 has been launched. (Main Thread=1)
'       Task=2, obj=alpha, Thread=3
'       Task=3, obj=delta, Thread=3
'       Task=4, obj=gamma, Thread=1
'</snippet01>
