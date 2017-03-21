        public static HttpRequestCachePolicy CreateMaxStalePolicy(TimeSpan span)
        {
            HttpRequestCachePolicy policy = 
                new HttpRequestCachePolicy(HttpCacheAgeControl.MaxStale, span);
               
           Console.WriteLine("Max stale is {0}", policy.MaxStale);
            return policy;
        } 