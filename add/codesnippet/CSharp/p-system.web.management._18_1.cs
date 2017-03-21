        public string GetRequestsExecuting()
        {
            // Get the requests in execution.
            return (string.Format(
                "Requests executing: {0}",
                processStatistics.RequestsExecuting.ToString()));
        }
