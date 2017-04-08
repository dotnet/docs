'<snippet03>
Imports System.Threading
Imports System.Threading.Tasks

Module ContinuationDemo

    ' Demonstrated features:
    '   Task.Factory
    '   Task.ContinueWith()
    '   Task.Wait()
    ' Expected results:
    '   A sequence of three unrelated tasks is created and executed in this order - alpha, beta, gamma.
    '   A sequence of three related tasks is created - each task negates its argument and passes is to the next task: 5, -5, 5 is printed.
    '   A sequence of three unrelated tasks is created where tasks have different types.
    ' Documentation:
    '   http://msdn.microsoft.com/en-us/library/system.threading.tasks.taskfactory_members(VS.100).aspx
    Sub Main()
        Dim action As Action(Of String) = Sub(str) Console.WriteLine("Task={0}, str={1}, Thread={2}", Task.CurrentId, str, Thread.CurrentThread.ManagedThreadId)

        ' Creating a sequence of action tasks (that return no result).
        Console.WriteLine("Creating a sequence of action tasks (that return no result)")
        ' Continuations ignore antecedent data
        Task.Factory.StartNew(Sub() action("alpha")).ContinueWith(Sub(antecendent) action("beta")).ContinueWith(Sub(antecendent) action("gamma")).Wait()


        Dim negate As Func(Of Integer, Integer) = Function(n)
                                                      Console.WriteLine("Task={0}, n={1}, -n={2}, Thread={3}", Task.CurrentId, n, -n, Thread.CurrentThread.ManagedThreadId)
                                                      Return -n
                                                  End Function

        ' Creating a sequence of function tasks where each continuation uses the result from its antecendent
        Console.WriteLine(vbLf & "Creating a sequence of function tasks where each continuation uses the result from its antecendent")
        Task(Of Integer).Factory.StartNew(Function() negate(5)).ContinueWith(Function(antecendent) negate(antecendent.Result)).ContinueWith(Function(antecendent) negate(antecendent.Result)).Wait()


        ' Creating a sequence of tasks where you can mix and match the types
        Console.WriteLine(vbLf & "Creating a sequence of tasks where you can mix and match the types")
        Task(Of Integer).Factory.StartNew(Function() negate(6)).ContinueWith(Sub(antecendent) action("x")).ContinueWith(Function(antecendent) negate(7)).Wait()
    End Sub
End Module
'</snippet03>

