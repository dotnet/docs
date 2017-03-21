    Public Sub Add(ByVal key As Integer, ByVal value As String)
        cacheLock.EnterWriteLock()
        Try
            innerCache.Add(key, value)
        Finally
            cacheLock.ExitWriteLock()
        End Try
    End Sub