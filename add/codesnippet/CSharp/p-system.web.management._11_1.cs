        // Get the impersonation mode.
        public string GetThreadImpersonation()
        {
            return (string.Format(
                "Is impersonating: {0}",
                ThreadInformation.IsImpersonating.ToString()));
        }