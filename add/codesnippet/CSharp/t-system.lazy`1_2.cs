    static LargeObject InitLargeObject()
    {
        LargeObject large = new LargeObject(Thread.CurrentThread.ManagedThreadId);
        // Perform additional initialization here.
        return large;
    }