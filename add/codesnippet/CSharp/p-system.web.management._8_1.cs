        public string GetRequestsRejected()
        {
            // Get the requests rejected.
            return (string.Format(
                "Requests rejected: {0}",
                processStatistics.RequestsRejected.ToString()));
        }
