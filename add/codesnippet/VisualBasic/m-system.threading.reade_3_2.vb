    Public Function AddOrUpdate(ByVal key As Integer, _
                                ByVal value As String) As AddOrUpdateStatus
        cacheLock.EnterUpgradeableReadLock()
        Try
            Dim result As String = Nothing
            If innerCache.TryGetValue(key, result) Then
                If result = value Then
                    Return AddOrUpdateStatus.Unchanged
                Else
                    cacheLock.EnterWriteLock()
                    Try
                        innerCache.Item(key) = value
                    Finally
                        cacheLock.ExitWriteLock()
                    End Try
                    Return AddOrUpdateStatus.Updated
                End If
            Else
                cacheLock.EnterWriteLock()
                Try
                    innerCache.Add(key, value)
                Finally
                    cacheLock.ExitWriteLock()
                End Try
                Return AddOrUpdateStatus.Added
            End If
        Finally
            cacheLock.ExitUpgradeableReadLock()
        End Try
    End Function