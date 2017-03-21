
    public static void NonblockingListener(string [] prefixes)
    {
        HttpListener listener = new HttpListener();
        foreach (string s in prefixes)
        {
            listener.Prefixes.Add(s);
        }
        listener.Start();
        IAsyncResult result = listener.BeginGetContext(new AsyncCallback(ListenerCallback),listener);
        // Applications can do some work here while waiting for the 
        // request. If no work can be done until you have processed a request,
        // use a wait handle to prevent this thread from terminating
        // while the asynchronous operation completes.
        Console.WriteLine("Waiting for request to be processed asyncronously.");
        result.AsyncWaitHandle.WaitOne();
        Console.WriteLine("Request processed asyncronously.");
        listener.Close();
    }