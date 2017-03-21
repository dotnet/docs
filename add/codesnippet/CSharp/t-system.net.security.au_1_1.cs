
        // The following example uses the System, System.Net, 
        // and System.IO namespaces.
        
        public static void RequestMutualAuth(Uri resource)
        {
            // Create a new HttpWebRequest object for the specified resource.
            WebRequest request=(WebRequest) WebRequest.Create(resource);
            // Request mutual authentication.
           request.AuthenticationLevel = AuthenticationLevel.MutualAuthRequested;
            // Supply client credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            // Determine whether mutual authentication was used.
            Console.WriteLine("Is mutually authenticated? {0}", response.IsMutuallyAuthenticated);
            // Read and display the response.
            Stream streamResponse = response.GetResponseStream();
            StreamReader streamRead = new StreamReader(streamResponse);
            string responseString = streamRead.ReadToEnd();
           Console.WriteLine(responseString);
            // Close the stream objects.
            streamResponse.Close();
            streamRead.Close();
            // Release the HttpWebResponse.
            response.Close();
        }