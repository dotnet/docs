' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Threading
Imports System.Threading.Tasks

Module Example
    Public Sub Main()
        Dim parent = Task.Factory.StartNew(Sub()
                                               Console.WriteLine("Outer task executing.")
                                               Dim child = Task.Factory.StartNew(Sub()
                                                                                     Console.WriteLine("Nested task starting.")
                                                                                     Thread.SpinWait(500000)
                                                                                     Console.WriteLine("Nested task completing.")
                                                                                 End Sub)
                                           End Sub)
        parent.Wait()
        Console.WriteLine("Outer task has completed.")
    End Sub
End Module
' The example produces output like the following:
'   Outer task executing.
'   Nested task starting.
'   Outer task has completed.
'   Nested task completing.
'</snippet1>


