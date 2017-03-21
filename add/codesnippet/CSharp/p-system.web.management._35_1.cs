        public string GetThreadCount()
        {
            // Get the thread count.
            return (string.Format(
                "Thread count: {0}",
                processStatistics.ThreadCount.ToString()));
        }
