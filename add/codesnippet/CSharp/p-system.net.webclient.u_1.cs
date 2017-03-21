    // Sample call: UploadFileInBackground3("http://www.contoso.com/fileUpload.aspx", "data.txt")
    public static void UploadFileInBackground3 (string address, string fileName)
    {
        WebClient client = new WebClient ();

        Uri uri = new Uri(address);

        client.UseDefaultCredentials = true;
        client.UploadFileCompleted += new UploadFileCompletedEventHandler (UploadFileCallback2);
        client.UploadFileAsync (uri, fileName);
        Console.WriteLine ("File upload started.");
    }
