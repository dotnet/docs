        public string GetAppDomainCount()
        {
            // Get the app domain count.
            return (string.Format(
                "Application domain count: {0}",
                processStatistics.AppDomainCount.ToString()));
        }
