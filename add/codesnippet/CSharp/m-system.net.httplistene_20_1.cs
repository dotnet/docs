        // Set up a listener.
        HttpListener listener = new HttpListener();
        foreach (string s in prefixes)
        {
            listener.Prefixes.Add(s);
        }
        listener.Start();