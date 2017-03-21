    public static void OpenResourceForReading2 (string address)
    {
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);

        client.OpenReadCompleted += new OpenReadCompletedEventHandler(OpenReadCallback2);
        client.OpenReadAsync (uri);
    }
