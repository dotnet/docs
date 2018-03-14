using System;
using System.Net;
using System.Net.Cache;
using System.IO;
using System.Text;
using System.Collections.Specialized;
using System.Collections;

namespace Examples.System.Net.Cache
{
    public class CacheExample
    {
      //<snippet1>
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
           //</snippet1>
      
        //<snippet2>
        // The following method demonstrates overriding the
        // caching policy for a request.
        public static WebResponse GetResponseNoCache(Uri uri)
        {
            // Set a default policy level for the "http:" and "https" schemes.
            HttpRequestCachePolicy policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.Default);
            HttpWebRequest.DefaultCachePolicy = policy;
            // Create the request.
            WebRequest request = WebRequest.Create(uri);
            // Define a cache policy for this request only. 
            HttpRequestCachePolicy noCachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            request.CachePolicy = noCachePolicy;
            WebResponse response = request.GetResponse();
            Console.WriteLine("IsFromCache? {0}", response.IsFromCache);            
            return response;
        }
        //</snippet2>
        
        //<snippet3>
        public static HttpRequestCachePolicy CreateLastSyncPolicy(DateTime when)
        {
            HttpRequestCachePolicy policy = 
               new HttpRequestCachePolicy(when);
               
            Console.WriteLine("When: {0}", when);
            Console.WriteLine(policy.CacheSyncDate.ToString());
            return policy; 
        }
        //</snippet3>
        
        //<snippet4>
        public static void DisplayPolicyDetails(HttpRequestCachePolicy policy)
        {
            Console.WriteLine("Synchronize date: {0}", policy.CacheSyncDate);
            Console.WriteLine("Max age:   {0}", policy.MaxAge);
            Console.WriteLine("Max stale: {0}", policy.MaxStale);
            Console.WriteLine("Min fresh: {0}", policy.MinFresh);
        }
         //</snippet4>
         
         //<snippet5> 
        public static HttpRequestCachePolicy CreateMinFreshPolicy(TimeSpan span)
        {
            HttpRequestCachePolicy policy = 
                new HttpRequestCachePolicy(HttpCacheAgeControl.MinFresh, span); 
            Console.WriteLine("Minimum freshness {0}", policy.MinFresh.ToString());
            return policy;
        } 
        
        //</snippet5>
        
        //<snippet6>
        public static HttpRequestCachePolicy CreateMaxStalePolicy(TimeSpan span)
        {
            HttpRequestCachePolicy policy = 
                new HttpRequestCachePolicy(HttpCacheAgeControl.MaxStale, span);
               
           Console.WriteLine("Max stale is {0}", policy.MaxStale);
            return policy;
        } 
        //</snippet6> 
        
        //<snippet7>
        public static HttpRequestCachePolicy CreateMaxAgePolicy(TimeSpan span)
        {
            HttpRequestCachePolicy policy = 
                new HttpRequestCachePolicy(HttpCacheAgeControl.MaxAge, span); 
            Console.WriteLine("Max age is {0}", policy.MaxAge);
            return policy;
        } 
        //</snippet7>
        
        //<snippet8>
        public static HttpRequestCachePolicy CreateDefaultPolicy()
        {
            HttpRequestCachePolicy policy = 
                new HttpRequestCachePolicy(); 
            Console.WriteLine(policy.ToString());
            return policy; 
        } 
        //</snippet8>
        
        //<snippet9>
        public static HttpRequestCachePolicy CreateFreshAndAgePolicy(TimeSpan freshMinimum, TimeSpan ageMaximum)
        {
            HttpRequestCachePolicy policy = 
                new HttpRequestCachePolicy(HttpCacheAgeControl.MaxAgeAndMinFresh, ageMaximum, freshMinimum); 
            Console.WriteLine(policy.ToString());
            return policy; 
        }
        //</snippet9>
         
        //<snippet10>
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
        //</snippet10>
        
         //<snippet11>
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
           //</snippet11>

        //<snippet12>
        public static HttpRequestCachePolicy CreateCacheIfAvailablePolicy()
        {
            HttpRequestCachePolicy policy = 
                new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
               
            Console.WriteLine(policy.ToString());
            return policy;
            
        } 
        //</snippet12>

