        public string GetApplicationMachineName()
        {
            // Get the name of the application machine name.
            return (string.Format(
                "Application machine name: {0}",
                ApplicationInformation.MachineName));
        }