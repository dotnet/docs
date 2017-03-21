        public static WebProxy CreateProxyWithCredentials(bool bypassLocal)
        {
            // Do not use the proxy server for Contoso.com URIs.
            string[] bypassList = new string[]{";*.Contoso.com"};
            return new WebProxy("http://contoso", 
                bypassLocal, 
                bypassList,
                CredentialCache.DefaultCredentials);
        }