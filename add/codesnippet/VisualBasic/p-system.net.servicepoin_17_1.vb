                ServicePointManager.UseNagleAlgorithm = True
                ServicePointManager.Expect100Continue = True
                ServicePointManager.CheckCertificateRevocationList = True
                ServicePointManager.DefaultConnectionLimit = _
                    ServicePointManager.DefaultPersistentConnectionLimit
                ServicePointManager.EnableDnsRoundRobin = True
                ServicePointManager.DnsRefreshTimeout = 4*60*1000