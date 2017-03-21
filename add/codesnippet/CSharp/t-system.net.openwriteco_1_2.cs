    private static void OpenWriteCallback2 (Object sender, OpenWriteCompletedEventArgs e)
    {
        Stream body = null;
        StreamWriter s = null;

        try
        {
            body = (Stream)e.Result;
            s = new StreamWriter (body);
            s.AutoFlush = true;
            s.Write ("This is content data to be sent to the server.");
        }
        finally
        {
            if (s != null)
            {
                s.Close ();
            }

            if (body != null)
            {
                body.Close ();
            }
        }
    }
