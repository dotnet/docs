    private static void UploadDataCallback2 (Object sender, UploadDataCompletedEventArgs e)
    {
        byte[] data = (byte[])e.Result;
        string reply = System.Text.Encoding.UTF8.GetString (data);

        Console.WriteLine (reply);
    }
