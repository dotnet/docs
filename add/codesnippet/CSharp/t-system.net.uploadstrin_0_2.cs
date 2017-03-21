    private static void UploadStringCallback2 (Object sender, UploadStringCompletedEventArgs e)
    {
            string reply = (string)e.Result;
            Console.WriteLine (reply);
    }