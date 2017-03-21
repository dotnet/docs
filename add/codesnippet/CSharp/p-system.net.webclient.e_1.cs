    public static void UploadString (string address)
    {
        string data = "Time = 12:00am temperature = 50";
        WebClient client = new WebClient ();
        // Optionally specify an encoding for uploading and downloading strings.
        client.Encoding = System.Text.Encoding.UTF8;
        // Upload the data.
        string reply = client.UploadString (address, data);
        // Disply the server's response.
        Console.WriteLine (reply);
    }
