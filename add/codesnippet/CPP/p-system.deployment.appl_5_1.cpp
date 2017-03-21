    public:
        bool IsNewVersionAvailable()
        {
            bool isRestartRequired = false;

            if (ApplicationDeployment::IsNetworkDeployed)
            {
                ApplicationDeployment^ restartAppDeployment =
                    ApplicationDeployment::CurrentDeployment;
                if (restartAppDeployment->UpdatedVersion > 
                    restartAppDeployment->CurrentVersion)
                {
                    isRestartRequired = true;
                }
            }

            return (isRestartRequired);
        }