    public:
        void LaunchUpdateWithTimeout()
        {
            if (ApplicationDeployment::IsNetworkDeployed)
            {
                ApplicationDeployment^ appDeployment =
                    ApplicationDeployment::CurrentDeployment;
                appDeployment->UpdateCompleted +=
                    gcnew AsyncCompletedEventHandler(this, 
                    &Form1::deploy_UpdateCompleted);

                // The Interval property uses millisecond resolution.
                timer1->Interval = (1000 * 60) * 2;
                timer1->Start();

                appDeployment->UpdateAsync();
            }
        }

    private:
        void deploy_UpdateCompleted(Object^ sender,
            AsyncCompletedEventArgs^ e)
        {
            timer1->Stop();
            if (!e->Cancelled)
            {
                if (nullptr == e->Error)
                {
                    Application::Restart();
                }
                else
                {
                    // Replace with your own error reporting or logging.
                    MessageBox::Show(
                        "The update of the application encountered an " +
                        "error. Error message: {0}",
                        e->Error->Message);
                }
            }
            else
            {
                // Replace with your own error reporting or logging.
                MessageBox::Show(
                    "The application update was cancelled because the update " +
                    "server was unreachable. Please try again later.");
            }
        }

    private:
        void timer1_Tick(Object^ sender, EventArgs^ e)
        {
            if (ApplicationDeployment::IsNetworkDeployed)
            {
                ApplicationDeployment::CurrentDeployment->UpdateAsyncCancel();
            }
        }