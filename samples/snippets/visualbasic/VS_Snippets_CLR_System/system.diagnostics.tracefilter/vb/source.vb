'<Snippet1>
#Const TRACE = True

Imports System
Imports System.Diagnostics

Namespace TestingTracing
    Class TraceTest
        Public Shared Sub Main()
            Dim ts As New TraceSource("TraceTest")
            Dim sourceSwitch As New SourceSwitch("SourceSwitch", "Verbose")
            ts.Switch = sourceSwitch
            Dim ctl As new ConsoleTraceListener()
            ctl.Name = "console"
            ctl.TraceOutputOptions = TraceOptions.DateTime
            ctl.Filter = New ErrorFilter()
            ts.Listeners.Add(ctl)

            ts.TraceEvent(TraceEventType.Warning, 1, "*** This event will be filtered out ***")
            ts.TraceEvent(TraceEventType.Error, 2, "*** This event will be be displayed ***")

            ts.Flush()
            ts.Close()
        End Sub
    End Class

    '<Snippet2>
    Public Class ErrorFilter
        Inherits TraceFilter

        Public Overrides Function ShouldTrace ( cache As TraceEventCache, _
                    source As String, eventType As TraceEventType, _
                    id As Integer, formatOrMessage As String, _
                    args As Object(), data As Object, _
                    dataArray As Object() ) As Boolean
            If eventType = TraceEventType.Error Then
                Return True
            Else
                Return False
            End If
        End Function
    End Class
    '</Snippet2>
End Namespace
'</Snippet1>
