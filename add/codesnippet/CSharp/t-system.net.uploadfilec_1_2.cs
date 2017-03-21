    private static void UploadFileCallback2 (Object sender, UploadFileCompletedEventArgs e)
    {
        string reply = System.Text.Encoding.UTF8.GetString (e.Result);
        Console.WriteLine (reply);
    }
