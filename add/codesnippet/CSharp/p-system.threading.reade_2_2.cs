           int waitingReadCt = rwLock.WaitingReadCount;
           if (waitingReadCt > READ_THRESHOLD)
           {
               performanceLog.WriteEntry(String.Format(
                   "{0} blocked reader threads; exceeds recommended maximum.", 
                   waitingReadCt));
           }