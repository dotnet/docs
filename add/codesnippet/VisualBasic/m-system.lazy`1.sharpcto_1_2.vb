        Dim large As LargeObject = Nothing
        Try
            large = lazyLargeObject.Value

            ' The following line introduces an artificial delay, to exaggerate the race 
            ' condition.
            Thread.Sleep(5)

            ' IMPORTANT: Lazy initialization is thread-safe, but it doesn't protect the  
            '            object after creation. You must lock the object before accessing it,
            '            unless the type is thread safe. (LargeObject is not thread safe.)
            SyncLock large
                large.Data(0) = Thread.CurrentThread.ManagedThreadId
                Console.WriteLine( _
                    "LargeObject was initialized by thread {0}; last used by thread {1}.", _
                    large.InitializedBy, large.Data(0))
            End SyncLock
        Catch ex As ApplicationException
            Console.WriteLine("ApplicationException: {0}", ex.Message)
        End Try