            ServicePointManager.UseNagleAlgorithm = true;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.CheckCertificateRevocationList = true;
            ServicePointManager.DefaultConnectionLimit = ServicePointManager.DefaultPersistentConnectionLimit;
            ServicePointManager.EnableDnsRoundRobin = true;
            ServicePointManager.DnsRefreshTimeout = 4*60*1000; // 4 minutes