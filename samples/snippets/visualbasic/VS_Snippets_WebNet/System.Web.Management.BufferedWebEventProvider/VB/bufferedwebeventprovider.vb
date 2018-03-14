 '*
'  *File name: WebEventProvider.cs
'  *Purpose: Shows how to build a custom event provider. 
'  *

' <Snippet1>
Imports System
Imports System.Text
Imports System.IO
Imports System.Web.Management
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Web



' Implements a custom event provider.

Public Class SampleBufferedWebEventProvider
   Inherits BufferedWebEventProvider
   
   ' The local path of the file where
   ' to store event information.
   Private logFilePath As String = String.Empty
   
   ' Holds custom information.
   Private customInfo As StringBuilder
   
   Private fs As FileStream
   
    Private providerName, buffer, bufferModality As String
   
   
   ' <Snippet8>
   Public Sub New()
      ' Perform local initializations.
      ' Path of local file where to store 
      ' event info.
      ' Assure that the path works for you and
      ' that the right permissions are set.
      logFilePath = "C:/test/log.doc"
      
      ' Instantiate buffer to contain 
      ' local data.
      customInfo = New StringBuilder()
   End Sub 'New
    
   
   ' </Snippet8>
   ' <Snippet9>
   Public Overrides Sub Flush()
      customInfo.AppendLine("Perform custom flush")
        StoreToFile(customInfo, _
        logFilePath, FileMode.Append)
   End Sub 'Flush
    ' </Snippet9>
   
   ' <Snippet2>
   ' Initializes the provider.
    Public Overrides Sub Initialize(ByVal name As String, _
    ByVal config As NameValueCollection)
        MyBase.Initialize(name, config)

        ' Get the configuration information.
        providerName = name
        buffer = SampleUseBuffering.ToString()
        bufferModality = SampleBufferMode

        customInfo.AppendLine(String.Format( _
        "Provider name: {0}", providerName))
        customInfo.AppendLine(String.Format( _
        "Buffering: {0}", buffer))
        customInfo.AppendLine(String.Format( _
        "Buffering modality: {0}", bufferModality))
    End Sub 'Initialize
   
   ' </Snippet2>
   ' <Snippet3>
   
   Public ReadOnly Property SampleUseBuffering() As Boolean
      Get
         Return UseBuffering
      End Get
    End Property
    ' </Snippet3>

    ' <Snippet4>
   
   Public ReadOnly Property SampleBufferMode() As String
      Get
         Return BufferMode
      End Get
    End Property
    ' </Snippet4>

    ' <Snippet5>
   ' Processes the incoming events.
    ' This method performs custom 
    ' processing and, if buffering is 
    ' enabled, it calls the base.ProcessEvent
    ' to buffer the event information.
    Public Overrides Sub ProcessEvent( _
    ByVal eventRaised As WebBaseEvent)

        If UseBuffering Then
            ' Buffering enabled, call the base event to
            ' buffer event information.
            MyBase.ProcessEvent(eventRaised)
        Else
            ' Buffering disabled, store the current event
            ' now.
            customInfo.AppendLine("*** Buffering disabled ***")
            customInfo.AppendLine(eventRaised.ToString())
            ' Store the information in the specified file.
            StoreToFile(customInfo, _
            logFilePath, FileMode.Append)
        End If
    End Sub 'ProcessEvent
   
   ' </Snippet5>

    '<Snippet11>
    Private Function GetEvents( _
    ByVal flushInfo As WebEventBufferFlushInfo) _
    As WebBaseEventCollection
        Return flushInfo.Events
    End Function 'GetEvents

    '</Snippet11>

    '<Snippet12>
    Private Function GetEventsDiscardedSinceLastNotification( _
    ByVal flushInfo _
    As WebEventBufferFlushInfo) As Integer
        Return flushInfo.EventsDiscardedSinceLastNotification
    End Function 'GetEventsDiscardedSinceLastNotification

    '</Snippet12>

    '<Snippet13>
    Private Function GetEventsInBuffer(ByVal flushInfo _
    As WebEventBufferFlushInfo) As Integer
        Return flushInfo.EventsInBuffer
    End Function 'GetEventsInBuffer

    '</Snippet13>

    '<Snippet14>
    Private Function GetLastNotificationTime(ByVal flushInfo _
    As WebEventBufferFlushInfo) As DateTime
        Return flushInfo.LastNotificationUtc
    End Function 'GetLastNotificationTime

    '</Snippet14>

    '<Snippet15>
    Private Function GetNotificationSequence(ByVal flushInfo _
    As WebEventBufferFlushInfo) As Integer
        Return flushInfo.NotificationSequence
    End Function 'GetNotificationSequence

    '</Snippet15>

    '<Snippet16>
    Private Function GetNotificationType(ByVal flushInfo _
    As WebEventBufferFlushInfo) _
    As EventNotificationType
        Return flushInfo.NotificationType
    End Function 'GetNotificationType

    '</Snippet16>

    ' <Snippet6>
    ' Processes the messages that have been buffered.
    ' It is called by the ASP.NET when the flushing of 
    ' the buffer is required according to the parameters 
    ' defined in the <bufferModes> element of the 
    ' <healthMonitoring> configuration section.
    Public Overrides Sub ProcessEventFlush(ByVal flushInfo _
    As WebEventBufferFlushInfo)

        ' Customize event information to be sent to 
        ' the Windows Event Viewer Application Log.
        customInfo.AppendLine( _
        "SampleEventLogWebEventProvider buffer flush.")

        customInfo.AppendLine(String.Format( _
        "NotificationType: {0}", _
        GetNotificationType(flushInfo)))

        customInfo.AppendLine(String.Format( _
        "EventsInBuffer: {0}", _
        GetEventsInBuffer(flushInfo)))

        customInfo.AppendLine(String.Format( _
        "EventsDiscardedSinceLastNotification: {0}", _
GetEventsDiscardedSinceLastNotification( _
flushInfo)))

        ' Read each buffered event and send it to the
        ' Application Log.
        Dim eventRaised As WebBaseEvent
        For Each eventRaised In flushInfo.Events
            customInfo.AppendLine(eventRaised.ToString())
        Next eventRaised
        ' Store the information in the specified file.
        StoreToFile(customInfo, logFilePath, _
        FileMode.Append)
    End Sub 'ProcessEventFlush

    ' </Snippet6>
    ' <Snippet7>
    ' Performs standard shutdown.
    Public Overrides Sub Shutdown()
        ' Here you need the code that performs
        ' those tasks required before shutting 
        ' down the provider.
        ' Flush the buffer, if needed.
        Flush()

    End Sub 'Shutdown

    ' </Snippet7>
    ' <Snippet10>
    ' Store event information in a local file.
    Private Sub StoreToFile(ByVal [text] _
    As StringBuilder, ByVal filePath As String, _
    ByVal mode As FileMode)
        Dim writeBlock As Integer
        Dim startIndex As Integer

        Try

            writeBlock = 256
            startIndex = 0

            ' Open or create the local file 
            ' to store the event information.
            fs = New FileStream(filePath, mode, FileAccess.Write)

            ' Lock the file for writing.
            fs.Lock(startIndex, writeBlock)

            ' Create a stream writer
            Dim writer As New StreamWriter(fs)

            ' Set the file pointer to the current 
            ' position to keep adding data to it. 
            ' If you want to rewrite the file use 
            ' the following statement instead.
            ' writer.BaseStream.Seek (0, SeekOrigin.Begin);
            writer.BaseStream.Seek(0, SeekOrigin.Current)

            'If the file already exists it must not 
            ' be write protected otherwise  
            ' the following write operation 
            'fails silently.
            writer.Write([text].ToString())

            ' Update the underlying file
            writer.Flush()

            ' Unlock the file for other processes.
            fs.Unlock(startIndex, writeBlock)

            ' Close the stream writer and 
            'the underlying file     
            writer.Close()

            fs.Close()
        Catch e As Exception
            'Use this for debugging.
            'Never dispaly it!
            Dim ex As String = e.ToString()
            Throw New Exception( _
            "[SampleEventProvider] StoreToFile: exception.")
        End Try
    End Sub 'StoreToFile
    ' </Snippet10>
End Class 'SampleBufferedWebEventProvider



' </Snippet1>