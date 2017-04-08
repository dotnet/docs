 '*
'  *File name: WebErrorEvent.cs
'  *Purpose: Implements a custom WebErrorEvent type
'  *by inheriting from the System.Web.Management.WebErrorEvent.
'  *

' <Snippet1>
Imports System
Imports System.Text
Imports System.Web
Imports System.Web.Management


' Implements a custom WebErrorEvent class. 

Public Class SampleWebErrorEvent
   Inherits WebErrorEvent
   Private eventInfo As StringBuilder
   
   
   ' <Snippet2>
   ' Invoked in case of events identified 
   ' only by their event code.
    Public Sub New(ByVal msg As String, _
    ByVal eventSource As Object, _
    ByVal eventCode As Integer, ByVal e As Exception)
        MyBase.New(msg, eventSource, eventCode, e)
        ' Perform custom initialization.
        eventInfo = New StringBuilder()
        eventInfo.Append(String.Format( _
        "Event created at: ", EventTime.ToString()))
    End Sub 'New
   
   ' </Snippet2>
   
   ' <Snippet3>
   ' Invoked in case of events identified 
   ' by their event code.and 
   ' related event detailed code.
    Public Sub New(ByVal msg As String, ByVal eventSource _
    As Object, ByVal eventCode As Integer, _
    ByVal detailedCode As Integer, ByVal e As Exception)
        MyBase.New(msg, eventSource, _
        eventCode, detailedCode, e)
        ' Perform custom initialization.
        eventInfo = New StringBuilder()
        eventInfo.Append(String.Format( _
        "Event created at: ", EventTime.ToString()))
    End Sub 'New
   
   
   ' </Snippet3>
   ' <Snippet4>
   ' Raises the SampleWebErrorEvent.
   Public Overrides Sub Raise()
      ' Perform custom processing. 
        eventInfo.Append(String.Format( _
        "Event raised at: ", EventTime.ToString()))
      
      ' Raise the event.
      MyBase.Raise()
   End Sub 'Raise
   
   ' </Snippet4>
   ' <Snippet5>
   ' Obtains the current request information.
   Public Function GetRequestInfo() As String
      Dim reqInfo As String = GetRequestInfo()
      Return reqInfo
   End Function 'GetRequestInfo
   
   ' </Snippet5>
   
   ' <Snippet6>
   ' Obtains the current thread information.
   Public Function GetThreadInfo() As String
      Dim threadInfo As String = GetThreadInfo()
      Return threadInfo
   End Function 'GetThreadInfo
   
   ' </Snippet6>
   
   ' <Snippet7>
   ' Obtains the current process information.
   Public Function GetProcessInfo() As String
      Dim procInfo As String = GetProcessInfo()
      Return procInfo
   End Function 'GetProcessInfo
   
   ' </Snippet7>
   
   ' <Snippet8>
   'Formats Web request event information..
    Public Overrides Sub FormatCustomEventDetails( _
    ByVal formatter As WebEventFormatter)

        MyBase.FormatCustomEventDetails(formatter)

        ' Add custom data.
        formatter.AppendLine("")

        formatter.IndentationLevel += 1
        formatter.AppendLine( _
        "** SampleWebErrorEvent Start **")

        formatter.AppendLine(eventInfo.ToString())

        formatter.AppendLine( _
        "** SampleWebBaseErrorEvent End **")

        formatter.IndentationLevel -= 1
    End Sub 'FormatCustomEventDetails 
    ' </Snippet8>

End Class 'SampleWebErrorEvent 


' </Snippet1>