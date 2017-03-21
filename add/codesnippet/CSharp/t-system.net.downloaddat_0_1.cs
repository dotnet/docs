    // Sample call : DownLoadDataInBackground ("http://www.contoso.com/GameScores.html");
    public static void DownloadDataInBackground (string address)
    {
        System.Threading.AutoResetEvent waiter = new System.Threading.AutoResetEvent (false);
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);

        // Specify that the DownloadDataCallback method gets called
        // when the download completes.
        client.DownloadDataCompleted += new DownloadDataCompletedEventHandler (DownloadDataCallback);
        client.DownloadDataAsync (uri, waiter);

        // Block the main application thread. Real applications
        // can perform other tasks while waiting for the download to complete.
        waiter.WaitOne ();
    }
