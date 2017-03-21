        public string GetWorkingSet()
        {
            // Get the working set.
            return (string.Format(
                "Working set: {0}",
                processStatistics.WorkingSet.ToString()));
        }
