    public LargeObject(int initializedBy) 
    { 
        initBy = initializedBy;
        Console.WriteLine("Constructor: Instance initializing on thread {0}", initBy);
    }

    ~LargeObject()
    {
        Console.WriteLine("Finalizer: Instance was initialized on {0}", initBy);
    }