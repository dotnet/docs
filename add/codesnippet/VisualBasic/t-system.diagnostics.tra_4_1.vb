Imports System.Diagnostics.Tracing

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

Class Program

    Shared Sub Main(ByVal args() As String)
        MyCompanyEventSource.Log.Startup()
        ' ...
        MyCompanyEventSource.Log.OpenFileStart("SomeFile")
        ' ...
        MyCompanyEventSource.Log.OpenFileStop()

    End Sub 'Main
End Class 'Program