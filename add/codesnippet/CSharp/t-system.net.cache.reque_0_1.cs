        public static WebResponse GetResponseFromCache(Uri uri)
        {
             RequestCachePolicy policy = 
                new  RequestCachePolicy( RequestCacheLevel.CacheOnly);
            WebRequest request = WebRequest.Create(uri);
            request.CachePolicy = policy;
            WebResponse response = request.GetResponse();
            Console.WriteLine("Policy level is {0}.", policy.Level.ToString());
            Console.WriteLine("Is the response from the cache? {0}", response.IsFromCache);  
            return response;
            
        } 