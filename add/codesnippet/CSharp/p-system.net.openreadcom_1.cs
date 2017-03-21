    private static void OpenReadCallback2 (Object sender, OpenReadCompletedEventArgs e)
    {
        Stream reply = null;
        StreamReader s = null;

        try
        {
            reply = (Stream)e.Result;
            s = new StreamReader (reply);
            Console.WriteLine (s.ReadToEnd ());
        }
        finally
        {
            if (s != null)
            {
                s.Close ();
            }

            if (reply != null)
            {
                reply.Close ();
            }
        }
    }
