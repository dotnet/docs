           Dim waitingReadCt As Integer = rwLock.WaitingReadCount
           If waitingReadCt > READ_THRESHOLD Then
               performanceLog.WriteEntry(String.Format( _
                   "{0} blocked reader threads; exceeds recommended maximum.", _
                   waitingReadCt))
           End If