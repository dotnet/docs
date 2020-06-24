' <Snippet4>
Imports System.Threading
Imports System.Threading.Tasks

Module Example
    Public Sub Main()
        Dim parent = Task(Of Integer).Factory.StartNew(Function()
                                                           Console.WriteLine("Outer task executing.")
                                                           Dim child = Task(Of Integer).Factory.StartNew(Function()
                                                                                                             Console.WriteLine("Nested task starting.")
                                                                                                             Thread.SpinWait(5000000)
                                                                                                             Console.WriteLine("Nested task completing.")
                                                                                                             Return 42
                                                                                                         End Function)
                                                           Return child.Result


                                                       End Function)
        Console.WriteLine("Outer has returned {0}", parent.Result)
    End Sub
End Module
' The example displays the following output:
'       Outer task executing.
'       Nested task starting.
'       Detached task completing.
'       Outer has returned 42
' </Snippet4>
