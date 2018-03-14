' <Snippet1>
Imports System
Imports System.Threading
Imports System.Runtime.InteropServices 

Namespace Examples.AdvancedProgramming.AsynchronousOperations
    Public Class AsyncDemo 
        ' The method to be executed asynchronously.
        Public Function TestMethod(ByVal callDuration As Integer, _
                <Out> ByRef threadId As Integer) As String
            Console.WriteLine("Test method begins.")
            Thread.Sleep(callDuration)
            threadId = Thread.CurrentThread.ManagedThreadId()
            return String.Format("My call time was {0}.", callDuration.ToString())
        End Function
    End Class

    ' The delegate must have the same signature as the method
    ' it will call asynchronously.
    Public Delegate Function AsyncMethodCaller(ByVal callDuration As Integer, _
        <Out> ByRef threadId As Integer) As String
End Namespace
'</Snippet1>