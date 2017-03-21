        Dim large As LargeObject = lazyLargeObject.Value

        ' IMPORTANT: Lazy initialization is thread-safe, but it doesn't protect the  
        '            object after creation. You must lock the object before accessing it,
        '            unless the type is thread safe. (LargeObject is not thread safe.)
        SyncLock large
            large.Data(0) = Thread.CurrentThread.ManagedThreadId
            Console.WriteLine("Initialized by thread {0}; last used by thread {1}.", _
                large.InitializedBy, large.Data(0))
        End SyncLock