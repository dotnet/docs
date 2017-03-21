        public string GetProcessId()
        {
            // Get the process identifier.
            return (string.Format(
                "Process Id: {0}", 
                ProcessInformation.ProcessID.ToString()));
        }