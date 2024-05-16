'<Snippet1>
Imports System.Diagnostics.Tracing

'<Snippet2>
Class MyCompanyEventSource
    Inherits EventSource
    Public Shared Log As New MyCompanyEventSource()

    Public Sub Startup()
        WriteEvent(1)
    End Sub

    Public Sub OpenFileStart(ByVal fileName As String)
        WriteEvent(2, fileName)
    End Sub

    Public Sub OpenFileStop()
        WriteEvent(3)
    End Sub
End Class
'</Snippet2>

'<Snippet3>
Class Program

    Shared Sub Main(ByVal args() As String)
        MyCompanyEventSource.Log.Startup()
        ' ...
        MyCompanyEventSource.Log.OpenFileStart("SomeFile")
        ' ...
        MyCompanyEventSource.Log.OpenFileStop()

    End Sub
End Class
'</Snippet3>
'</Snippet1>