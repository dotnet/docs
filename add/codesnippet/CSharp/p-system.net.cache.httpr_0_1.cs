        public static HttpRequestCachePolicy CreateMinFreshPolicy(TimeSpan span)
        {
            HttpRequestCachePolicy policy = 
                new HttpRequestCachePolicy(HttpCacheAgeControl.MinFresh, span); 
            Console.WriteLine("Minimum freshness {0}", policy.MinFresh.ToString());
            return policy;
        } 
        