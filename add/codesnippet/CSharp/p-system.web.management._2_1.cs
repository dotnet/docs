        public string GetApplicationTrustLevel()
        {
            // Get the name of the application trust level.
            return (string.Format(
                "Application trust level: {0}",
                ApplicationInformation.TrustLevel));
        }