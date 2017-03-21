        LargeObject large = null;
        try
        {
            large = lazyLargeObject.Value;

            // The following line introduces an artificial delay, to exaggerate the race 
            // condition.
            Thread.Sleep(5); 

            // IMPORTANT: Lazy initialization is thread-safe, but it doesn't protect the  
            //            object after creation. You must lock the object before accessing it,
            //            unless the type is thread safe. (LargeObject is not thread safe.)
            lock(large)
            {
                large.Data[0] = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine("LargeObject was initialized by thread {0}; last used by thread {1}.", 
                    large.InitializedBy, large.Data[0]);
            }
        }
        catch (ApplicationException ex)
        {
            Console.WriteLine("ApplicationException: {0}", ex.Message);
        }