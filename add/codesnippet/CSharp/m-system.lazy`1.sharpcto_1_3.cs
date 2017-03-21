    static int instanceCount = 0;
    static LargeObject InitLargeObject()
    {
        if (1 == Interlocked.Increment(ref instanceCount))
        {
            throw new ApplicationException(
                String.Format("Lazy initialization function failed on thread {0}.",
                Thread.CurrentThread.ManagedThreadId));
        }
        return new LargeObject(Thread.CurrentThread.ManagedThreadId);
    }