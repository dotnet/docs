'<Snippet1>
Imports System.Diagnostics.Tracing

'<Snippet2>
Class MyCompanyEventSource
    Inherits EventSource
    Public Shared Log As New MyCompanyEventSource()

    Public Sub Startup()
        WriteEvent(1)
    End Sub 'Startup

    Public Sub OpenFileStart(ByVal fileName As String)
        WriteEvent(2, fileName)
    End Sub 'OpenFileStart

    Public Sub OpenFileStop()
        WriteEvent(3)
    End Sub 'OpenFileStop
End Class 'MyCompanyEventSource 
'</Snippet2>

'<Snippet3>
Class Program

    Shared Sub Main(ByVal args() As String)
        MyCompanyEventSource.Log.Startup()
        ' ...
        MyCompanyEventSource.Log.OpenFileStart("SomeFile")
        ' ...
        MyCompanyEventSource.Log.OpenFileStop()

    End Sub 'Main
End Class 'Program
'</Snippet3>
'</Snippet1>