           Debug.Assert(Not rwLock.IsReadLockHeld, _
               String.Format("Thread {0} already held the read lock when MyFunction began executing.", _
                             Thread.CurrentThread.ManagedThreadId))