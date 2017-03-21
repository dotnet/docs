           Debug.Assert(Not rwLock.IsUpgradeableReadLockHeld, _
               String.Format("Thread {0} has entered the upgradeable read lock while MyFunction is still executing.", _
                             Thread.CurrentThread.ManagedThreadId))