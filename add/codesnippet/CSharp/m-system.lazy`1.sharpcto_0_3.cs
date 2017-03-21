    static int instanceCount = 0;
    public LargeObject()
    {
        if (1 == Interlocked.Increment(ref instanceCount))
        {
            throw new ApplicationException("Throw only ONCE.");
        }

        initBy = Thread.CurrentThread.ManagedThreadId;
        Console.WriteLine("LargeObject was created on thread id {0}.", initBy);
    }