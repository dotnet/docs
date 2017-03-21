    public static void UploadDataInBackground3 (string address)
    {
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);
        string text = "Time = 12:00am temperature = 50";
        byte[] data = System.Text.Encoding.UTF8.GetBytes (text);

        client.UploadDataCompleted += new UploadDataCompletedEventHandler (UploadDataCallback3);
        client.UploadDataAsync (uri, data);
    }
