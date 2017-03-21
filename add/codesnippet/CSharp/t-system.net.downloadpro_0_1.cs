    // Sample call : DownLoadFileInBackground2 ("http://www.contoso.com/logs/January.txt");
    public static void DownLoadFileInBackground2 (string address)
    {
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);

        // Specify that the DownloadFileCallback method gets called
        // when the download completes.
        client.DownloadFileCompleted += new AsyncCompletedEventHandler (DownloadFileCallback2);
        // Specify a progress notification handler.
        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback);
        client.DownloadFileAsync (uri, "serverdata.txt");
    }
