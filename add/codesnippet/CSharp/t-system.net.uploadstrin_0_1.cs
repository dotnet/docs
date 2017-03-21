    public static void UploadStringInBackground2 (string address)
    {
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);
        string data = "Time = 12:00am temperature = 50";
        client.UploadStringCompleted += new UploadStringCompletedEventHandler (UploadStringCallback2);
        client.UploadStringAsync (uri, data);
    }
