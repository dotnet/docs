           Dim waitingWriteCt As Integer = rwLock.WaitingWriteCount
           If waitingWriteCt > WRITE_THRESHOLD Then
               performanceLog.WriteEntry(String.Format( _
                   "{0} blocked writer threads; exceeds recommended maximum.", _
                   waitingWriteCt))
           End If