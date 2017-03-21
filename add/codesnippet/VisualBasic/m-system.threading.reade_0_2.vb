    Public Function Read(ByVal key As Integer) As String
        cacheLock.EnterReadLock()
        Try
            Return innerCache(key)
        Finally
            cacheLock.ExitReadLock()
        End Try
    End Function