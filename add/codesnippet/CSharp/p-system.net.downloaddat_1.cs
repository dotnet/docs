    private static void DownloadDataCallback (Object sender, DownloadDataCompletedEventArgs e)
    {
        System.Threading.AutoResetEvent waiter = (System.Threading.AutoResetEvent)e.UserState;

        try
        {
            // If the request was not canceled and did not throw
            // an exception, display the resource.
            if (!e.Cancelled && e.Error == null)
            {
                byte[] data = (byte[])e.Result;
                string textData = System.Text.Encoding.UTF8.GetString (data);

                Console.WriteLine (textData);
            }
        }
        finally
        {
            // Let the main application thread resume.
            waiter.Set ();
        }
    }
