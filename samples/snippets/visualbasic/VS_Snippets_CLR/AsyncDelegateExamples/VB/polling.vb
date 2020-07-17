' <Snippet4>
Imports System.Threading
Imports System.Runtime.InteropServices

Namespace Examples.AdvancedProgramming.AsynchronousOperations

    Public Class AsyncMain
        Shared Sub Main()
            ' The asynchronous method puts the thread id here.
            Dim threadId As Integer

            ' Create an instance of the test class.
            Dim ad As New AsyncDemo()

            ' Create the delegate.
            Dim caller As New AsyncMethodCaller(AddressOf ad.TestMethod)

            ' Initiate the asynchronous call.
            Dim result As IAsyncResult = caller.BeginInvoke(3000, _
                threadId, Nothing, Nothing)

            ' Poll while simulating work.
            While result.IsCompleted = False
                Thread.Sleep(250)
                Console.Write(".")
            End While

            ' Call EndInvoke to retrieve the results.
            Dim returnValue As String = caller.EndInvoke(threadId, result)

            Console.WriteLine(vbCrLf & _
                "The call executed on thread {0}, with return value ""{1}"".", _
                threadId, returnValue)
        End Sub
    End Class
End Namespace

' This example produces output similar to the following:
'
'Test method begins.
'.............
'The call executed on thread 3, with return value "My call time was 3000.".
' </Snippet4>
