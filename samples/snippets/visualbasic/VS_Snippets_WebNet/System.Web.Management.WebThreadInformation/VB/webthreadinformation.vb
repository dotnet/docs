 '*
'  *File name: WebThreadInformation.cs
'  *Purpose: Implements a custom type to 
' * access the thread information. 
'  *

' <Snippet1>
Imports System
Imports System.Text
Imports System.Web
Imports System.Web.Management



' Implements a custom WebErrorstEvent that uses the 
' WebThreadInformation. 

Public Class SampleWebThreadInformation
   Inherits WebErrorEvent
   Private eventInfo As StringBuilder
   
   
   ' <Snippet2>
   ' Instantiate events identified 
   ' only by their event code.
    Public Sub New(ByVal msg As String, _
    ByVal eventSource As Object, _
    ByVal eventCode As Integer, ByVal e As Exception)
        MyBase.New(msg, eventSource, eventCode, e)
        ' Perform custom initialization.
        eventInfo = New StringBuilder()
        eventInfo.Append(String.Format("Event created at: {0}", EventTime.ToString()))
    End Sub 'New
   
   
   ' </Snippet2>
   
   ' <Snippet3>
   ' Raises the event.
   Public Overrides Sub Raise()
      ' Perform custom processing. 
        eventInfo.Append(String.Format( _
        "Event raised at: {0}", EventTime.ToString()))
      ' Raise the event.
      MyBase.Raise()
   End Sub 'Raise
   
   ' </Snippet3>
   ' <Snippet4>
   ' Get the impersonation mode.
   Public Function GetThreadImpersonation() As String
        Return String.Format( _
        "Is impersonating: {0}", _
        ThreadInformation.IsImpersonating.ToString())
   End Function 'GetThreadImpersonation
   
   ' </Snippet4>
   ' <Snippet5>
   ' Get the stack trace.
   Public Function GetThreadStackTrace() As String
        Return String.Format( _
        "Stack trace: {0}", _
        ThreadInformation.StackTrace)
   End Function 'GetThreadStackTrace
   
   ' </Snippet5>
   ' <Snippet6>
   ' Get the account name.
   Public Function GetThreadAccountName() As String
        Return String.Format( _
        "Request user host address: {0}", _
        ThreadInformation.ThreadAccountName)
   End Function 'GetThreadAccountName
   
   ' </Snippet6>
   ' <Snippet7>
   ' Get the task Id.
   Public Function GetThreadId() As String
      ' Get the request principal.
        Return String.Format( _
        "Thread Id: {0}", _
        ThreadInformation.ThreadID.ToString())
   End Function 'GetThreadId
   
   ' </Snippet7>
   ' <Snippet8>
   ' Formats Web request event information.
    Public Overrides Sub FormatCustomEventDetails( _
    ByVal formatter As WebEventFormatter)

        ' Add custom data.
        formatter.AppendLine("")
        formatter.AppendLine( _
        "Custom Thread Information:")

        formatter.IndentationLevel += 1

        ' Display the thread information obtained 
        formatter.AppendLine(GetThreadImpersonation())
        formatter.AppendLine(GetThreadStackTrace())
        formatter.AppendLine(GetThreadAccountName())
        formatter.AppendLine(GetThreadId())
        formatter.IndentationLevel -= 1

        formatter.AppendLine(eventInfo.ToString())
    End Sub 'FormatCustomEventDetails 
    ' </Snippet8>

End Class 'SampleWebThreadInformation



' </Snippet1>