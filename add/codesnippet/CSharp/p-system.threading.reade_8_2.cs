           Debug.Assert(!rwLock.IsReadLockHeld,
               String.Format("Thread {0} already held the read lock when MyFunction began executing.",
                             Thread.CurrentThread.ManagedThreadId));