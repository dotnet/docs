        Dim asyncTask1 As New PageAsyncTask(AddressOf slowTask1.OnBegin, AddressOf slowTask1.OnEnd, AddressOf slowTask1.OnTimeout, "Async1", True)
        Dim asyncTask2 As New PageAsyncTask(AddressOf slowTask2.OnBegin, AddressOf slowTask2.OnEnd, AddressOf slowTask2.OnTimeout, "Async2", True)
        Dim asyncTask3 As New PageAsyncTask(AddressOf slowTask3.OnBegin, AddressOf slowTask3.OnEnd, AddressOf slowTask3.OnTimeout, "Async3", True)

        ' Register the asynchronous task.
        Page.RegisterAsyncTask(asyncTask1)
        Page.RegisterAsyncTask(asyncTask2)
        Page.RegisterAsyncTask(asyncTask3)