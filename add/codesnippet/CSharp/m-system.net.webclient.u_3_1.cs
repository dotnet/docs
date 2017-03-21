    public static void PostString (string address)
    {
        string data = "Time = 12:00am temperature = 50";
        string method = "POST";
        WebClient client = new WebClient ();
        string reply = client.UploadString (address, method, data);

        Console.WriteLine (reply);
    }
