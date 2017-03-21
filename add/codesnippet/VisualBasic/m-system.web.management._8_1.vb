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
     