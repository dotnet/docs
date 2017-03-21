           Debug.Assert(Not rwLock.IsWriteLockHeld, _
               String.Format("Thread {0} is still holding the write lock after MyFunction has finished.", _
                             Thread.CurrentThread.ManagedThreadId))