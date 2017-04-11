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

Public Class SampleEventProvider
    Inherits System.Web.Management.WebEventProvider
    
    ' The local path of the file where
    ' to store event information.
    Private logFilePath As String
    
    ' The current number of buffered messages 
    Private msgCounter As Integer
    
    ' The max number of messages to buffere.
    Private maxMsgNumber As Integer
    
    ' The message buffer.
    '  private System.Collections.Generic.Queue
    Private msgBuffer _
    As System.Collections.Generic.Queue( _
    Of System.Web.Management.WebBaseEvent) = _
    New System.Collections.Generic.Queue( _
    Of System.Web.Management.WebBaseEvent)


    ' <Snippet2>
    ' Initializes the provider.
    Public Sub New() 
        
        ' Initialize the local path of the file 
        ' that holds event information.
        logFilePath = "C:/test/log.doc"
        
        ' Clear the message buffer.
        msgBuffer.Clear()
        
        ' Initialize the max number of messages
        ' to buffer.
        maxMsgNumber = 10
    
    End Sub 'New
     
    ' More custom initialization goes here.
    ' </Snippet2>
    
    ' <Snippet3>
    ' Flush the input buffer if required.
    Public Overrides Sub Flush() 
        ' Create a string builder to 
        ' hold the event information.
        Dim reData As New StringBuilder()
        
        ' Store custom information.
        reData.Append( _
        "SampleEventProvider processing." + _
        Environment.NewLine)

        reData.Append( _
        "Flush done at: {0}" + _
        DateTime.Now.TimeOfDay.ToString() + _
        Environment.NewLine)
        
        Dim e As WebBaseEvent
        For Each e In  msgBuffer
            ' Store event data.
            reData.Append(e.ToString())
        Next e
        
        ' Store the information in the specified file.
        StoreToFile(reData, logFilePath, FileMode.Append)
        
        ' Reset the message counter.
        msgCounter = 0
        
        ' Clear the buffer.
        msgBuffer.Clear()
    
    End Sub 'Flush
     
    ' </Snippet3>
    ' <Snippet4>
    ' Shutdown the provider.
    Public Overrides Sub Shutdown() 
        Flush()
    
    End Sub 'Shutdown
    
    ' </Snippet4>
    ' <Snippet5>
    ' Process the event that has been raised.
    Public Overrides Sub ProcessEvent( _
    ByVal raisedEvent As WebBaseEvent)

        If msgCounter < maxMsgNumber Then
            ' Buffer the event information.
            msgBuffer.Enqueue(raisedEvent)
            ' Increment the message counter.
            msgCounter += 1
        Else
            ' Flush the buffer.
            Flush()
        End If

    End Sub 'ProcessEvent
    
    
    ' </Snippet5>
    ' <Snippet6>
    ' Store event information in a local file.
    Private Sub StoreToFile( _
    ByVal [text] As StringBuilder, _
    ByVal filePath As String, _
    ByVal mode As FileMode)
        Dim writeBlock As Integer
        Dim startIndex As Integer

        Try

            writeBlock = 256
            startIndex = 0

            ' Open or create the local file 
            ' to store the event information.
            Dim fs As New FileStream( _
            filePath, mode, FileAccess.Write)

            ' Lock the file for writing.
            fs.Lock(startIndex, writeBlock)

            ' Create a stream writer
            Dim writer As New StreamWriter(fs)

            ' Set the file pointer to the current 
            ' position to keep adding data to it. 
            ' If you want to rewrite the file use 
            ' the(following) statement instead.
            ' writer.BaseStream.Seek (0, SeekOrigin.Begin);
            writer.BaseStream.Seek(0, SeekOrigin.Current)

            'If the file already exists it must 
            'not be write protected, otherwise  
            'the following write operation fails silently.
            writer.Write([text].ToString())

            ' Update the underlying file
            writer.Flush()

            ' Unlock the file for other processes.
            fs.Unlock(startIndex, writeBlock)

            ' Close the stream writer and the underlying file     
            writer.Close()

            fs.Close()
        Catch e As Exception
            Throw New Exception( _
            "SampleEventProvider.StoreToFile: " + _
            e.ToString())
        End Try

    End Sub 'StoreToFile
End Class 'SampleEventProvider
' </Snippet6>


' </Snippet1>