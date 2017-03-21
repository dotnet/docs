        public static WebResponse GetResponseUsingCacheDefault(Uri uri)
        {
            // Set  the default cache policy level for the "http:" scheme.
            RequestCachePolicy policy = new RequestCachePolicy();
            // Create the request.
            WebRequest request = WebRequest.Create(uri);
            request.CachePolicy = policy;
            WebResponse response = request.GetResponse();
            Console.WriteLine("Policy level is {0}.", policy.Level.ToString());
            Console.WriteLine("Is the response from the cache? {0}", response.IsFromCache);  
            
            return response;
        }