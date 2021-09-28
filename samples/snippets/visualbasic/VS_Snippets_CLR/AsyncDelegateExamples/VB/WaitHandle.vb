' <Snippet3>
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

            Thread.Sleep(0)
            Console.WriteLine("Main thread {0} does some work.", _
                Thread.CurrentThread.ManagedThreadId)
            ' Perform additional processing here and then
            ' wait for the WaitHandle to be signaled.
            result.AsyncWaitHandle.WaitOne()

            ' Call EndInvoke to retrieve the results.
            Dim returnValue As String = caller.EndInvoke(threadId, result)

            ' Close the wait handle.
            result.AsyncWaitHandle.Close()

            Console.WriteLine("The call executed on thread {0}, with return value ""{1}"".", _
                threadId, returnValue)
        End Sub
    End Class
End Namespace

'This example produces output similar to the following:
'
'Main thread 1 does some work.
'Test method begins.
'The call executed on thread 3, with return value "My call time was 3000.".
' </Snippet3>

