 '*
'  *File name: WebAuthenticationFailureAuditEvent.cs
'  *Purpose: Implements a custom WebAuthenticationFailureAuditEvent type
'  *by inheriting from the System.Web.Management.WebAuthenticationFailureAuditEvent class
'  *

' <Snippet1>
Imports System
Imports System.Text
Imports System.Web
Imports System.Web.Management


' Implements a custom WebAuthenticationFailureAuditEvent class. 

Public Class SampleWebAuthenticationFailureAuditEvent
    Inherits System.Web.Management.WebAuthenticationFailureAuditEvent
    Private customCreatedMsg, customRaisedMsg As String



    ' <Snippet2>
    ' Invoked in case of events identified only by their event code.
    Public Sub New(ByVal msg As String, ByVal eventSource _
    As Object, ByVal eventCode As Integer, _
    ByVal userName As String)
        MyBase.New(msg, eventSource, eventCode, userName)
        ' Perform custom initialization.
        customCreatedMsg = _
        String.Format("Event created at: {0}", _
        DateTime.Now.TimeOfDay.ToString())

    End Sub 'New

    ' </Snippet2>

    ' <Snippet3>
    ' Invoked in case of events identified by their event code.and 
    ' event detailed code.
    Public Sub New(ByVal msg As String, ByVal eventSource As Object, _
    ByVal eventCode As Integer, ByVal detailedCode As Integer, _
    ByVal userName As String)
        MyBase.New(msg, eventSource, eventCode, _
        detailedCode, userName)
        ' Perform custom initialization.
        customCreatedMsg = _
        String.Format( _
        "Event created at: {0}", DateTime.Now.TimeOfDay.ToString())

    End Sub 'New


    ' </Snippet3>

    ' <Snippet4>
    ' Raises the SampleWebAuthenticationFailureAuditEvent.
    Public Overrides Sub Raise()
        ' Perform custom processing.
        customRaisedMsg = String.Format( _
        "Event raised at: {0}", _
        DateTime.Now.TimeOfDay.ToString())

        ' Raise the event.
        WebBaseEvent.Raise(Me)

    End Sub 'Raise

    ' </Snippet4>

    ' <Snippet5>
    ' Obtains the current thread information.
    Public Function GetRequestInformation() _
    As WebRequestInformation
        ' No customization is allowed.
        Return RequestInformation

    End Function 'GetRequestInformation

    ' </Snippet5>

    ' <Snippet6>
    'Formats Web request event information.
    'This method is invoked indirectly by the provider 
    'using one of the overloaded ToString methods.
    Public Overrides Sub FormatCustomEventDetails(ByVal formatter _
    As WebEventFormatter)
        MyBase.FormatCustomEventDetails(formatter)

        ' Add custom data.
        formatter.AppendLine("")

        formatter.IndentationLevel += 1
        formatter.AppendLine( _
        "* SampleWebAuthenticationFailureAuditEvent Start *")
        formatter.AppendLine( _
        String.Format("Request path: {0}", _
        RequestInformation.RequestPath))
        formatter.AppendLine( _
        String.Format("Request Url: {0}", _
        RequestInformation.RequestUrl))

        ' Display custom event timing.
        formatter.AppendLine(customCreatedMsg)
        formatter.AppendLine(customRaisedMsg)

        formatter.AppendLine( _
        "* SampleWebAuthenticationFailureAuditEvent End *")

        formatter.IndentationLevel -= 1

    End Sub 'FormatCustomEventDetails 
End Class 'SampleWebAuthenticationFailureAuditEvent
' </Snippet6>

' </Snippet1>