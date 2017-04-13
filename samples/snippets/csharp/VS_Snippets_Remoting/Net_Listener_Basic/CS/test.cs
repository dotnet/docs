using System;
using System.Net;

public class ListenerBasic
{
    // <snippet1>
    public static void DisplayPrefixesAndState(HttpListener listener)
    {
        // List the prefixes to which the server listens.
        HttpListenerPrefixCollection prefixes = listener.Prefixes;
        if (prefixes.Count == 0)
        {
            Console.WriteLine("There are no prefixes.");
        }
        foreach(string prefix in prefixes)
        {
            Console.WriteLine(prefix);
        }
        // Show the listening state.
        if (listener.IsListening)
        {
            Console.WriteLine("The server is listening.");
        }
    }
    // </snippet1>

    // <snippet2>
    // This example requires the System and System.Net namespaces.
    public static void SimpleListenerExample(string[] prefixes)
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
        System.IO.Stream output = response.OutputStream;
        output.Write(buffer,0,buffer.Length);
        // You must close the output stream.
        output.Close();
        listener.Stop();
    }
    // </snippet2>

    // <snippet3>
    // This example requires the System and System.Net namespaces.
    // <snippet8>
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
    // </snippet8>

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

            // <snippet9>
        // Set up a listener.
        HttpListener listener = new HttpListener();
        foreach (string s in prefixes)
        {
            listener.Prefixes.Add(s);
        }
        listener.Start();
        // </snippet9>
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
    // </snippet3>
    // <snippet4>
    public static bool CheckForPrefix(HttpListener listener, string prefix)
    {
        // Get the prefixes that the Web server is listening to.
        HttpListenerPrefixCollection prefixes = listener.Prefixes;
        if (prefixes.Count == 0 || prefix == null)
        {
            return false;
        }
        return prefixes.Contains(prefix);
    }
    // </snippet4>


    // <snippet6>
    public static bool RemoveAllPrefixes(HttpListener listener)
    {
        // Get the prefixes that the Web server is listening to.
        HttpListenerPrefixCollection prefixes = listener.Prefixes;
        try 
        {
            prefixes.Clear();
        } 
        // If the operation failed, return false.
        catch
        {
            return false;
        }
        return true;
    }
    // </snippet6>
    // <snippet7>
    public static string[] CopyPrefixes (HttpListener listener)
    {
         HttpListenerPrefixCollection prefixes = listener.Prefixes;
         string[] prefixArray = new string[prefixes.Count];
         prefixes.CopyTo(prefixArray, 0);
         return prefixArray;
    }
    // </snippet7>
    // <snippet10>
    public static void ConfigureListener1(HttpListener listener)
    {
        // Specify an authentication realm.
        listener.Realm = "ExampleRealm";
    }
    // </snippet10>
    // <snippet11>
    public static void CheckTestUrl(HttpListener listener, HttpListenerRequest request)
    {
        if (request.RawUrl == "/www.contoso.com/test/NoReply")
        {
            listener.Abort ();
            return;
        }

    }
    // </snippet11>
    // <snippet12>

    public static void NonblockingListener(string [] prefixes)
    {
        HttpListener listener = new HttpListener();
        foreach (string s in prefixes)
        {
            listener.Prefixes.Add(s);
        }
        listener.Start();
        IAsyncResult result = listener.BeginGetContext(new AsyncCallback(ListenerCallback),listener);
        // Applications can do some work here while waiting for the 
        // request. If no work can be done until you have processed a request,
        // use a wait handle to prevent this thread from terminating
        // while the asynchronous operation completes.
        Console.WriteLine("Waiting for request to be processed asyncronously.");
        result.AsyncWaitHandle.WaitOne();
        Console.WriteLine("Request processed asyncronously.");
        listener.Close();
    }
    // </snippet12>
    // <snippet13>
    public static void ListenerCallback(IAsyncResult result)
    {
        HttpListener listener = (HttpListener) result.AsyncState;
        // Call EndGetContext to complete the asynchronous operation.
        HttpListenerContext context = listener.EndGetContext(result);
        HttpListenerRequest request = context.Request;
        // Obtain a response object.
        HttpListenerResponse response = context.Response;
        // Construct a response.
        string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
        // Get a response stream and write the response to it.
        response.ContentLength64 = buffer.Length;
        System.IO.Stream output = response.OutputStream;
        output.Write(buffer,0,buffer.Length);
        // You must close the output stream.
        output.Close();
    }
    // </snippet13>

