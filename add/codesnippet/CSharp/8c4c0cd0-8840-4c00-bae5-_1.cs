        public static HttpRequestCachePolicy CreateFreshAndAgePolicy2(TimeSpan freshMinimum, TimeSpan ageMaximum, DateTime when)
        {
            HttpRequestCachePolicy policy = 
                new HttpRequestCachePolicy(HttpCacheAgeControl.MaxAgeAndMinFresh, ageMaximum, freshMinimum, when); 
            Console.WriteLine(policy.ToString());
            return policy;
            // For the following invocation: 
            // CreateFreshAndAgePolicy(new TimeSpan(5,0,0), new TimeSpan(10,0,0),);
            // the output is:
            // Level:Automatic 
            // AgeControl:MinFreshAndMaxAge 
            // MinFresh:18000 
            // MaxAge:36000
        }