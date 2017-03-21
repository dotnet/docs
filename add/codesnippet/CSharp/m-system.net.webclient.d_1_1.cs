    public static void DownloadString (string address)
    {
        WebClient client = new WebClient ();
        string reply = client.DownloadString (address);

        Console.WriteLine (reply);
    }
