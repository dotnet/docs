#using <System.Drawing.dll>
#using <System.Data.dll>
#using <System.Deployment.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Deployment::Application;

namespace ClickOnceAPIExample
{
    /// <summary>
    /// Summary description for form.
    /// </summary>
    public ref class Form1 : public System::Windows::Forms::Form
    {
    private:
        System::Windows::Forms::Timer^ timer1;
    private:
        System::Windows::Forms::StatusStrip^ statusStrip1;
    private:
        System::Windows::Forms::ToolStripContainer^ topToolStripContainer;
    private:
        System::Windows::Forms::ToolStripContainer^ bottomToolStripContainer;
    private:
        System::Windows::Forms::ToolStripContainer^ leftToolStripContainer;
    private:
        System::Windows::Forms::ToolStripContainer^ rightToolStripContainer;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
    private:
        void InitializeComponent()
        {
            this->components = gcnew System::ComponentModel::Container();
            this->timer1 = gcnew System::Windows::Forms::Timer(
                this->components);
            this->statusStrip1 = gcnew System::Windows::Forms::StatusStrip();
            this->topToolStripContainer =
                gcnew System::Windows::Forms::ToolStripContainer();
            this->bottomToolStripContainer =
                gcnew System::Windows::Forms::ToolStripContainer();
            this->leftToolStripContainer =
                gcnew System::Windows::Forms::ToolStripContainer();
            this->rightToolStripContainer =
                gcnew System::Windows::Forms::ToolStripContainer();
            this->bottomToolStripContainer->SuspendLayout();
            this->SuspendLayout();
            //
            // timer1
            //
            this->timer1->Tick += gcnew System::EventHandler(this,
                &Form1::timer1_Tick);
            //
            // statusStrip1
            //
            this->statusStrip1->CanOverflow = false;
            this->statusStrip1->GripStyle = 
                System::Windows::Forms::ToolStripGripStyle::Hidden;
            this->statusStrip1->Location = System::Drawing::Point(0, 3);
            this->statusStrip1->Name = "statusStrip1";
            this->statusStrip1->Size = System::Drawing::Size(913, 23);
            this->statusStrip1->TabIndex = 0;
            this->statusStrip1->Text = "statusStrip1";
            //
            // topToolStripContainer
            //
            this->topToolStripContainer->Dock = 
                System::Windows::Forms::DockStyle::Top;
            this->topToolStripContainer->Name = "topToolStripContainer";
            //
            // bottomToolStripContainer
            //
            this->bottomToolStripContainer->ContentPanel->Controls->
                Add(this->statusStrip1);
            this->bottomToolStripContainer->Dock = 
                System::Windows::Forms::DockStyle::Bottom;
            this->bottomToolStripContainer->Name = "bottomToolStripContainer";
            //
            // leftToolStripContainer
            //
            this->leftToolStripContainer->Dock = 
                System::Windows::Forms::DockStyle::Left;
            this->leftToolStripContainer->Name = "leftToolStripContainer";
            //
            // rightToolStripContainer
            //
            this->rightToolStripContainer->Dock = 
                System::Windows::Forms::DockStyle::Right;
            this->rightToolStripContainer->Name = "rightToolStripContainer";
            //
            // Form1
            //
            this->AutoScaleBaseSize = System::Drawing::Size(5, 13);
            this->AutoSize = true;
            this->ClientSize = System::Drawing::Size(931, 241);
            this->Controls->Add(this->topToolStripContainer);
            this->Controls->Add(this->bottomToolStripContainer);
            this->Controls->Add(this->leftToolStripContainer);
            this->Controls->Add(this->rightToolStripContainer);
            this->Name = "Form1";
            this->Padding = System::Windows::Forms::Padding(9);
            this->Text = "Form1";
            this->Load += gcnew System::EventHandler(this,&Form1::Form1_Load);
            this->bottomToolStripContainer->ResumeLayout(false);
            this->bottomToolStripContainer->PerformLayout();
            this->ResumeLayout(false);
            this->PerformLayout();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
    protected:
        ~Form1()
		{
			if (components)
			{
				delete components;
			}
		}

        /// <summary>
        /// Required designer variable.
        /// </summary>
    private:
        System::ComponentModel::IContainer^ components;

        //
        // NOTE:
        // Change the method call in Form1_Load in order to execute another
        // sample in this application.
    public:
        Form1()
        {
            InitializeComponent();
        }

        // ApplicationDeployment - Main Ref Portal
        //<SNIPPET1>
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
        //</SNIPPET1>

        // ApplicationDeployment.CurrentDeployment
        //<SNIPPET2>
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
        //</SNIPPET2>

        // ApplicationDeployment.LastCheckForUpdateTime
        //<SNIPPET3>
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
        //</SNIPPET3>

        //<SNIPPET4>
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
        //</SNIPPET4>

        // ApplicationDeployment.CancelAsync
        //<SNIPPET5>
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
        //</SNIPPET5>

        // ApplicationDeployment.CheckForUpdate
        // ApplicationDeployment.Update
        //<SNIPPET6>
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
        //</SNIPPET6>

        // ApplicationDeployment.GetUpdateCheckInfo
        //<SNIPPET7>
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
        //</SNIPPET7>

        // ApplicationDeployment.UpdateCompleted
        // NOTE: This is a modification of SNIPPET1 that puts the emphasis on
        // the UpdateCompleted event handler.
        //<SNIPPET8>
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
        //</SNIPPET8>
    };
}

/// <summary>
/// The main entry point for the application.
/// </summary>
[STAThread]
void main()
{
    Application::Run(gcnew ClickOnceAPIExample::Form1());
}
