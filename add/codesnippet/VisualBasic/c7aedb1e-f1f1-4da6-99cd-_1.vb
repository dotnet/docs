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
    
    