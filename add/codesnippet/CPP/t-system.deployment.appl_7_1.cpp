        void LaunchAppUpdate()
        {
            if (ApplicationDeployment::IsNetworkDeployed)
            {
                ApplicationDeployment^ ad =
                    ApplicationDeployment::CurrentDeployment;
                ad->UpdateCompleted +=
                    gcnew AsyncCompletedEventHandler(this,
                    &Form1::LaunchAppUpdate_UpdateCompleted);

                ad->UpdateAsync();
            }
        }

        void LaunchAppUpdate_UpdateCompleted(Object^ sender,
            AsyncCompletedEventArgs^ e)
        {
            if (!e->Cancelled)
            {
                if (nullptr != e->Error)
                {
                    System::Windows::Forms::DialogResult dr =
                        MessageBox::Show(
                        "The application has been updated. Restart?",
                        "Restart Application",
                        MessageBoxButtons::OKCancel);
                    if (System::Windows::Forms::DialogResult::OK == dr)
                    {
                        Application::Restart();
                    }
                }
                else
                {
                    // Replace with your own error reporting or logging.
                    MessageBox::Show(
                        "The application encountered an error in " +
                        "downloading the latest update. Error: {0}",
                        e->Error->Message);
                }
            }
            else
            {
                // Replace with your own error reporting or logging.
                MessageBox::Show(
                    "The update of the application's latest version was " +
                    "cancelled.");
            }
        }