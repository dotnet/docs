        // Get the stack trace.
        public string GetThreadStackTrace()
        {
            return (string.Format(
                "Stack trace: {0}",
                ThreadInformation.StackTrace));
        }