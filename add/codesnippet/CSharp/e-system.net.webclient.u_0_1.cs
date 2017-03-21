    // Sample call: UploadFileInBackground2("http://www.contoso.com/fileUpload.aspx", "data.txt")
    public static void UploadFileInBackground2 (string address, string fileName)
    {
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);

        client.UploadFileCompleted += new UploadFileCompletedEventHandler (UploadFileCallback2);

	 // Specify a progress notification handler.
	 client.UploadProgressChanged += new UploadProgressChangedEventHandler(UploadProgressCallback);
        client.UploadFileAsync (uri, "POST", fileName);
        Console.WriteLine ("File upload started.");
    }
