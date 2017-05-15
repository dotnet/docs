 '*
'  *File name: WebRequestInformation.cs
'  *Purpose: Implements a custom type to 
' * access the request information. 
'  *

' <Snippet1>
Imports System
Imports System.Text
Imports System.Web
Imports System.Web.Management
Imports System.Web.UI
Imports System.Web.UI.WebControls


' Implements a custom WebRequestEvent that uses
' WebRequestInformation. 

Public Class SampleWebRequestInformation
   Inherits WebRequestEvent
   Private eventInfo As StringBuilder
   
   
   ' <Snippet2>
   ' Instantiate events identified 
   ' only by their event code.
    Public Sub New(ByVal msg As String, _
    ByVal eventSource As Object, _
    ByVal eventCode As Integer)
        MyBase.New(msg, eventSource, eventCode)
        ' Perform custom initialization.
        eventInfo = New StringBuilder()
        eventInfo.Append(String.Format( _
        "Event created at: {0}", EventTime.ToString()))
    End Sub 'New
   
   ' </Snippet2>
   
   ' <Snippet3>
   ' Instantiate events identified by 
   ' their event code.and related 
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
        "Event created at: {0}", EventTime.ToString()))
    End Sub 'New
   
   
   ' </Snippet3>
   ' <Snippet4>
   ' Raises the event.
   Public Overrides Sub Raise()
      ' Perform custom processing. 
        eventInfo.Append(String.Format( _
        "Event raised at: {0}", EventTime.ToString()))
      ' Raise the event.
      MyBase.Raise()
   End Sub 'Raise
   
   ' </Snippet4>
   ' <Snippet5>
   ' Get the request path.
   Public Function GetRequestPath() As String
      ' Get the request path.
        Return String.Format( _
        "Request path: {0}", RequestInformation.RequestPath)
   End Function 'GetRequestPath
   
   ' </Snippet5>
   ' <Snippet6>
   ' Get the request URL.
   Public Function GetRequestUrl() As String
      ' Get the request URL.
        Return String.Format("Request URL: {0}", _
        RequestInformation.RequestUrl)
   End Function 'GetRequestUrl
   
   ' </Snippet6>
   ' <Snippet7>
   ' Get the request user host address.
   Public Function GetRequestUserHostAdddress() As String
      ' Get the request user host address.
        Return String.Format( _
        "Request user host address: {0}", _
        RequestInformation.UserHostAddress)
   End Function 'GetRequestUserHostAdddress
   
   ' </Snippet7>
   ' <Snippet8>
   ' Get the request principal.
   Public Function GetRequestPrincipal() As String
      ' Get the request principal.
        Return String.Format( _
        "Request principal name: {0}", _
        RequestInformation.Principal.Identity.Name)
   End Function 'GetRequestPrincipal
   
   ' </Snippet8>
   ' <Snippet9>
   ' Formats Web request event information.
    Public Overrides Sub FormatCustomEventDetails( _
    ByVal formatter As WebEventFormatter)

        ' Add custom data.
        formatter.AppendLine("")
        formatter.AppendLine("Custom Request Information:")

        formatter.IndentationLevel += 1

        ' Display the request information obtained 
        ' using the WebRequestInformation object.
        formatter.AppendLine(GetRequestPath())
        formatter.AppendLine(GetRequestUrl())
        formatter.AppendLine(GetRequestUserHostAdddress())
        formatter.AppendLine(GetRequestPrincipal())
        formatter.IndentationLevel -= 1

        formatter.AppendLine(eventInfo.ToString())
    End Sub 'FormatCustomEventDetails 
    ' </Snippet9>

End Class 'SampleWebRequestInformation


' </Snippet1>