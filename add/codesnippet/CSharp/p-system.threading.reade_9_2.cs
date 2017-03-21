           Debug.Assert(!rwLock.IsUpgradeableReadLockHeld,
               String.Format("Thread {0} has entered the upgradeable read lock while MyFunction is still executing.",
                             Thread.CurrentThread.ManagedThreadId));