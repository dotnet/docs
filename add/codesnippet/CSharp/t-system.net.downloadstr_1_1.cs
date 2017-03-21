    // Sample call : DownloadStringInBackground2 ("http://www.contoso.com/GameScores.html");
    public static void DownloadStringInBackground2 (string address)
    {
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);

        // Specify that the DownloadStringCallback2 method gets called
        // when the download completes.
        client.DownloadStringCompleted += new DownloadStringCompletedEventHandler (DownloadStringCallback2);
        client.DownloadStringAsync (uri);
    }
