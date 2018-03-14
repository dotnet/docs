'<Snippet1>
Imports System
Imports System.Management


Public Class EventSample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        ' Requests sending aggregated events
        ' if the number of events exceeds 15.
        Dim props() As String = {"TargetInstance.SourceName"}
        Dim t As New TimeSpan(0, 10, 0)
        Dim q As New WqlEventQuery("__InstanceCreationEvent", _
            System.TimeSpan.MaxValue, _
            "TargetInstance isa ""Win32_NTLogEvent""", _
            t, _
            props, _
            "NumberOfEvents >15")

        MessageBox.Show(q.QueryString)

    End Function 'Main
End Class 'EventSample
'</Snippet1>