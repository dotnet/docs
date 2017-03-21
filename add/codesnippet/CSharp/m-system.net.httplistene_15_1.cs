    // This example requires the System and System.Net namespaces.
    public static void SimpleCookieExample(string[] prefixes)
    {
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
        
        // This application sends a cookie to the client marking the time 
        // they visited. 
        Cookie timeStampCookie = new Cookie("VisitDate", DateTime.Now.ToString());
        // Obtain a response object.
        HttpListenerResponse response = context.Response;
        // Add the cookie to the response.
        response.SetCookie(timeStampCookie);
        // Construct a response.
        string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
        response.ContentEncoding = System.Text.Encoding.UTF8;
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
        // Send the response.
        response.Close(buffer, true);
        listener.Stop();
    }