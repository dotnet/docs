    public LargeObject() 
    { 
        initBy = Thread.CurrentThread.ManagedThreadId;
        Console.WriteLine("Constructor: Instance initializing on thread {0}", initBy);
    }

    ~LargeObject()
    {
        Console.WriteLine("Finalizer: Instance was initialized on {0}", initBy);
    }