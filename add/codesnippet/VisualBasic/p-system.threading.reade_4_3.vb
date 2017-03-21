           Dim readCt As Integer = rwLock.CurrentReadCount
           If readCt > READ_THRESHOLD Then
               performanceLog.WriteEntry(String.Format( _
                   "{0} reader threads; exceeds recommended maximum.", readCt))
           End If