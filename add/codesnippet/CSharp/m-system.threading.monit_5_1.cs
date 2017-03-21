        bool acquiredLock = false;

        try
        {
            Monitor.Enter(lockObject, ref acquiredLock);

            // Code that accesses resources that are protected by the lock.

        }
        finally
        {
            if (acquiredLock)
            {
                Monitor.Exit(lockObject);
            }
        }