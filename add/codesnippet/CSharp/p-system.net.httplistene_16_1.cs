    // This example requires the System and System.Net namespaces.
    public static string ClientInformation(HttpListenerContext context)
    {
        System.Security.Principal.IPrincipal user = context.User;
        System.Security.Principal.IIdentity id = user.Identity;
        if (id == null)
        {
            return "Client authentication is not enabled for this Web server.";
        }
        
        string display;
        if (id.IsAuthenticated)
        {
            display = String.Format("{0} was authenticated using {1}", id.Name, 
                id.AuthenticationType);
        }
        else
        {
           display = String.Format("{0} was not authenticated", id.Name);
        }
        return display;
    }

    public static void SimpleListenerWithAuthentication(string[] prefixes)
    {
        if (!HttpListener.IsSupported)
        {
            Console.WriteLine ("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
            return;
        }

        // URI prefixes are required,
        // for example "http://contoso.com:8080/index/".
        if (prefixes == null || prefixes.Length == 0)
          throw new ArgumentException("prefixes");

        // Set up a listener.
        HttpListener listener = new HttpListener();
        foreach (string s in prefixes)
        {
            listener.Prefixes.Add(s);
        }
        listener.Start();
        // Specify Negotiate as the authentication scheme.
        listener.AuthenticationSchemes = AuthenticationSchemes.Negotiate;
        Console.WriteLine("Listening...");
        // GetContext blocks while waiting for a request. 
        HttpListenerContext context = listener.GetContext();
        HttpListenerRequest request = context.Request;
        // Obtain a response object.
        HttpListenerResponse response = context.Response;
        // Construct a response.
        string clientInformation = ClientInformation(context);
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes("<HTML><BODY> " + clientInformation + "</BODY></HTML>");
        // Get a response stream and write the response to it.
        response.ContentLength64 = buffer.Length;
        System.IO.Stream output = response.OutputStream;
        output.Write(buffer,0,buffer.Length);
        output.Close();
        listener.Stop();
    }