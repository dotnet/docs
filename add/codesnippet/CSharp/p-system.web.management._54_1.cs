        // Get the task Id.
        public string GetThreadId()
        {
            // Get the request principal.
            return (string.Format(
                "Thread Id: {0}",
                ThreadInformation.ThreadID.ToString()));
        }