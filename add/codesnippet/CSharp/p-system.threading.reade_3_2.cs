           int waitingWriteCt = rwLock.WaitingWriteCount;
           if (waitingWriteCt > WRITE_THRESHOLD)
           {
               performanceLog.WriteEntry(String.Format(
                   "{0} blocked writer threads; exceeds recommended maximum.", 
                   waitingWriteCt));
           }