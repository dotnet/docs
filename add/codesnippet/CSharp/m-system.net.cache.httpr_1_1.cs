        public static WebResponse GetResponseUsingDefaultCache(Uri uri)
        {
            // Set a cache policy level for the "http:" scheme.
            HttpRequestCachePolicy policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.Default);
            // Create the request.
            WebRequest request = WebRequest.Create(uri);
            request.CachePolicy = policy;
            WebResponse response = request.GetResponse();
            Console.WriteLine("Policy {0}.", policy.ToString());
            Console.WriteLine("Is the response from the cache? {0}", response.IsFromCache);   
            return response;
        }