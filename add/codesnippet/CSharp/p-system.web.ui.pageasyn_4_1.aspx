    PageAsyncTask asyncTask1 = new PageAsyncTask(slowTask1.OnBegin, slowTask1.OnEnd, slowTask1.OnTimeout, "Async1", true);
    PageAsyncTask asyncTask2 = new PageAsyncTask(slowTask2.OnBegin, slowTask2.OnEnd, slowTask2.OnTimeout, "Async2", true);
    PageAsyncTask asyncTask3 = new PageAsyncTask(slowTask3.OnBegin, slowTask3.OnEnd, slowTask3.OnTimeout, "Async3", true);

    // Register the asynchronous task.
    Page.RegisterAsyncTask(asyncTask1);
    Page.RegisterAsyncTask(asyncTask2);
    Page.RegisterAsyncTask(asyncTask3);