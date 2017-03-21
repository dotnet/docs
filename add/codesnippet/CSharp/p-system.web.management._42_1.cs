        public string GetProcessStartTime()
        {
            // Get the process start time.
            return (string.Format(
                "Process start time: {0}",
                processStatistics.ProcessStartTime.ToString()));
        }
