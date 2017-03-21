    Public Function AddWithTimeout(ByVal key As Integer, ByVal value As String, _
                                   ByVal timeout As Integer) As Boolean
        If cacheLock.TryEnterWriteLock(timeout) Then
            Try
                innerCache.Add(key, value)
            Finally
                cacheLock.ExitWriteLock()
            End Try
            Return True
        Else
            Return False
        End If
    End Function