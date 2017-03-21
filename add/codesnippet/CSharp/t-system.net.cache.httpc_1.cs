        public static HttpRequestCachePolicy CreateFreshAndAgePolicy(TimeSpan freshMinimum, TimeSpan ageMaximum)
        {
            HttpRequestCachePolicy policy = 
                new HttpRequestCachePolicy(HttpCacheAgeControl.MaxAgeAndMinFresh, ageMaximum, freshMinimum); 
            Console.WriteLine(policy.ToString());
            return policy; 
        }