        public static WebProxy CreateProxyWithHostAddress(bool bypassLocal)
        {
            WebProxy proxy =  new WebProxy("http://contoso", bypassLocal);
            Console.WriteLine("Bypass proxy for local URIs?: {0}", 
               proxy.BypassProxyOnLocal);
            return proxy;
        }