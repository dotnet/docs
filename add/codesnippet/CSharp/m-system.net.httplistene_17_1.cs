    // This example requires the System and System.Net namespaces.
    public static void SimpleListenerExample2(string[] prefixes)
    {
        // URI prefixes are required,
        // for example "http://contoso.com:8080/index/".
        if (prefixes == null || prefixes.Length == 0)
          throw new ArgumentException("prefixes");
        
        // Create a listener.
        HttpListener listener = new HttpListener();
        // Add the prefixes.
        foreach (string s in prefixes)
        {
            listener.Prefixes.Add(s);
        }
        listener.Start();
        Console.WriteLine("Listening...");
        // Note: The GetContext method blocks while waiting for a request. 
        HttpListenerContext context = listener.GetContext();
        HttpListenerRequest request = context.Request;
        // Obtain a response object.
        HttpListenerResponse response = context.Response;
        // Construct a response.
        string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
        // Get a response stream and write the response to it.
        response.ContentLength64 = buffer.Length;
        // Demonstrate using the close overload that takes an 
        // entity body.
        // Specify true to block while data is transmitted.
        response.Close(buffer, true);
        listener.Stop();
    }