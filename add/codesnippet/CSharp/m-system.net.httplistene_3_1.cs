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