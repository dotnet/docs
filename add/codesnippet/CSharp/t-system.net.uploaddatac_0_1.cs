    public static void UploadDataInBackground2 (string address)
    {
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);
        string text = "Time = 12:00am temperature = 50";
        byte[] data = System.Text.Encoding.UTF8.GetBytes (text);
        string method = "POST";

        client.UploadDataCompleted += new UploadDataCompletedEventHandler (UploadDataCallback2);
        client.UploadDataAsync (uri, method, data);
    }
