' How to: Cancel Threads Cooperatively
' <snippet12>
Imports System.Threading

Public Class ServerClass
    Public Shared Sub StaticMethod(obj As Object)
        Dim ct AS CancellationToken = CType(obj, CancellationToken)
        Console.WriteLine("ServerClass.StaticMethod is running on another thread.")

        ' Simulate work that can be canceled.
        While Not ct.IsCancellationRequested
            Thread.SpinWait(50000)
        End While
        Console.WriteLine("The worker thread has been canceled. Press any key to exit.")
        Console.ReadKey(True)
    End Sub
End Class

Public Class Simple
    Public Shared Sub Main()
        ' The Simple class controls access to the token source.
        Dim cts As New CancellationTokenSource()

        Console.WriteLine("Press 'C' to terminate the application..." + vbCrLf)
        ' Allow the UI thread to capture the token source, so that it
        ' can issue the cancel command.
        Dim t1 As New Thread(Sub()
                                 If Console.ReadKey(true).KeyChar.ToString().ToUpperInvariant() = "C" Then
                                     cts.Cancel()
                                 End If
                             End Sub)

        ' ServerClass sees only the token, not the token source.
        Dim t2 As New Thread(New ParameterizedThreadStart(AddressOf ServerClass.StaticMethod))

        ' Start the UI thread.
        t1.Start()

        ' Start the worker thread and pass it the token.
        t2.Start(cts.Token)

        t2.Join()
        cts.Dispose()
    End Sub
End Class
' The example displays the following output:
'       Press 'C' to terminate the application...
'
'       ServerClass.StaticMethod is running on another thread.
'       The worker thread has been canceled. Press any key to exit.
' </snippet12>
