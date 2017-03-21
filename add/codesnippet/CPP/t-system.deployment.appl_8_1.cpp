    public:
        void InstallUpdateSync()
        {
            if (ApplicationDeployment::IsNetworkDeployed)
            {
                bool isUpdateAvailable = false;
                ApplicationDeployment^ appDeployment =
                    ApplicationDeployment::CurrentDeployment;

                try
                {
                    isUpdateAvailable = appDeployment->CheckForUpdate();
                }
                catch (InvalidOperationException^ ex)
                {
                    MessageBox::Show("The update check failed. Error: {0}",
                        ex->Message);
                    return;
                }

                if (isUpdateAvailable)
                {
                    try
                    {
                        appDeployment->Update();
                        MessageBox::Show(
                            "The application has been upgraded, and will now " +
                            "restart.");
                        Application::Restart();
                    }
                    catch (Exception^ ex)
                    {
                        MessageBox::Show("The update failed. Error: {0}",
                            ex->Message);
                        return;
                    }

                }
            }
        }