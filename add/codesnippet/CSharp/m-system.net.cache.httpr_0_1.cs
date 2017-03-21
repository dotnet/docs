        public static HttpRequestCachePolicy CreateLastSyncPolicy(DateTime when)
        {
            HttpRequestCachePolicy policy = 
               new HttpRequestCachePolicy(when);
               
            Console.WriteLine("When: {0}", when);
            Console.WriteLine(policy.CacheSyncDate.ToString());
            return policy; 
        }