        public static HttpRequestCachePolicy CreateMaxAgePolicy(TimeSpan span)
        {
            HttpRequestCachePolicy policy = 
                new HttpRequestCachePolicy(HttpCacheAgeControl.MaxAge, span); 
            Console.WriteLine("Max age is {0}", policy.MaxAge);
            return policy;
        } 