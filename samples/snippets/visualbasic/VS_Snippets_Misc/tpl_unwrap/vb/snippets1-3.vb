Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks

' How to: Unwrap a Nested Task
Class IntroSnippets

    '<snippet01>
    Shared Function DoWorkAsync() As Task(Of String)

        Return Task(Of String).Run(Function()
                                       '...
                                       Return "Work completed."
                                   End Function)
    End Function

    Shared Sub StartTask()

        Dim t As Task(Of String) = DoWorkAsync()
        t.Wait()
        Console.WriteLine(t.Result)
    End Sub
    '</snippet01>


    Shared Sub Main()

        '<snippet02>
        ' Note the type of t and t2.
        Dim t As Task(Of Task(Of String)) = Task.Run(Function() DoWorkAsync())
        Dim t2 As Task(Of Task(Of String)) = DoWorkAsync().ContinueWith(Function(s) DoMoreWorkAsync())

        ' Outputs: System.Threading.Tasks.Task`1[System.String]
        Console.WriteLine(t.Result)
        '</snippet02>

        '<snippet03>
        ' Unwrap the inner task.
        Dim t3 As Task(Of String) = DoWorkAsync().ContinueWith(Function(s) DoMoreWorkAsync()).Unwrap()

        ' Outputs "More work completed."
        Console.WriteLine(t.Result)
        '</snippet03>


        Console.ReadKey()
    End Sub

    Shared Function DoMoreWorkAsync() As Task(Of String)

        Return Task(Of String).Run(Function()

                                       '...
                                       Return "More work completed."
                                   End Function)
    End Function

End Class


