'<Snippet1>
Imports System
Imports System.Management


Public Class EventSample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        ' Requests notification of the creation
        ' of Win32_Service instances with a 10 second
        ' allowed latency.
        Dim t As New TimeSpan(0, 0, 10)
        Dim q As New WqlEventQuery("__InstanceCreationEvent", _
            t, "TargetInstance isa ""Win32_Service""")

        MessageBox.Show(q.QueryString)

    End Function 'Main
End Class 'EventSample
'</Snippet1>