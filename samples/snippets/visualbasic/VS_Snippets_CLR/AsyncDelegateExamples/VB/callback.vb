' <Snippet5>
Imports System.Threading
Imports System.Runtime.Remoting.Messaging

Namespace Examples.AdvancedProgramming.AsynchronousOperations

    Public Class AsyncMain

        Shared Sub Main()

            ' Create an instance of the test class.
            Dim ad As New AsyncDemo()

            ' Create the delegate.
            Dim caller As New AsyncMethodCaller(AddressOf ad.TestMethod)

            ' The threadId parameter of TestMethod is an <Out> parameter, so
            ' its input value is never used by TestMethod. Therefore, a dummy
            ' variable can be passed to the BeginInvoke call. If the threadId
            ' parameter were a ByRef parameter, it would have to be a class-
            ' level field so that it could be passed to both BeginInvoke and 
            ' EndInvoke.
            Dim dummy As Integer = 0

            ' Initiate the asynchronous call, passing three seconds (3000 ms)
            ' for the callDuration parameter of TestMethod; a dummy variable 
            ' for the <Out> parameter (threadId); the callback delegate; and
            ' state information that can be retrieved by the callback method.
            ' In this case, the state information is a string that can be used
            ' to format a console message.
            Dim result As IAsyncResult = caller.BeginInvoke(3000, _
                dummy, _
                AddressOf CallbackMethod, _
                "The call executed on thread {0}, with return value ""{1}"".")

            Console.WriteLine("The main thread {0} continues to execute...", _
                Thread.CurrentThread.ManagedThreadId)

            ' The callback is made on a ThreadPool thread. ThreadPool threads
            ' are background threads, which do not keep the application running
            ' if the main thread ends. Comment out the next line to demonstrate
            ' this.
            Thread.Sleep(4000)

            Console.WriteLine("The main thread ends.")
        End Sub

        ' The callback method must have the same signature as the
        ' AsyncCallback delegate.
        Shared Sub CallbackMethod(ByVal ar As IAsyncResult)
            ' Retrieve the delegate.
            Dim result As AsyncResult = CType(ar, AsyncResult)
            Dim caller As AsyncMethodCaller = CType(result.AsyncDelegate, AsyncMethodCaller)

            ' Retrieve the format string that was passed as state 
            ' information.
            Dim formatString As String = CType(ar.AsyncState, String)

            ' Define a variable to receive the value of the <Out> parameter.
            ' If the parameter were ByRef rather than <Out> then it would have to
            ' be a class-level field so it could also be passed to BeginInvoke.
            Dim threadId As Integer = 0

            ' Call EndInvoke to retrieve the results.
            Dim returnValue As String = caller.EndInvoke(threadId, ar)

            ' Use the format string to format the output message.
            Console.WriteLine(formatString, threadId, returnValue)
        End Sub
    End Class
End Namespace

' This example produces output similar to the following:
'
'The main thread 1 continues to execute...
'Test method begins.
'The call executed on thread 3, with return value "My call time was 3000.".
'The main thread ends.
' </Snippet5>

