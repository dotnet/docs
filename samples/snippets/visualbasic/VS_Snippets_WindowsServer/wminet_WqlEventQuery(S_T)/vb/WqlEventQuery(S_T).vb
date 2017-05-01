'<Snippet1>
Imports System
Imports System.Management


Public Class EventSample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        ' Requests all instance creation events,
        ' with a specified latency of
        ' 10 seconds. The query created
        ' is "SELECT * FROM __InstanceCreationEvent WITHIN 10"
        Dim t As New TimeSpan(0, 0, 10)
        Dim q As New WqlEventQuery("__InstanceCreationEvent", t)

        MessageBox.Show(q.QueryString)

    End Function 'Main
End Class 'EventSample
'</Snippet1>