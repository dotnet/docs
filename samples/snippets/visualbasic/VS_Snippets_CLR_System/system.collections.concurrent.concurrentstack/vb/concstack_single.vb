'<snippet1>
Imports System.Collections.Concurrent
Imports System.Threading.Tasks

Class Example
    ' Demonstrates:
    '   ConcurrentStack<T>.Push();
    '   ConcurrentStack<T>.TryPeek();
    '   ConcurrentStack<T>.TryPop();
    '   ConcurrentStack<T>.Clear();
    '   ConcurrentStack<T>.IsEmpty;
    Shared Sub Main()
        Dim items As Integer = 10000
        Dim stack As ConcurrentStack(Of Integer) = New ConcurrentStack(Of Integer)()

        ' Create an action to push items onto the stack
        Dim pusher As Action = Function()
                                   For i As Integer = 0 To items - 1
                                       stack.Push(i)
                                   Next
                               End Function

        ' Run the action once
        pusher()

        Dim result As Integer = Nothing

        If stack.TryPeek(result) Then
            Console.WriteLine($"TryPeek() saw {result} on top of the stack.")
        Else
            Console.WriteLine("Could not peek most recently added number.")
        End If

        ' Empty the stack
        stack.Clear()

        If stack.IsEmpty Then
            Console.WriteLine("Cleared the stack.")
        End If

        ' Create an action to push and pop items
        Dim pushAndPop As Action = Function()
                                       Console.WriteLine($"Task started on {Task.CurrentId}")
                                       Dim item As Integer

                                       For i As Integer = 0 To items - 1
                                           stack.Push(i)
                                       Next

                                       For i As Integer = 0 To items - 1
                                           stack.TryPop(item)
                                       Next

                                       Console.WriteLine($"Task ended on {Task.CurrentId}")
                                   End Function

        ' Spin up five concurrent tasks of the action
        Dim tasks = New Task(4) {}
        For i As Integer = 0 To tasks.Length - 1
            tasks(i) = Task.Factory.StartNew(pushAndPop)
        Next

        ' Wait for all the tasks to finish up
        Task.WaitAll(tasks)

        If Not stack.IsEmpty Then
            Console.WriteLine("Did not take all the items off the stack")
        End If
    End Sub
End Class
'</snippet1>
