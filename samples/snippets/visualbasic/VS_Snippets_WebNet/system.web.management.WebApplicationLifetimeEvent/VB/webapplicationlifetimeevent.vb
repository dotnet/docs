 '*
'  *File name: WebApplicationLifeTimeEvent.vb
'  *Purpose: Implements a custom WebApplicationLifeTimeEvent type
'  *

' <Snippet1>
Imports System
Imports System.Text
Imports System.Web
Imports System.Web.Management


' Implements a custom WebManagementEvent class. 

Public Class SampleWebApplicationLifetimeEvent
    Inherits System.Web.Management.WebApplicationLifetimeEvent
    Private customCreatedMsg, customRaisedMsg As String
    
    ' <Snippet2>
    ' Invoked in case of events identified only by 
    ' their event code.
    Public Sub New(ByVal msg As String, _
    ByVal eventSource As Object, _
    ByVal eventCode As Integer)
        MyBase.New(msg, eventSource, eventCode)
        ' Perform custom initialization.
        customCreatedMsg = _
        String.Format("Event created at: {0}", _
        DateTime.Now.TimeOfDay.ToString())

    End Sub 'New
    
    ' </Snippet2>
    
    ' <Snippet3>
    ' Invoked in case of events identified by their 
    ' event code.and related event detailed code.
    Public Sub New(ByVal msg As String, _
    ByVal eventSource As Object, _
    ByVal eventCode As Integer, _
    ByVal eventDetailCode As Integer)
        MyBase.New(msg, eventSource, _
        eventCode, eventDetailCode)
        ' Perform custom initialization.
        customCreatedMsg = _
        String.Format("Event created at: {0}", _
        DateTime.Now.TimeOfDay.ToString())
    End Sub 'New

    ' </Snippet3>

    ' <Snippet4>
    ' Raises the SampleWebRequestEvent.
    Public Overrides Sub Raise() 
        ' Perform custom processing. 
        customRaisedMsg = _
        String.Format("Event raised at: {0}" + _
        vbLf, DateTime.Now.TimeOfDay.ToString())
        ' Raise the event.
        MyBase.Raise()
    
    End Sub 'Raise
    
    ' </Snippet4>
    ' <Snippet5>
    'Formats Web request event information.
    Public Overrides Sub FormatCustomEventDetails( _
    ByVal formatter As WebEventFormatter)
        MyBase.FormatCustomEventDetails(formatter)

        ' Add custom data.
        formatter.AppendLine("")

        formatter.IndentationLevel += 1

        formatter.TabSize = 4

        formatter.AppendLine( _
        "*SampleWebApplicationLifetimeEvent Start *")
        formatter.AppendLine("Custom information goes here")
        formatter.AppendLine( _
        "* SampleWebApplicationLifetimeEvent End *")
        ' Display custom event timing.
        formatter.AppendLine(customCreatedMsg)
        formatter.AppendLine(customRaisedMsg)

        formatter.IndentationLevel -= 1

    End Sub 'FormatCustomEventDetails 
End Class 'SampleWebApplicationLifetimeEvent
' </Snippet5>

' </Snippet1>