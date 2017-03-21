Public Class SynchronizedCache
    Private cacheLock As New ReaderWriterLockSlim()
    Private innerCache As New Dictionary(Of Integer, String)

    Public ReadOnly Property Count As Integer
       Get
          Return innerCache.Count
       End Get
    End Property
    
    Public Function Read(ByVal key As Integer) As String
        cacheLock.EnterReadLock()
        Try
            Return innerCache(key)
        Finally
            cacheLock.ExitReadLock()
        End Try
    End Function

    Public Sub Add(ByVal key As Integer, ByVal value As String)
        cacheLock.EnterWriteLock()
        Try
            innerCache.Add(key, value)
        Finally
            cacheLock.ExitWriteLock()
        End Try
    End Sub

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

    Public Sub Delete(ByVal key As Integer)
        cacheLock.EnterWriteLock()
        Try
            innerCache.Remove(key)
        Finally
            cacheLock.ExitWriteLock()
        End Try
    End Sub

    Public Enum AddOrUpdateStatus
        Added
        Updated
        Unchanged
    End Enum

    Protected Overrides Sub Finalize()
       If cacheLock IsNot Nothing Then cacheLock.Dispose()
    End Sub
End Class