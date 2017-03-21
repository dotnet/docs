    public:
        bool CheckForUpdateDue()
        {
            bool isUpdateDue = false;

            if (ApplicationDeployment::IsNetworkDeployed)
            {
                ApplicationDeployment^ dueAppDeployment =
                    ApplicationDeployment::CurrentDeployment;
                TimeSpan^ updateInterval =
                    DateTime::Now - dueAppDeployment->TimeOfLastUpdateCheck;
                if (updateInterval->Days >= 3)
                {
                    isUpdateDue = true;
                }
            }

            return (isUpdateDue);
        }