        public static HttpRequestCachePolicy CreateCacheIfAvailablePolicy()
        {
            HttpRequestCachePolicy policy = 
                new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
               
            Console.WriteLine(policy.ToString());
            return policy;
            
        } 