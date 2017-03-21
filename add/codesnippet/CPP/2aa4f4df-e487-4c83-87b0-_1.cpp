    private:
        long sizeOfUpdate;


    private:
        void Form1_Load(Object^ sender, System::EventArgs^ e)
        {
            DoUpdate();
        }

    public:
        void DoUpdate()
        {
            if (ApplicationDeployment::IsNetworkDeployed)
            {
                ApplicationDeployment^ currentAppDeployment =
                    ApplicationDeployment::CurrentDeployment;
                currentAppDeployment->CheckForUpdateCompleted +=
                    gcnew CheckForUpdateCompletedEventHandler(
                    this, &Form1::currentDeploy_CheckForUpdateCompleted);
                currentAppDeployment->CheckForUpdateAsync();
            }
        }

        // If update is available, fetch it.
        void currentDeploy_CheckForUpdateCompleted(Object^ sender,
            CheckForUpdateCompletedEventArgs^ e)
        {
            if (nullptr != e->Error)
            {
                // Log error.
                return;
            }

            if (e->UpdateAvailable)
            {
                sizeOfUpdate = (long) e->UpdateSizeBytes;
                if (!e->IsUpdateRequired)
                {
                    System::Windows::Forms::DialogResult 
                        updateDialogueResult = MessageBox::Show(
                        "An update is available.Would you like to update the" +
                        " application now?", "Update Available",
                        MessageBoxButtons::OKCancel);
                    if (System::Windows::Forms::DialogResult::OK == 
                        updateDialogueResult)
                    {
                        BeginUpdate();
                    }
                }
                else
                {
                    BeginUpdate();
                }
            }
        }

        void BeginUpdate()
        {
            ApplicationDeployment^ ad = ApplicationDeployment::CurrentDeployment;
            ad->UpdateCompleted +=
                gcnew AsyncCompletedEventHandler(
                this, &Form1::CurrentDeployment_UpdateCompleted);

            // Indicate progress in the application's status bar.
            ad->UpdateProgressChanged +=
                gcnew DeploymentProgressChangedEventHandler(this, 
                &Form1::ad_ProgressChanged);

            ad->UpdateAsync();
        }

        void CurrentDeployment_UpdateCompleted(Object^ sender,
            AsyncCompletedEventArgs^ e)
        {
            if (!e->Cancelled)
            {
                if (nullptr != e->Error)
                {
                    System::Windows::Forms::DialogResult 
                        restartDialogueResult = MessageBox::Show(
                        "The application has been updated. Restart?",
                        "Restart Application",
                        MessageBoxButtons::OKCancel);
                    if (System::Windows::Forms::DialogResult::OK == 
                        restartDialogueResult)
                    {
                        Application::Restart();
                    }
                }
                else
                {
                    // Replace with your own error reporting or logging.
                    MessageBox::Show(
                        "The application encountered an error in downloading" +
                        " the latest update. Error: {0}",
                        e->Error->Message);
                }
            }
            else
            {
                // Replace with your own error reporting or logging.
                MessageBox::Show("The update of the application's latest" +
                    " version was cancelled.");
            }
        }

        void ad_ProgressChanged(Object^ sender,
            DeploymentProgressChangedEventArgs^ e)
        {
            String^ progressText =
                String::Format(
                "{0:D}K out of {1:D}K downloaded - {2:D}% complete",
                e->BytesCompleted / 1024, e->BytesTotal / 1024,
                e->ProgressPercentage);
            statusStrip1->Text = progressText;
        }