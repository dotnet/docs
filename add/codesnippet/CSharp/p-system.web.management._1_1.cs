        public string GetManagedHeapSize()
        {
            // Get the mamaged heap size.
            return (string.Format(
                "Managed heap size: {0}",
                processStatistics.ManagedHeapSize.ToString()));
        }
