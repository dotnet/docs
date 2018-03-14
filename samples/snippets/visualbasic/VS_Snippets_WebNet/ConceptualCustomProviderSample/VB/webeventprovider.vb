'*
'  *File name: BufferedWebEventProvider.cs
'  *Purpose: Shows how to build a buffered custom event provider. 
'  *

' <Snippet1>
Imports Microsoft.VisualBasic
Imports System
Imports System.Text
Imports System.IO
Imports System.Web.Management
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Web


Namespace Samples.AspNet.Management

    ' Implements a custom event provider.


    Public Class SampleBufferedEventProvider
        Inherits BufferedWebEventProvider

        ' The local path of the file where
        ' to store event information.
        Private logFilePath As String = String.Empty

        ' Holds custom information.
        Private customInfo As New StringBuilder()

        Private providerName, buffer, bufMode As String



        ' Initializes the provider.
        Public Overrides Sub Initialize(ByVal name As String, ByVal config As NameValueCollection)
            MyBase.Initialize(name, config)

            'Define the log local file location.
            logFilePath = "C:\test\log.doc"

            customInfo = New StringBuilder()

            providerName = name
            buffer = config.Get("buffer")
            bufMode = config.Get("bufferMode")

            customInfo.AppendLine( _
            String.Format("Provider name: {0}", providerName))
            customInfo.AppendLine( _
            String.Format("Buffering: {0}", buffer))
            customInfo.AppendLine( _
            String.Format("Buffering modality: {0}", BufferMode))
        End Sub 'Initialize




        ' Processes the incoming events.
        ' This method performs custom processing and, if
        ' buffering is enabled, it calls the base.ProcessEvent
        ' to buffer the event information.
        Public Overrides Sub ProcessEvent( _
        ByVal eventRaised As WebBaseEvent)

            If UseBuffering Then
                ' Buffering enabled, call the base event to
                ' buffer event information.
                MyBase.ProcessEvent(eventRaised)
            Else
                ' Buffering disabled, store event information
                ' immediately.
                customInfo.AppendLine(String.Format( _
                "{0}", eventRaised.Message))
                ' Store the information in the specified file.
                StoreToFile(customInfo, logFilePath, FileMode.Append)
            End If
        End Sub 'ProcessEvent


        ' Processes the messages that have been buffered.
        ' It is called by the ASP.NET when the flushing of 
        ' the buffer is required according to the parameters 
        ' defined in the <bufferModes> element of the 
        ' <healthMonitoring> configuration section.
        Public Overrides Sub ProcessEventFlush( _
        ByVal flushInfo As WebEventBufferFlushInfo)

            ' Customize event information to be logged. 
            customInfo.AppendLine( _
            "SampleEventLogWebEventProvider buffer flush.")

            customInfo.AppendLine(String.Format( _
            "NotificationType: {0}", flushInfo.NotificationType))

            customInfo.AppendLine(String.Format( _
            "EventsInBuffer: {0}", flushInfo.EventsInBuffer))

            customInfo.AppendLine(String.Format( _
            "EventsDiscardedSinceLastNotification: {0}", _
            flushInfo.EventsDiscardedSinceLastNotification))


            ' Read each buffered event and send it to the
            ' Log.
            Dim eventRaised As WebBaseEvent
            For Each eventRaised In flushInfo.Events
                customInfo.AppendLine(eventRaised.ToString())
            Next eventRaised
            ' Store the information in the specified file.
            StoreToFile(customInfo, logFilePath, FileMode.Append)

        End Sub 'ProcessEventFlush


        ' Performs standard shutdown.
        Public Overrides Sub Shutdown()
            ' Here you need the code that performs
            ' those tasks required before shutting 
            ' down the provider.
            ' Flush the buffer, if needed.
            Flush()
        End Sub 'Shutdown


        ' Store event information in a local file.
        Private Sub StoreToFile( _
        ByVal [text] As StringBuilder, _
        ByVal filePath As String, ByVal mode As FileMode)
            Dim writeBlock As Integer
            Dim startIndex As Integer

            Try

                writeBlock = 256
                startIndex = 0

                ' Open or create the local file 
                ' to store the event information.
                Dim fs As New FileStream(filePath, mode, FileAccess.Write)

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
                ' the following write operation fails silently.
                writer.Write([text].ToString())

                ' Update the underlying file
                writer.Flush()

                ' Unlock the file for other processes.
                fs.Unlock(startIndex, writeBlock)

                ' Close the stream writer and the underlying file     
                writer.Close()

                fs.Close()
            Catch e As Exception
                Throw New Exception("SampleEventProvider.StoreToFile: " + e.ToString())
            End Try
        End Sub 'StoreToFile
    End Class 'SampleBufferedEventProvider

End Namespace
' </Snippet1>