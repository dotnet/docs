    static bool pleaseThrow = true;
    public LargeObject()
    {
        if (pleaseThrow)
        {
            pleaseThrow = false;
            throw new ApplicationException("Throw only ONCE.");
        }

        Console.WriteLine("LargeObject was created on thread id {0}.", 
            Thread.CurrentThread.ManagedThreadId);
    }