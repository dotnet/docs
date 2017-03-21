        public string GetPeakWorkingSet()
        {
            // Get the peak working set.
            return (string.Format(
                "Peak working set: {0}",
                processStatistics.PeakWorkingSet.ToString()));
        }