        //<snippet13>
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
        //</snippet13>

        //<snippet14>
        public static WebResponse GetResponseFromServer(Uri uri)
        {
             RequestCachePolicy policy = 
                new  RequestCachePolicy( RequestCacheLevel.NoCacheNoStore);
            WebRequest request = WebRequest.Create(uri);
            request.CachePolicy = policy;
            WebResponse response = request.GetResponse();
            Console.WriteLine("Policy is {0}.", policy.ToString());
            Console.WriteLine("Is the response from the cache? {0}", response.IsFromCache);  
            return response;
            
        } 
        //</snippet14>

        // <snippet15>
                public static WebResponse GetResponseFromServer2(Uri uri)
        {
             RequestCachePolicy policy = 
                new  RequestCachePolicy( RequestCacheLevel.NoCacheNoStore);
            WebRequest request = WebRequest.Create(uri);
            WebRequest.DefaultCachePolicy = policy;
            WebResponse response = request.GetResponse();
            Console.WriteLine("Policy is {0}.", policy.ToString());
            Console.WriteLine("Is the response from the cache? {0}", response.IsFromCache);  
            return response;
        } 
        // </snippet15>
        
        public static void Main()
        {
 /*           WebResponse response = GetResponseUsingDefaultCache (new Uri("http://www.example.com")); 
            DisplayResponseStream (response);
            Console.WriteLine("hit enter for next test..."); Console.ReadLine();
             response = GetResponseNoCache (new Uri("http://www.example.com"));
            DisplayResponseStream (response);

            DisplayPolicyDetails(CreateLastSyncPolicy(DateTime.Now));
            Console.WriteLine("hit enter for next test...");  Console.ReadLine();

            DisplayPolicyDetails(CreateMinFreshPolicy(new TimeSpan(10,0,0)));
            Console.WriteLine("hit enter for next test...");  Console.ReadLine();

            DisplayPolicyDetails(CreateMaxStalePolicy(new TimeSpan(1,10,0)));
            Console.WriteLine("hit enter for next test...");  Console.ReadLine();
            DisplayPolicyDetails(CreateMaxAgePolicy(new TimeSpan(10,0,0)));
            Console.WriteLine("hit enter for next test...");  Console.ReadLine();

            DisplayPolicyDetails(CreateDefaultPolicy());
            Console.WriteLine("hit enter for next test...");  Console.ReadLine();

            DisplayPolicyDetails(CreateFreshAndAgePolicy(new TimeSpan(5,0,0), new TimeSpan(10,0,0)));
            Console.WriteLine("hit enter for next test...");  Console.ReadLine();

            DisplayPolicyDetails(CreateFreshAndAgePolicy2(new TimeSpan(5,0,0), new TimeSpan(10,0,0), DateTime.Now));
            Console.WriteLine("hit enter for next test...");  Console.ReadLine();

             response = GetResponseUsingCacheDefault (new Uri("http://www.example.com")); 
            DisplayResponseStream (response);
            Console.WriteLine("hit enter for next test...");  Console.ReadLine();

            DisplayPolicyDetails(CreateCacheIfAvailablePolicy());

           response =  GetResponseFromCache (new Uri("http://www.example.com")); 
           DisplayResponseStream (response);
            Console.WriteLine("hit enter for next test..."); Console.ReadLine();
          response =  GetResponseFromServer (new Uri("http://www.example.com")); 
           DisplayResponseStream (response);

                       Console.WriteLine("hit enter for next test..."); Console.ReadLine();
   */     WebResponse  response =  GetResponseFromServer2 (new Uri("http://www.example.com")); 
           DisplayResponseStream (response);
            
            Console.WriteLine("done.");  

        }
        
        public static void DisplayResponseStream (WebResponse response)
        {
            Stream stream = response.GetResponseStream();
            while (true) 
            {
                byte[] buffer = new byte[1024];
                int read = stream.Read(buffer, 0, buffer.Length);
                if (read == 0) 
                {
                    stream.Close();
                    break;
                } 
                else
                {
                    Console.Write(Encoding.UTF8.GetString(buffer));
                }
            }
            stream.Close();
        }
    }
}
