    Class simpleMessageList
        Public messagesList() As String = New String(50) {}
        Public messagesLast As Integer = -1
        Private messagesLock As New Object
        Public Sub addAnotherMessage(ByVal newMessage As String)
            SyncLock messagesLock
                messagesLast += 1
                If messagesLast < messagesList.Length Then
                    messagesList(messagesLast) = newMessage
                End If
            End SyncLock
        End Sub
    End Class