           int readCt = rwLock.CurrentReadCount;
           if (readCt > READ_THRESHOLD)
           {
               performanceLog.WriteEntry(String.Format(
                   "{0} reader threads; exceeds recommended maximum.", readCt));
           }