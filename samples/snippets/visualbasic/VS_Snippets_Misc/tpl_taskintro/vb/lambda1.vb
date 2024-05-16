' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Threading

Namespace Lambda
    Module Example
        Public Sub Main()
            Thread.CurrentThread.Name = "Main"

            ' Create a task and supply a user delegate by using a lambda expression. 
            Dim taskA = New Task(Sub() Console.WriteLine("Hello from taskA."))
            ' Start the task.
            taskA.Start()

            ' Output a message from the calling thread.
            Console.WriteLine("Hello from thread '{0}'.",
                            Thread.CurrentThread.Name)
            taskA.Wait()
        End Sub
    End Module
    ' The example displays output like the following:
    '    Hello from thread 'Main'.
    '    Hello from taskA.
End Namespace
' </Snippet1>
