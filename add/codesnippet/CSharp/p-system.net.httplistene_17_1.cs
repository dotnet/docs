    public static void ShowRequestData (HttpListenerRequest request)
    {
        if (!request.HasEntityBody)
        {
            Console.WriteLine("No client data was sent with the request.");
            return;
        }
        System.IO.Stream body = request.InputStream;
        System.Text.Encoding encoding = request.ContentEncoding;
        System.IO.StreamReader reader = new System.IO.StreamReader(body, encoding);
        if (request.ContentType != null)
        {
            Console.WriteLine("Client data content type {0}", request.ContentType);
        }
        Console.WriteLine("Client data content length {0}", request.ContentLength64);
       
        Console.WriteLine("Start of client data:");
        // Convert the data to a string and display it on the console.
        string s = reader.ReadToEnd();
        Console.WriteLine(s);
        Console.WriteLine("End of client data:");
        body.Close();
        reader.Close();
        // If you are finished with the request, it should be closed also.
    }