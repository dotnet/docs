    public static void CheckTestUrl(HttpListener listener, HttpListenerRequest request)
    {
        if (request.RawUrl == "/www.contoso.com/test/NoReply")
        {
            listener.Abort ();
            return;
        }

    }