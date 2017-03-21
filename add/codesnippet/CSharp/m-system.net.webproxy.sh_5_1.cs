        public static WebProxy CreateProxyWithBypassList(bool bypassLocal)
        {
            // Do not use the proxy server for Contoso.com URIs.
            string[] bypassList = new string[]{";*.Contoso.com"};
            return new WebProxy(new Uri("http://contoso"), 
                bypassLocal, 
                bypassList);
        }