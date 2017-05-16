' <Snippet1>
Imports System
Imports System.Threading

Public Class Test

    <MTAThread> _
    Shared Sub Main()
        Dim newThread As New Thread(AddressOf TestMethod)
        newThread.Start()
        Thread.Sleep(1000)

        ' Abort newThread.
        Console.WriteLine("Main aborting new thread.")
        newThread.Abort("Information from Main.")

        ' Wait for the thread to terminate.
        newThread.Join()
        Console.WriteLine("New thread terminated - Main exiting.")
    End Sub

    Shared Sub TestMethod()
        Try
            While True
                Console.WriteLine("New thread running.")
                Thread.Sleep(1000)
            End While
        Catch abortException As ThreadAbortException
            Console.WriteLine( _
                CType(abortException.ExceptionState, String))
        End Try
    End Sub

End Class
' </Snippet1>