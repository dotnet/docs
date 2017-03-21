    public:
        void LaunchUpdate()
        {
            if (ApplicationDeployment::IsNetworkDeployed)
            {
                ApplicationDeployment^ launchAppDeployment =
                    ApplicationDeployment::CurrentDeployment;
                // Launch synchronous or asynchronous update.
            }
        }