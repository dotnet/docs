    public:
        void InstallUpdateSyncWithInfo()
        {
            if (ApplicationDeployment::IsNetworkDeployed)
            {
                ApplicationDeployment^ deployment =
                    ApplicationDeployment::CurrentDeployment;
                UpdateCheckInfo^ updateInfo = nullptr;

                try
                {
                    updateInfo = deployment->CheckForDetailedUpdate();
                }
                catch (Exception^ ex)
                {
                    MessageBox::Show("The update failed. Error: {0}",
                        ex->Message);
                    return;
                }

                if (updateInfo->UpdateAvailable)
                {
                    bool doUpdate = true;

                    if (!updateInfo->IsUpdateRequired)
                    {
                        System::Windows::Forms::DialogResult dr =
                            MessageBox::Show(
                            "An update is available. Would you like to " +
                            "update the application now?",
                            "Update Available",
                            MessageBoxButtons::OKCancel);
                        if (!(System::Windows::Forms::DialogResult::OK == dr))
                        {
                            doUpdate = false;
                        }
                    }

                    if (doUpdate)
                    {
                        try
                        {
                            deployment->Update();
                            MessageBox::Show(
                                "The application has been upgraded, and will " +
                                "now restart.");
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
        }