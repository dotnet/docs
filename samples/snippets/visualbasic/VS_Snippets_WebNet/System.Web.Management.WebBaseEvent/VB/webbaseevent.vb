 '*
'  *File name: WebBaseEvent.cs
'  *Purpose: Implements a custom WebBaseEvent type
'  *

' <Snippet1>
Imports System
Imports System.Text
Imports System.Web
Imports System.Web.Management


Public Class SampleWebBaseEvent
    Inherits System.Web.Management.WebBaseEvent
    Implements System.Web.Management.IWebEventCustomEvaluator


    Private customCreatedMsg, customRaisedMsg As String

    ' Store firing record info.
    Private Shared firingRecordInfo As String

    ' <Snippet22>
    ' Implements the IWebEventCustomEvaluator.CanFire 
    ' method. It is called by the ASP.NET if this custom
    ' type is configured in the profile
    ' element of the healthMonitoring section.
    Public Function CanFire( _
    ByVal e As System.Web.Management.WebBaseEvent, _
    ByVal rule As RuleFiringRecord) As Boolean _
    Implements System.Web.Management.IWebEventCustomEvaluator.CanFire

        Dim fireEvent As Boolean
        Dim lastFired As String = _
            rule.LastFired.ToString()
        Dim timesRaised As String = _
            rule.TimesRaised.ToString()

        ' Fire every other event raised.
        fireEvent = _
        IIf(rule.TimesRaised Mod 2 = 0, True, False)

        If fireEvent Then
            firingRecordInfo = String.Format( _
            "Event last fired: {0}", lastFired) + _
            String.Format( _
            ". Times raised: {0}",  timesRaised) 
          
        Else
            firingRecordInfo = String.Format( _
            "Event not fired. Times raised: {0}", _
            timesRaised)
        End If

        Return fireEvent

    End Function 'CanFire

 ' </Snippet22>
 
    ' <Snippet2>
    ' Invoked in case of events identified only by 
    ' their event code.
    Public Sub New(ByVal msg As String, _
    ByVal eventSource As Object, _
    ByVal eventCode As Integer)
        MyBase.New(msg, eventSource, eventCode)
        ' Perform custom initialization.
        customCreatedMsg = String.Format( _
        "Event created at: {0}", DateTime.Now.TimeOfDay.ToString())

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
        customCreatedMsg = String.Format( _
        "Event created at: {0}", DateTime.Now.TimeOfDay.ToString())

    End Sub 'New


    ' </Snippet3>
    ' <Snippet4>
    ' Raises the SampleWebBaseEvent.
    Public Overrides Sub Raise()
        ' Perform custom processing. 
        customRaisedMsg = String.Format( _
        "Event raised at: {0}", DateTime.Now.TimeOfDay.ToString())

        ' Raise the event.
        MyBase.Raise()

    End Sub 'Raise

    ' </Snippet4>
    ' <Snippet5>
    ' Raises the SampleWebBaseEvent.
    Public Sub CustomRaise(ByVal evnt _
    As System.Web.Management.WebBaseEvent)

        ' Raise the event.
        Raise(evnt)

    End Sub 'CustomRaise


    ' </Snippet5>
    ' Gets the event code.
    Public Function GetEventCode(ByVal detail _
    As Boolean) As Integer
        Dim eCode As Integer

        If Not detail Then
            ' <Snippet6>
            ' Get the event code.
            eCode = EventCode
            ' </Snippet6>
            ' <Snippet7>
            ' Get the detail event code.
        Else
            eCode = EventDetailCode
        End If
        ' </Snippet7>
        Return eCode

    End Function 'GetEventCode


    ' <Snippet8>
    ' Gets the event sequence.
    Public Function GetEventSequence() As Long
        ' Get the event sequence.
        Dim eventSequence As Long = eventSequence
        Return eventSequence

    End Function 'GetEventSequence

    ' </Snippet8>


    ' <Snippet9>
    ' Gets the event source.
    Public Function GetEventSource() As [Object]
        ' Get the event source.
        Dim [source] As [Object] = Me.EventSource
        Return [source]

    End Function 'GetEventSource

    ' </Snippet9>
    ' <Snippet10>
    ' Gets the event time.
    Public Function GetEventTime() As DateTime
        ' Get the event source.
        Dim eTime As DateTime = EventTime
        Return eTime

    End Function 'GetEventTime

    ' </Snippet10>
    ' <Snippet11>
    ' Gets the event time.
    Public Function GetEventTimeUtc() As DateTime
        ' Get the event source.
        Dim eTime As DateTime = EventTimeUtc
        Return eTime

    End Function 'GetEventTimeUtc

    ' </Snippet11>
    ' <Snippet12>
    ' Gets the event sequence.
    Public Function GetEventMessage() As String
        ' Get the event message.
        Dim eventMsg As String = Message
        Return eventMsg

    End Function 'GetEventMessage

    ' </Snippet12>
    ' <Snippet13>
    ' Gets the current application information.
    Public Function GetEventAppInfo() As WebApplicationInformation
        ' Get the event message.
        Dim appImfo As WebApplicationInformation = _
        ApplicationInformation
        Return appImfo

    End Function 'GetEventAppInfo

    ' </Snippet13>
    ' <Snippet14>
    ' Implements the ToString() method.
    Public Overrides Function ToString() As String
        Return MyBase.ToString()

    End Function 'ToString

    ' </Snippet14>
    ' <Snippet15>
    ' Implements the ToString(bool, bool) method.
    Public Function customToString(ByVal includeAppInfo As Boolean, _
    ByVal includeCustomInfo As Boolean) As String
        Return MyBase.ToString(includeAppInfo, includeCustomInfo)

    End Function 'customToString

    ' </Snippet15>
    ' <Snippet16>
    ' Gets the event identifier.
    Public Function GetEventId() As Guid
        Dim evId As Guid = EventID
        Return evId

    End Function 'GetEventId

    ' </Snippet16>
    
    ' <Snippet17>
    'Formats Web request event information.
    Public Overrides Sub FormatCustomEventDetails( _
ByVal formatter As WebEventFormatter)
        MyBase.FormatCustomEventDetails(formatter)

        ' Add custom data.
        formatter.AppendLine("")

        ' <Snippet18>
        formatter.IndentationLevel += 1
        ' </Snippet18>
        
        ' <Snippet19>
        formatter.TabSize = 4
        ' </Snippet19>
        
        ' <Snippet20>
        formatter.AppendLine("*SampleWebBaseEvent Start *")
        formatter.AppendLine("Custom information goes here")
        formatter.AppendLine("* SampleWebBaseEvent End *")
        ' Display custom event timing.
        formatter.AppendLine(customCreatedMsg)
        formatter.AppendLine(customRaisedMsg)
        ' </Snippet20>
        formatter.IndentationLevel -= 1

    End Sub 'FormatCustomEventDetails
    ' </Snippet17>

End Class 'SampleWebBaseEvent

' </Snippet1>
