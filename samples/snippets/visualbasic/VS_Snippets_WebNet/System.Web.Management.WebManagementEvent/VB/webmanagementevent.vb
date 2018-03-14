 '*
'  *File name: WebManagementEvent.cs
'  *Purpose: Implements a custom WebManagementEvent type
'  *

' <Snippet1>
Imports System
Imports System.Text
Imports System.Web
Imports System.Web.Management


' Implements a custom 
' WebManagementEvent class. 

Public Class SampleWebManagementEvent
   Inherits WebManagementEvent
   Private eventInfo As StringBuilder
   
   
   ' <Snippet2>
   ' Invoked in case of events 
   ' identified only by their event code.
    Public Sub New(ByVal msg As String, _
    ByVal eventSource As Object, _
    ByVal eventCode As Integer)
        MyBase.New(msg, eventSource, eventCode)
        ' Perform custom initialization.
        eventInfo = New StringBuilder()
        eventInfo.Append(String.Format( _
        "Event created at: ", EventTime.ToString()))
    End Sub 'New
   
   ' </Snippet2>
   
   ' <Snippet3>
   ' Invoked in case of events identified 
   ' by their event code.and related 
   ' event detailed code.
    Public Sub New(ByVal msg As String, _
    ByVal eventSource As Object, _
    ByVal eventCode As Integer, _
    ByVal eventDetailCode As Integer)
        MyBase.New(msg, eventSource, _
        eventCode, eventDetailCode)
        ' Perform custom initialization.
        eventInfo = New StringBuilder()
        eventInfo.Append(String.Format( _
        "Event created at: ", EventTime.ToString()))
    End Sub 'New
   
   
   ' </Snippet3>
   ' <Snippet4>
   ' Raises the SampleWebRequestEvent.
   Public Overrides Sub Raise()
      ' Perform custom processing. 
        eventInfo.Append(String.Format( _
        "Event raised at: ", EventTime.ToString()))
      ' Raise the event.
      MyBase.Raise()
   End Sub 'Raise
   
   ' </Snippet4>
   
   ' <Snippet5>
   ' Obtains the current process information.
   Public Function GetProcessInfo() As String
      Dim tempPi As New StringBuilder()
      Dim pi As WebProcessInformation = ProcessInformation
        tempPi.Append( _
        (pi.ProcessName + Environment.NewLine))
        tempPi.Append( _
        (pi.ProcessID.ToString() + Environment.NewLine))
        tempPi.Append( _
        (pi.AccountName + Environment.NewLine))
      Return tempPi.ToString()
   End Function 'GetProcessInfo
   
   ' </Snippet5>
   
   ' <Snippet6>
    Public Overrides Sub FormatCustomEventDetails( _
    ByVal formatter As WebEventFormatter)
        MyBase.FormatCustomEventDetails(formatter)

        ' Add custom data.
        formatter.AppendLine("")

        formatter.IndentationLevel += 1
        formatter.AppendLine( _
        "** SampleWebManagementEvent Start **")

        ' Add custom data.
        formatter.AppendLine(eventInfo.ToString())

        formatter.AppendLine( _
        "** SampleWebManagementEvent End **")
    End Sub 'FormatCustomEventDetails
    ' </Snippet6>
End Class 'SampleWebManagementEvent 

' </Snippet1>