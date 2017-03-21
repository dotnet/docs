           Debug.Assert(!rwLock.IsWriteLockHeld, 
               String.Format("Thread {0} is still holding the write lock after MyFunction has finished.", 
                             Thread.CurrentThread.ManagedThreadId));