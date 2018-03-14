' <Snippet2>
Imports System
Imports System.Diagnostics

Public Class TraceErr
    ' <Snippet3>
    Private Shared appSwitch As new TraceSwitch("mySwitch", _
        "Switch in config file")

    Public Shared Sub Main(args As String())
        '...
        Console.WriteLine("Trace switch {0} configured as {1}",
        appSwitch.DisplayName, appSwitch.Level.ToString())
        If appSwitch.TraceError = True  Then
            '...
        End If
    End Sub
    ' </Snippet3>
End Class
' </Snippet2>
