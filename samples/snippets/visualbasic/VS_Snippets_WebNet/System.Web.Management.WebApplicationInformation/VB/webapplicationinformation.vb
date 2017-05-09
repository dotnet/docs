'*
'  *File name: WebProcessInformation.cs
'  *Purpose: Implements a custom type to access 
'  *the application information. 
'  *
' <Snippet1>
Imports System
Imports System.Text
Imports System.Web
Imports System.Web.Management


'Implements a custom WebBaseEvent that uses
' WebApplicationInformation. 
Public Class SampleWebApplicationInformation
    Inherits WebBaseEvent
    Private eventInfo As StringBuilder


    ' <Snippet2>
    ' Instantiate SampleWebGet    
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
    Public Function GetApplicationDomain() As String
        ' Get the name of the application domain.
        Return String.Format( _
        "Application domain: {0}", _
        ApplicationInformation.ApplicationDomain)
    End Function 'GetApplicationDomain

    ' </Snippet4>
    ' <Snippet5>
    Public Function GetApplicationPath() As String
        ' Get the name of the application  path.
        Return String.Format( _
        "Application path: {0}", _
        ApplicationInformation.ApplicationPath())
    End Function 'GetApplicationPath

    ' </Snippet5>
    ' <Snippet6>
    Public Function GetApplicationVirtualPath() As String
        ' Get the name of the application virtual path.
        Return String.Format( _
        "Application virtual path: {0}", _
        ApplicationInformation.ApplicationVirtualPath())
    End Function 'GetApplicationVirtualPath

    ' </Snippet6>
    ' <Snippet7>
    Public Function GetApplicationMachineName() As String
        ' Get the name of the application machine name.
        Return String.Format( _
        "Application machine name: {0}", _
        ApplicationInformation.MachineName())
    End Function 'GetApplicationMachineName

    ' </Snippet7>
    ' <Snippet8>
    Public Function GetApplicationTrustLevel() As String
        ' Get the name of the application trust level.
        Return String.Format( _
        "Application trust level: {0}", _
        ApplicationInformation.TrustLevel())
    End Function 'GetApplicationTrustLevel

    ' </Snippet8>
    ' <Snippet9>
    'Formats Web request event information.
    Public Overrides Sub FormatCustomEventDetails( _
 _
     ByVal formatter As WebEventFormatter)
        MyBase.FormatCustomEventDetails(formatter)

        ' Add custom data.
        formatter.AppendLine( _
        "Custom Application Information:")
        formatter.IndentationLevel += 1

        ' Display the application information.
        formatter.AppendLine(GetApplicationDomain())
        formatter.AppendLine(GetApplicationPath())
        formatter.AppendLine(GetApplicationVirtualPath())
        formatter.AppendLine(GetApplicationMachineName())
        formatter.AppendLine(GetApplicationTrustLevel())
        formatter.IndentationLevel -= 1
        formatter.AppendLine(eventInfo.ToString())
    End Sub 'FormatCustomEventDetails
End Class 'SampleWebApplicationInformation 

' </Snippet9>

' </Snippet1>