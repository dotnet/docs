        lazyLargeObject = new Lazy<LargeObject>(() => 
        {
            LargeObject large = new LargeObject(Thread.CurrentThread.ManagedThreadId);
            // Perform additional initialization here.
            return large;
        });