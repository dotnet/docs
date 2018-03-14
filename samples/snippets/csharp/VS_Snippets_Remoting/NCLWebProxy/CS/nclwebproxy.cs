using System;
using System.Net;

public class ExampleForWebProxy
    {
//<snippet1>
        public static WebProxy CreateProxy()
        {
            return new WebProxy();
        }
//</snippet1>        

        //<snippet2>
        public static WebProxy CreateProxyWithExampleAddress()
        {
            return new WebProxy(new Uri("http://contoso"));
        }
        //</snippet2>     

        //<snippet3>
        public static WebProxy CreateProxyWithExampleAddress(bool bypassLocal)
        {
            return new WebProxy(new Uri("http://contoso"), bypassLocal);
        }
        //</snippet3>     
        //<snippet4>
        public static WebProxy CreateProxyWithBypassList(bool bypassLocal)
        {
            // Do not use the proxy server for Contoso.com URIs.
            string[] bypassList = new string[]{";*.Contoso.com"};
            return new WebProxy(new Uri("http://contoso"), 
                bypassLocal, 
                bypassList);
        }
        //</snippet4>   
        
        //<snippet6>
        public static WebProxy CreateProxyWithHost()
        {
            return new WebProxy("http://contoso");
        }
        //</snippet6>     
        
        //<snippet5>
        public static WebProxy CreateProxyWithHostAndPort()
        {
            return new WebProxy("http://contoso", 80);
        }
        //</snippet5>    
        
        //<snippet7>
        public static WebProxy CreateProxyWithHostAddress(bool bypassLocal)
        {
            WebProxy proxy =  new WebProxy("http://contoso", bypassLocal);
            Console.WriteLine("Bypass proxy for local URIs?: {0}", 
               proxy.BypassProxyOnLocal);
            return proxy;
        }
        //</snippet7>      
        
        //<snippet8>
        public static WebProxy CreateProxyWithHostAndBypassList(bool bypassLocal)
        {
            // Do not use the proxy server for Contoso.com URIs.
            string[] bypassList = new string[]{";*.Contoso.com"};
            return new WebProxy("http://contoso", 
                bypassLocal, 
                bypassList);
        }
        //</snippet8>   
        
        //<snippet9>
        public static WebProxy CreateProxyWithCredentials(bool bypassLocal)
        {
            // Do not use the proxy server for Contoso.com URIs.
            string[] bypassList = new string[]{";*.Contoso.com"};
            return new WebProxy("http://contoso", 
                bypassLocal, 
                bypassList,
                CredentialCache.DefaultCredentials);
        }
        //</snippet9>   
        //<snippet10>
        public static void DisplayDefaultProxy()
        {
            WebProxy proxy = WebProxy.GetDefaultProxy();
        
            Console.WriteLine("Address: {0}", proxy.Address);
            
            Console.WriteLine("Bypass on local: {0}", 
                proxy.BypassProxyOnLocal);
            int count = proxy.BypassList.Length;
            if (count == 0)
            {
                Console.WriteLine("The bypass list is empty.");
                return;
            }
            string[] bypass = proxy.BypassList;
            Console.WriteLine("The bypass list contents:");
        
            for (int i=0; i< count; i++)
            {
                Console.WriteLine(bypass[i]);
            }
        
        }
        //</snippet10>   
        
   //<snippet11> 
    public static void CheckDefaultProxyForRequest(Uri resource)
    {
        WebProxy proxy = (WebProxy) WebProxy.GetDefaultProxy();
                
        // See what proxy is used for resource.
        Uri resourceProxy = proxy.GetProxy(resource);

        // Test to see whether a proxy was selected.
        if (resourceProxy == resource)
        {
            Console.WriteLine("No proxy for {0}", resource);
        } 
        else
        {
            Console.WriteLine("Proxy for {0} is {1}", resource.ToString(),
                resourceProxy.ToString());
        }
    }
//</snippet11>  

    //<snippet12>
    public static WebProxy CreateProxyAndCheckBypass(bool bypassLocal)
    {
        // Do not use the proxy server for Contoso.com URIs.
        string[] bypassList = new string[]{";*.Contoso.com"};
        WebProxy proxy =  new WebProxy("http://contoso", 
            bypassLocal, 
            bypassList);
            
        // Test the bypass list.
        if (!proxy.IsBypassed(new Uri("http://www.Contoso.com")))
        {
            Console.WriteLine("Bypass not working!");
            return null;
        } 
        else 
        {
            Console.WriteLine("Bypass is working.");
            return proxy;
        }
    }
    //</snippet12>   
        
    //<snippet13>
    public static WebProxy CreateProxyWithCredentials2(bool bypassLocal)
    {
        // Do not use the proxy server for Contoso.com URIs.
        string[] bypassList = new string[]{";*.Contoso.com"};
        return new WebProxy(new Uri("http://contoso"), 
            bypassLocal, 
            bypassList,
            CredentialCache.DefaultCredentials);
    }
    //</snippet13>   
        public static void Main()
        {
            Uri resource = new Uri("http://www.example.com");
           /* CreateProxy();
            CreateProxyWithExampleAddress();
            CreateProxyWithExampleAddress(true);
            CreateProxyWithBypassList(true);
            CreateProxyWithHost();
            CreateProxyWithHostAndPort();
            CreateProxyWithHostAddress(true);
            CreateProxyWithHostAndBypassList(true);
            CreateProxyWithCredentials(true);
           
            DisplayDefaultProxy();
             */
           // CreateProxyAndCheckBypass(false); 
           CreateProxyWithCredentials2( false);
            
        }
        
    }