// <snippet14>
    public static void SimpleListenerWithUnsafeAuthentication(string[] prefixes)
    {
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
        // If NTLM is used, we will allow multiple requests on the same
        // connection to use the authentication information of first request.
        // This improves performance but does reduce the security of your 
        // application. 
        listener.UnsafeConnectionNtlmAuthentication = true;
        // This listener does not want to receive exceptions 
        // that occur when sending the response to the client.
        listener.IgnoreWriteExceptions = true;
        Console.WriteLine("Listening...");
        // ... process requests here.

        listener.Close();
    }
// </snippet14>

    // <snippet15>
    public static void ShowRequestProperties1 (HttpListenerRequest request)
    {
        // Display the MIME types that can be used in the response.
        string[] types = request.AcceptTypes;
        if (types != null)
        {
            Console.WriteLine("Acceptable MIME types:");
            foreach (string s in types)
            {
                Console.WriteLine(s);
            }
        }
        // Display the language preferences for the response.
        types = request.UserLanguages;
        if (types != null)
        {
            Console.WriteLine("Acceptable natural languages:");
            foreach (string l in types)
            {
                Console.WriteLine(l);
            }
        }
        
        // Display the URL used by the client.
        Console.WriteLine("URL: {0}", request.Url.OriginalString);
        Console.WriteLine("Raw URL: {0}", request.RawUrl);
        Console.WriteLine("Query: {0}", request.QueryString);

        // Display the referring URI.
        Console.WriteLine("Referred by: {0}", request.UrlReferrer);

        //Display the HTTP method.
        Console.WriteLine("HTTP Method: {0}", request.HttpMethod);
        //Display the host information specified by the client;
        Console.WriteLine("Host name: {0}", request.UserHostName);
        Console.WriteLine("Host address: {0}", request.UserHostAddress);
        Console.WriteLine("User agent: {0}", request.UserAgent);
    }
    // </snippet15>
    
    // <snippet16>
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
        // </snippet16>
        
        // <snippet17>
        public static void ShowRequestProperties2 (HttpListenerRequest request)
        {
            Console.WriteLine("KeepAlive: {0}", request.KeepAlive);
            Console.WriteLine("Local end point: {0}", request.LocalEndPoint.ToString());
            Console.WriteLine("Remote end point: {0}", request.RemoteEndPoint.ToString());
            Console.WriteLine("Is local? {0}", request.IsLocal);
            Console.WriteLine("HTTP method: {0}", request.HttpMethod);
            Console.WriteLine("Protocol version: {0}", request.ProtocolVersion);
            Console.WriteLine("Is authenticated: {0}", request.IsAuthenticated);
            Console.WriteLine("Is secure: {0}", request.IsSecureConnection);

        }
        // </snippet17>
        // <snippet18>
        // This example requires the System and System.Net nam'espaces.
        public static void DisplayCookies(HttpListenerRequest request)
        {
            // Print the properties of each cookie.
            foreach (Cookie cook in request.Cookies)
            {
                Console.WriteLine("Cookie:");
                Console.WriteLine("{0} = {1}", cook.Name, cook.Value);
                Console.WriteLine("Domain: {0}", cook.Domain);
                Console.WriteLine("Path: {0}", cook.Path);
                Console.WriteLine("Port: {0}", cook.Port);
                Console.WriteLine("Secure: {0}", cook.Secure);
             
                Console.WriteLine("When issued: {0}", cook.TimeStamp);
                Console.WriteLine("Expires: {0} (expired? {1})", 
                    cook.Expires, cook.Expired);
                Console.WriteLine("Don't save: {0}", cook.Discard);    
                Console.WriteLine("Comment: {0}", cook.Comment);
                Console.WriteLine("Uri for comments: {0}", cook.CommentUri);
                Console.WriteLine("Version: RFC {0}" , cook.Version == 1 ? "2109" : "2965");

                // Show the string representation of the cookie.
                Console.WriteLine ("String: {0}", cook.ToString());
            }
        }
        // </snippet18>
        // <snippet19>
        // This example requires the System and System.Net namespaces.
        public static void DisplayCookies(HttpListenerResponse response)
        {
            // Print the properties of each cookie.
            foreach (Cookie cook in response.Cookies)
            {
                Console.WriteLine("Cookie:");
                Console.WriteLine("{0} = {1}", cook.Name, cook.Value);
                Console.WriteLine("Domain: {0}", cook.Domain);
                Console.WriteLine("Path: {0}", cook.Path);
                Console.WriteLine("Port: {0}", cook.Port);
                Console.WriteLine("Secure: {0}", cook.Secure);
             
                Console.WriteLine("When issued: {0}", cook.TimeStamp);
                Console.WriteLine("Expires: {0} (expired? {1})", 
                    cook.Expires, cook.Expired);
                Console.WriteLine("Don't save: {0}", cook.Discard);    
                Console.WriteLine("Comment: {0}", cook.Comment);
                Console.WriteLine("Uri for comments: {0}", cook.CommentUri);
                Console.WriteLine("Version: RFC {0}" , cook.Version == 1 ? "2109" : "2965");

                // Show the string representation of the cookie.
                Console.WriteLine ("String: {0}", cook.ToString());
            }
        }
        // </snippet19>

        // <snippet20>
        // This example requires the System and System.Net namespaces.

        public static string NextCustomerID()
        {
            // A real-world application would do something more robust
            // to ensure uniqueness.
            return DateTime.Now.ToString();
        }
        public static void SimpleListenerCookieExample(string[] prefixes)
        {
            // Create a listener.
            HttpListener listener = new HttpListener();
            // Add the prefixes.
            foreach (string s in prefixes)
            {
                listener.Prefixes.Add(s);
            }
            listener.IgnoreWriteExceptions = true;
            listener.Start();
            Console.WriteLine("Listening...");
            // Note: The GetContext method blocks while waiting for a request. 
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            string customerID = null;

            // Did the request come with a cookie?
            Cookie cookie = request.Cookies["ID"];
            if (cookie != null)
            {
                 customerID=cookie.Value;
            }
            if (customerID !=null)
            {
                  Console.WriteLine("Found the cookie!");
            }
            // Get the response object.
            HttpListenerResponse response = context.Response;
            // If they didn't provide a cookie containing their ID, give them one.
            if (customerID == null)
            {
                customerID = NextCustomerID();
                Cookie cook = new Cookie("ID", customerID );
                response.AppendCookie (cook);
            }
            // Construct a response.
            string responseString = "<HTML><BODY> Hello " + customerID + "!</BODY></HTML>";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            // Get the response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer,0,buffer.Length);
            // You must close the output stream.
            output.Close();
            // Closing the response sends the response to the client.
            response.Close();
            listener.Stop();
        }
        // </snippet20>


        // <snippet21>
        // Displays the header information that accompanied a request.
    public static void DisplayWebHeaderCollection(HttpListenerRequest request)
    {
        System.Collections.Specialized.NameValueCollection headers = request.Headers;
        // Get each header and display each value.
        foreach (string key in headers.AllKeys)
        {
            string[] values = headers.GetValues(key);
            if(values.Length > 0) 
            {
                Console.WriteLine("The values of the {0} header are: ", key);
                foreach (string value in values) 
                {
                    Console.WriteLine("   {0}", value);
                }
            }
            else
                Console.WriteLine("There is no value associated with the header.");
        }
    }
    // </snippet21>

    // <snippet22>
    public static void ShowSendFormat (HttpListenerResponse response)
    {
        
    
    }
    // </snippet22>

        // <snippet23>
        // Displays the header information that accompanied a request.
    public static void DisplayWebHeaderCollection(HttpListenerResponse response)
    {
        WebHeaderCollection headers = response.Headers;
        // Get each header and display each value.
        foreach (string key in headers.AllKeys)
        {
            string[] values = headers.GetValues(key);
            if(values.Length > 0) 
            {
                Console.WriteLine("The values of the {0} header are: ", key);
                foreach (string value in values) 
                {
                    Console.WriteLine("   {0}", value);
                }
            }
            else
                Console.WriteLine("There is no value associated with the header.");
        }
    }
    // </snippet23>
    // <snippet24>
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
    // </snippet24>

    //<snippet25>
    public static void TemporaryRedirect(HttpListenerRequest request, HttpListenerResponse response)
    {
        if (request.Url.OriginalString == @"http://www.contoso.com/index.html")
        {
            response.RedirectLocation = @"http://www.contoso.com/indexServer/index.html";
        }
    }
    //</snippet25>
    
    //<snippet26>
    public static void SetExpirationDate(long seconds, HttpListenerResponse response)
    {
        response.AddHeader("Expires", seconds.ToString());
    }
    //</snippet26>
    //<snippet27>
    public static void PermanentRedirect(HttpListenerRequest request, HttpListenerResponse response)
    {
        if (request.Url.OriginalString == @"http://www.contoso.com/index.html")
        {
            // Sets the location header, status code and status description.
            response.Redirect(@"http://www.contoso.com/indexServer/index.html");
        }
    }
    //</snippet27>

     // <snippet28>
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
    // </snippet28>
    public static void Main()
    {
        string[] prefixes = {@"http://localhost:8080/", @"http://sharriso3:8080/"};
        
        //  SimpleListenerWithAuthentication( prefixes);
        //  SimpleListenerExample(prefixes);
        //SimpleListenerWithUnsafeAuthentication( prefixes);
        //SimpleListenerCookieExample(prefixes);
        // SimpleListenerCookieExample(prefixes);
        SimpleCookieExample(prefixes);


      //  NonblockingListener( prefixes);
/*
        HttpListener listener = new HttpListener();
        foreach (string s in prefixes)
        {
            listener.Prefixes.Add(s);
        }

        try
        {
        listener.Start();
        } catch (System.ComponentModel.Win32Exception e)
        {
            Console.WriteLine("error code is {0}", e.NativeErrorCode);
            throw;
        }
        HttpListenerContext context = listener.GetContext();
        HttpListenerRequest request = context.HttpListenerRequest;
        //ShowRequestProperties1(request);
        ShowRequestProperties2(request);
        ShowRequestData(request);
        //DisplayWebHeaderCollection(request);



        
        /* test CheckTestUrl 

        CheckTestUrl(listener, request);
        */

        /* test CheckForPrefix */
       //Console.WriteLine(CheckForPrefix( listener, prefixes[0]));

       /* test CopyPrefixes 
       string[]prefixeStrings = CopyPrefixes( listener);
       foreach (string s in prefixeStrings)
       {
            Console.WriteLine(s);
       }
       */
       /* test RemovePrefix 

       Console.WriteLine("server has {0} prefixes", listener.Prefixes.Count);
       RemovePrefix(listener, prefixes[0]);
       Console.WriteLine("after remove 1 server has {0} prefixes", listener.Prefixes.Count);
       */

       /* test RemoveAllPrefixes 
       RemoveAllPrefixes( listener);
       Console.WriteLine("after remove all server has {0} prefixes", listener.Prefixes.Count);
    */
/*
    // send a test response
                    // Obtain a response object.
                    HttpListenerResponse response = context.HttpListenerResponse;
                    // Construct a response.
                    string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                    // Get a response stream and write the response to it.
                    response.ContentLength = buffer.Length;
                    System.IO.Stream output = response.OutputStream;
                    output.Write(buffer,0,buffer.Length);
                    // You must close the output stream.
                    output.Close();
                    // Closing the context sends the response to the client.
                    context.Close();
                    listener.Stop();
*/
       
    }
}



