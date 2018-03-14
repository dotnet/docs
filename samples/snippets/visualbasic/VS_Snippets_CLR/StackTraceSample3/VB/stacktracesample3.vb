Imports System
Imports System.Diagnostics

Public Class MyConsoleApp

    Public Shared Sub Main()

        Dim myApp As New MyConsoleApp()
        myApp.MyPublicSub()

    End Sub

    Public Shared Sub MyPublicSub()
        Dim helperClass As New MyInnerClass()
        helperClass.ThrowsException()
    End Sub

End Class
'<snippet5>

Class MyInnerClass
    Sub ThrowsException()
        Try
            Throw New Exception("A problem was encountered.")

        Catch e As Exception
            ' Log the Exception. We do not want to reveal the 
            ' inner workings of the class, or be too verbose, so
            ' we will create a StackTrace with a single 
            ' StackFrame, where the frame is that of the calling method.
            '<snippet6>
            Dim frame As New StackFrame(1, True)
            Dim strace As New StackTrace(frame)            

            EventLog.WriteEntry(frame.GetMethod().Name, _
                                strace.ToString(), _
                                EventLogEntryType.Warning)
            '</snippet6>
        End Try
        ' Note that whenever this application is run, the EventLog
        ' contains an Event similar to the following Event.
        '
        '     Event Type: Warning
        '     Event Source:   MyPublicSub
        '     Event Category: None
        '     Event ID:   0
        '     Date:       6/17/2001
        '     Time:       6:39:56 PM
        '     User:       N/A
        '     Computer:   MYCOMPUTER
        '     Description:
        '
        '        at MyConsoleApp.MyPublicSub()
        '
        '     For more information, see Help and Support Center at
        '     http://go.microsoft.com/fwlink/events.asp.

    End Sub

End Class
'</snippet5>

