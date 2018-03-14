Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Module Module1
    Class Program

        Shared Sub Main()

        End Sub

        '<snippet01>
        Sub QueueTasks()

            ' TaskA is a top level task.
            Dim taskA = Task.Factory.StartNew(Sub()

                                                  Console.WriteLine("I was enqueued on the thread pool's global queue.")

                                                  ' TaskB is a nested task and TaskC is a child task. Both go to local queue.
                                                  Dim taskB = New Task(Sub() Console.WriteLine("I was enqueued on the local queue."))
                                                  Dim taskC = New Task(Sub() Console.WriteLine("I was enqueued on the local queue, too."),
                                                                          TaskCreationOptions.AttachedToParent)

                                                  taskB.Start()
                                                  taskC.Start()

                                              End Sub)
        End Sub
        '</snippet01>

    End Class



End Module
