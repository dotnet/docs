 '*
'  *File name: WebProcessInformation.vb
'  *Purpose: Implements a custom type to acess 
'  *the process information.: 
'  *

' <Snippet1>
Imports System
Imports System.Text
Imports System.Web
Imports System.Web.Management


' Implements a custom WebBaseEvent type that 
' uses WebProcessInformation.

Public Class SampleWebProcessInformation
   Inherits WebBaseEvent
   Private eventInfo As StringBuilder
    Private Shared processInformation _
    As WebProcessInformation
   
   ' <Snippet2>
   ' Instantiate SampleWebProcessInformation.    
    Public Sub New(ByVal msg As String, _
    ByVal eventSource As Object, ByVal eventCode As Integer)
        MyBase.New(msg, eventSource, eventCode)
        ' Perform custom initialization.
        eventInfo = New StringBuilder
        eventInfo.Append(String.Format( _
        "Event created at: {0}", _
        EventTime.ToString()))

    End Sub 'New
   
   ' </Snippet2>
   ' <Snippet3>
   ' Raises the event.
   Public Overrides Sub Raise()
      ' Perform custom processing. 
        eventInfo.Append(String.Format( _
        "Event raised at: {0}", _
        EventTime.ToString()))
      
      ' Raise the event.
      MyBase.Raise()
   End Sub 'Raise
   
   ' </Snippet3>
   ' <Snippet4>
   Public Function GetAccountName() As String
      ' Get the name of the account.
        Return String.Format("Account name: {0}", _
        processInformation.AccountName)
   End Function 'GetAccountName
   
   ' </Snippet4>
   ' <Snippet5>
   Public Function GetProcessId() As String
      ' Get the process identifier.
        Return String.Format("Process Id: {0}", _
        processInformation.ProcessID.ToString())
   End Function 'GetProcessId
   
   ' </Snippet5>
   ' <Snippet6>
   Public Function GetProcessName() As String
      ' Get the requests in execution.
        Return String.Format("Process name: {0}", _
        ProcessInformation.ProcessName)
   End Function 'GetProcessName
   
   ' </Snippet6>
   ' <Snippet7>
    'Formats Web request event information.
    Public Overrides Sub FormatCustomEventDetails( _
    ByVal formatter _
    As System.Web.Management.WebEventFormatter)
        MyBase.FormatCustomEventDetails(formatter)
   
        ' Add custom data.
        formatter.AppendLine("")
        formatter.AppendLine( _
        "Custom Process Information:")
        formatter.IndentationLevel += 1

        ' Display the process information.
        formatter.AppendLine(GetAccountName())
        formatter.AppendLine(GetProcessId())
        formatter.AppendLine(GetProcessName())
        formatter.IndentationLevel -= 1
        formatter.AppendLine(eventInfo.ToString())
    End Sub 'FormatToString
    ' </Snippet7>

End Class 'SampleWebProcessInformation 

' </Snippet1>