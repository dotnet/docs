'<snippet13>
Imports System.Diagnostics
'</snippet13>

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim t As Type = GetType(SimpleListener)
        MsgBox(t.FullName & ", " & t.Assembly.FullName)
        DisplayStrongName()
        'MsgBox(GetListeners(My.Application.Log.TraceSource.Listeners))
        Trace.TraceInformation("trace information")
        Trace.TraceError("trace error")
        My.Application.Log.WriteEntry("Information", TraceEventType.Information)
        My.Application.Log.WriteEntry("Error", TraceEventType.Error)
    End Sub

    '<snippet18>
    Public Sub TestSimpleListener()
        My.Application.Log.WriteEntry("Hello SimpleListener")
    End Sub
    '</snippet18>
    '<snippet17>
    Public Sub DisplaySimpleListenerStrongName()
        Dim t As Type = GetType(SimpleListener)
        MsgBox(t.FullName & ", " & t.Assembly.FullName)
    End Sub
    '</snippet17>

    '<snippet15>
    Public Sub DisplayStrongName()
        Dim t As Type = GetType(Logging.FileLogTraceListener)
        MsgBox(t.FullName & ", " & t.Assembly.FullName)
    End Sub
    '</snippet15>

    Private Sub Snippet19()
        '<snippet19>
        Dim ListenerCollection As TraceListenerCollection
        ListenerCollection = My.Application.Log.TraceSource.Listeners
        Dim ListenersText As String = GetListeners(ListenerCollection)
        MsgBox(ListenersText)
        '</snippet19>
    End Sub

    '<snippet14>
    Function GetListeners(ByVal listeners As TraceListenerCollection) As String
        Dim ret As String = ""
        For Each listener As TraceListener In listeners
            ret &= listener.Name
            Dim listenerType As Type = listener.GetType
            If listenerType Is GetType(DefaultTraceListener) Then
                Dim tmp As DefaultTraceListener =
                    DirectCast(listener, DefaultTraceListener)
                ret &= ": Writes to the debug output."
            ElseIf listenerType Is GetType(Logging.FileLogTraceListener) Then
                Dim tmp As Logging.FileLogTraceListener =
                    DirectCast(listener, Logging.FileLogTraceListener)
                ret &= ": Log filename: " & tmp.FullLogFileName
            ElseIf listenerType Is GetType(EventLogTraceListener) Then
                Dim tmp As EventLogTraceListener =
                    DirectCast(listener, EventLogTraceListener)
                ret &= ": Event log name: " & tmp.EventLog.Log
            ElseIf listenerType Is GetType(XmlWriterTraceListener) Then
                Dim tmp As Diagnostics.XmlWriterTraceListener =
                    DirectCast(listener, XmlWriterTraceListener)
                ret &= ": XML log"
            ElseIf listenerType Is GetType(ConsoleTraceListener) Then
                Dim tmp As ConsoleTraceListener =
                    DirectCast(listener, ConsoleTraceListener)
                ret &= ": Console log"
            ElseIf listenerType Is GetType(DelimitedListTraceListener) Then
                Dim tmp As DelimitedListTraceListener =
                    DirectCast(listener, DelimitedListTraceListener)
                ret &= ": Delimited log"
            Else
                ret &= ": Unhandled log type: " &
                    listenerType.ToString
            End If
            ret &= vbCrLf
        Next

        Return ret
    End Function
    '</snippet14>

    '<snippet11>
    Public Sub TracingTest(ByVal fileName As String)
        My.Application.Log.WriteEntry(
            "Entering TracingTest with argument " &
            fileName & ".")
        ' Code to trace goes here.
        My.Application.Log.WriteEntry(
            "Exiting TracingTest with argument " &
            fileName & ".")
    End Sub
    '</snippet11>


    '<snippet10>
    Public Sub ExceptionLogTest(ByVal fileName As String)
        Try
            '<snippet7>
            ' Code that might generate an exception goes here.
            ' For example:
            '    Dim x As Object
            '    MsgBox(x.ToString)
            '</snippet7>
        Catch ex As Exception
            '<snippet8>
            My.Application.Log.WriteException(ex,
                TraceEventType.Error,
                "Exception in ExceptionLogTest " &
                "with argument " & fileName & ".")
            '</snippet8>
        End Try
    End Sub
    '</snippet10>
End Class
Class extra
    Private Sub extra()
        '<snippet6>
        Try
        Catch ex As Exception
        End Try
        '</snippet6>
    End Sub
    '<snippet9>
    Public Sub ExceptionLogTest(ByVal fileName As String)
    End Sub
    '</snippet9>
End Class


'<snippet16>
Public Class SimpleListener
    Inherits System.Diagnostics.TraceListener

    <Security.Permissions.HostProtection(Synchronization:=True)>
    Public Overloads Overrides Sub Write(ByVal message As String)
        MsgBox("Write: " & message)
    End Sub

    <Security.Permissions.HostProtection(Synchronization:=True)>
    Public Overloads Overrides Sub WriteLine(ByVal message As String)
        MsgBox("WriteLine: " & message)
    End Sub
End Class
'</snippet16>
