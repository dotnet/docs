        public static WebProxy CreateProxyWithExampleAddress(bool bypassLocal)
        {
            return new WebProxy(new Uri("http://contoso"), bypassLocal);
        }