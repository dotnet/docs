    // Sample call: UploadFileInBackground("http://www.contoso.com/fileUpload.aspx", "data.txt")
    public static void UploadFileInBackground (string address, string fileName)
    {
        System.Threading.AutoResetEvent waiter = new System.Threading.AutoResetEvent (false);
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);
        string method = "POST";

        // Specify that that UploadFileCallback method gets called
        // when the file upload completes.
        client.UploadFileCompleted += new UploadFileCompletedEventHandler (UploadFileCallback);
        client.UploadFileAsync (uri, method, fileName, waiter);

        // Block the main application thread. Real applications
        // can perform other tasks while waiting for the upload to complete.
        waiter.WaitOne ();
        Console.WriteLine ("File upload is complete.");
    }
