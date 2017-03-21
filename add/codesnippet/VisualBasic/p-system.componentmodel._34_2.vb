    ' This method cancels a pending asynchronous operation.
    Public Sub CancelAsync(ByVal taskId As Object)

        Dim obj As Object = userStateToLifetime(taskId)
        If (obj IsNot Nothing) Then

            SyncLock userStateToLifetime.SyncRoot

                userStateToLifetime.Remove(taskId)

            End SyncLock

        End If

    End Sub