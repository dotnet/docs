' <Snippet1>
Imports System
Imports System.Threading

Public Class Name

    <MTAThread> _
    Shared Sub Main()

        ' Check whether the thread has previously been named
        ' to avoid a possible InvalidOperationException.
        If Thread.CurrentThread.Name = Nothing Then
            Thread.CurrentThread.Name = "MainThread"
        Else
            Console.WriteLine("Unable to name a previously " & _
                "named thread.")
        End If

    End Sub
End Class
' </Snippet1>