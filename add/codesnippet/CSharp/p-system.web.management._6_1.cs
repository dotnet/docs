        public string GetProcessName()
        {
            // Get the requests in execution.
            return (string.Format(
                "Process name: {0}", 
                ProcessInformation.ProcessName));
        }