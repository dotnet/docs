' Visual Basic .NET Document
Option Infer On
Option Strict On

' <Snippet14>
Imports System.Globalization
Imports System.Threading

Module Example1
    Public Sub Main()
        Dim tasks As New List(Of Task)
        Console.WriteLine("The current UI culture is {0}",
                          Thread.CurrentThread.CurrentUICulture.Name)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("pt-BR")
        ' Change the current UI culture to Portuguese (Brazil).
        Console.WriteLine("Current culture changed to {0}",
                          Thread.CurrentThread.CurrentUICulture.Name)
        Console.WriteLine("Application thread is thread {0}",
                          Thread.CurrentThread.ManagedThreadId)
        ' Launch six tasks and display their current culture.
        For ctr As Integer = 0 To 5
            tasks.Add(Task.Run(Sub()
                                   Console.WriteLine("Culture of task {0} on thread {1} is {2}",
                                                     Task.CurrentId,
                                                     Thread.CurrentThread.ManagedThreadId,
                                                     Thread.CurrentThread.CurrentUICulture.Name)
                               End Sub))
        Next
        Task.WaitAll(tasks.ToArray())
    End Sub
End Module
' The example displays output like the following:
'     The current culture is en-US
'     Current culture changed to pt-BR
'     Application thread is thread 9
'     Culture of task 2 on thread 11 is pt-BR
'     Culture of task 1 on thread 10 is pt-BR
'     Culture of task 3 on thread 11 is pt-BR
'     Culture of task 5 on thread 11 is pt-BR
'     Culture of task 6 on thread 11 is pt-BR
'     Culture of task 4 on thread 10 is pt-BR
' </Snippet14>
