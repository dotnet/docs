using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Deployment.Application;
using System.Net;
using System.Security.Permissions;

namespace ClickOnceAPI
{
    [System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        private void UpdateAppButton_Click(object sender, EventArgs e)
        {
            UpdateApplication();
        }

        //<SNIPPET1>
        long sizeOfUpdate = 0;

        //<SNIPPET2>
        private void UpdateApplication()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                ad.CheckForUpdateCompleted += new CheckForUpdateCompletedEventHandler(ad_CheckForUpdateCompleted);
                ad.CheckForUpdateProgressChanged += new DeploymentProgressChangedEventHandler(ad_CheckForUpdateProgressChanged);

                ad.CheckForUpdateAsync();
            }
        }

        void  ad_CheckForUpdateProgressChanged(object sender, DeploymentProgressChangedEventArgs e)
        {
            downloadStatus.Text = String.Format("Downloading: {0}. {1:D}K of {2:D}K downloaded.", GetProgressString(e.State), e.BytesCompleted/1024, e.BytesTotal/1024);   
        }

        string GetProgressString(DeploymentProgressState state)
        {
            if (state == DeploymentProgressState.DownloadingApplicationFiles)
            {
                return "application files";
            } 
            else if (state == DeploymentProgressState.DownloadingApplicationInformation) 
            {
                return "application manifest";
            } 
            else 
            {
                return "deployment manifest";
            }
        }

        void ad_CheckForUpdateCompleted(object sender, CheckForUpdateCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("ERROR: Could not retrieve new version of the application. Reason: \n" + e.Error.Message + "\nPlease report this error to the system administrator.");
                return;
            }
            else if (e.Cancelled == true)
            {
                MessageBox.Show("The update was cancelled.");
            }

            // Ask the user if they would like to update the application now.
            if (e.UpdateAvailable)
            {
                sizeOfUpdate = e.UpdateSizeBytes;

                if (!e.IsUpdateRequired)
                {
                    DialogResult dr = MessageBox.Show("An update is available. Would you like to update the application now?\n\nEstimated Download Time: ", "Update Available", MessageBoxButtons.OKCancel);
                    if (DialogResult.OK == dr)
                    {
                        BeginUpdate();
                    }
                }
                else
                {
                    MessageBox.Show("A mandatory update is available for your application. We will install the update now, after which we will save all of your in-progress data and restart your application.");
                    BeginUpdate();
                }
            }
        }
        //</SNIPPET2>

        private void BeginUpdate()
        {
            ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
            ad.UpdateCompleted += new AsyncCompletedEventHandler(ad_UpdateCompleted);

            // Indicate progress in the application's status bar.
            ad.UpdateProgressChanged += new DeploymentProgressChangedEventHandler(ad_UpdateProgressChanged);
            ad.UpdateAsync();
        }

        void ad_UpdateProgressChanged(object sender, DeploymentProgressChangedEventArgs e)
        {
            String progressText = String.Format("{0:D}K out of {1:D}K downloaded - {2:D}% complete", e.BytesCompleted / 1024, e.BytesTotal / 1024, e.ProgressPercentage);
            downloadStatus.Text = progressText;
        }

        void ad_UpdateCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("The update of the application's latest version was cancelled.");
                return;
            }
            else if (e.Error != null)
            {
                MessageBox.Show("ERROR: Could not install the latest version of the application. Reason: \n" + e.Error.Message + "\nPlease report this error to the system administrator.");
                return;
            }

            DialogResult dr = MessageBox.Show("The application has been updated. Restart? (If you do not restart now, the new version will not take effect until after you quit and launch the application again.)", "Restart Application", MessageBoxButtons.OKCancel);
            if (DialogResult.OK == dr)
            {
                Application.Restart();
            }
        }
        //</SNIPPET1>

        //<SNIPPET3>
        private Boolean CheckForUpdateDue()
        {
            Boolean isUpdateDue = false;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                TimeSpan updateInterval = DateTime.Now - ad.TimeOfLastUpdateCheck;
                if (updateInterval.Days > 3)
                {
                    isUpdateDue = true;
                }
            }

            return (isUpdateDue);
        }
        //</SNIPPET3>

        //<SNIPPET4>
        public Boolean IsNewVersionAvailable()
        {
            Boolean isRestartRequired = false;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                if (ad.UpdatedVersion > ad.CurrentVersion)
                {
                    isRestartRequired = true;
                }
            }

            return (isRestartRequired);
        }
        //</SNIPPET4>

        //<SNIPPET5>
        private void InstallUpdateSync()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                Boolean updateAvailable = false;
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    updateAvailable = ad.CheckForUpdate();
                }
                catch (DeploymentDownloadException dde)
                {
                    // This exception occurs if a network error or disk error occurs
                    // when downloading the deployment.
                    MessageBox.Show("The application cannt check for the existence of a new version at this time. \n\nPlease check your network connection, or try again later. Error: " + dde);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    MessageBox.Show("The application cannot check for an update. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show("This application cannot check for an update. This most often happens if the application is already in the process of updating. Error: " + ioe.Message);
                    return;
                }

                if (updateAvailable)
                {
                    try
                    {
                        ad.Update();
                        MessageBox.Show("The application has been upgraded, and will now restart.");
                        Application.Restart();
                    }
                    catch (DeploymentDownloadException dde)
                    {
                        MessageBox.Show("Cannot install the latest version of the application. Either the deployment server is unavailable, or your network connection is down. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
                    }
                    catch (TrustNotGrantedException tnge)
                    {
                        MessageBox.Show("The application cannot be updated. The system did not grant the application the appropriate level of trust. Please contact your system administrator or help desk for further troubleshooting. Error: " + tnge.Message);
                    }
                }
            }
        }
        //</SNIPPET5>

        //<SNIPPET6>
        private void InstallUpdateSyncWithInfo()
        {
            UpdateCheckInfo info = null;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    info = ad.CheckForDetailedUpdate();

                }
                catch (DeploymentDownloadException dde)
                {
                    MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    MessageBox.Show("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message);
                    return;
                }

                if (info.UpdateAvailable)
                {
                    Boolean doUpdate = true;

                    if (!info.IsUpdateRequired)
                    {
                        DialogResult dr = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel);
                        if (!(DialogResult.OK == dr))
                        {
                            doUpdate = false;
                        }
                    }
                    else
                    {
                        // Display a message that the app MUST reboot. Display the minimum required version.
                        MessageBox.Show("This application has detected a mandatory update from your current " + 
                            "version to version " + info.MinimumRequiredVersion.ToString() + 
                            ". The application will now install the update and restart.", 
                            "Update Available", MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);
                    }

                    if (doUpdate)
                    {
                        try
                        {
                            ad.Update();
                            MessageBox.Show("The application has been upgraded, and will now restart.");
                            Application.Restart();
                        }
                        catch (DeploymentDownloadException dde)
                        {
                            MessageBox.Show("Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error: " + dde);
                            return;
                        }
                    }
                }
            }
        }
        //</SNIPPET6>

        //<SNIPPET7>
        public void LaunchAppUpdate()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment appDeploy = ApplicationDeployment.CurrentDeployment;
                appDeploy.UpdateCompleted += new AsyncCompletedEventHandler(appDeploy_UpdateCompleted);
            }
        }

        void appDeploy_UpdateCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Could not install application update. Please try again later,  or contact a system administrator.", "Application Update Error");
                return;
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("The application update has been cancelled.", "Application Update Cancelled");
                return;
            }

            // Process successful update.
            DialogResult dr = MessageBox.Show("The application has been updated. Restart?", "Restart Application", MessageBoxButtons.OKCancel);
            if (DialogResult.OK == dr)
            {
                Application.Restart();
            }
        }

        //</SNIPPET7>

        //<SNIPPET8>
        private void DownloadFileGroupAsync(string fileGroup)
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment deployment = ApplicationDeployment.CurrentDeployment;

                try
                {
                    if (!deployment.IsFileGroupDownloaded(fileGroup))
                    {
                        deployment.DownloadFileGroupProgressChanged += new DeploymentProgressChangedEventHandler(deployment_DownloadFileGroupProgressChanged);
                        deployment.DownloadFileGroupCompleted += new DownloadFileGroupCompletedEventHandler(deployment_DownloadFileGroupCompleted);

                        deployment.DownloadFileGroupAsync(fileGroup);
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show("This application is not a ClickOnce application. Error: " + ioe.Message);
                    return;
                }
            }
        }

        void deployment_DownloadFileGroupProgressChanged(object sender, DeploymentProgressChangedEventArgs e)
        {
            downloadStatus.Text = String.Format("Downloading file group {0}; {1:D}K of {2:D}K completed.", e.Group, e.BytesCompleted / 1024, e.BytesTotal / 1024);               
        }

        void deployment_DownloadFileGroupCompleted(object sender, DownloadFileGroupCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                downloadStatus.Text = "Could not download files. Will try again later.";
                return;
            }
            else if (e.Cancelled)
            {
                downloadStatus.Text = "The file download has been cancelled.";
                return;
            }

            downloadStatus.Text = String.Format("Download of file group {0} complete.", e.Group);
        }
        //</SNIPPET8>

        //<SNIPPET9>
        private void DownloadFileGroupSync(string fileGroup)
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment deployment = ApplicationDeployment.CurrentDeployment;

                if (deployment.IsFirstRun)
                {
                    try
                    {
                        if (deployment.IsFileGroupDownloaded(fileGroup))
                        {
                            deployment.DownloadFileGroup(fileGroup);
                        } 
                    }
                    catch (InvalidOperationException ioe)
                    {
                        MessageBox.Show("This application is not a ClickOnce application. Error: " + ioe.Message);
                        return;
                    }

                    downloadStatus.Text = String.Format("Download of file group {0} complete.", fileGroup);
                }
            }            
        }

        //</SNIPPET9>

        //<SNIPPET10>
        ApplicationDeployment adCheckForUpdateAsyncMin;

        private void CheckForUpdateAsyncMin()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                adCheckForUpdateAsyncMin = ApplicationDeployment.CurrentDeployment;
                adCheckForUpdateAsyncMin.CheckForUpdateCompleted += new CheckForUpdateCompletedEventHandler(adCheckForUpdateAsyncMin_CheckForUpdateCompleted);

                adCheckForUpdateAsyncMin.CheckForUpdate();
            }
        }

        void adCheckForUpdateAsyncMin_CheckForUpdateCompleted(object sender, CheckForUpdateCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Could not install application update. Please try again later,  or contact a system administrator.", "Application Update Error");
                return;
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("The application update has been cancelled.", "Application Update Cancelled");
                return;
            }

            adCheckForUpdateAsyncMin = ApplicationDeployment.CurrentDeployment;
            if (e.MinimumRequiredVersion > adCheckForUpdateAsyncMin.CurrentVersion)
            {
                // Launch an install of the minimum required version. 
                adCheckForUpdateAsyncMin.UpdateCompleted += new AsyncCompletedEventHandler(adCheckForUpdateAsyncMin_UpdateCompleted);
                adCheckForUpdateAsyncMin.UpdateAsync();
            }
        }

        void adCheckForUpdateAsyncMin_UpdateCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // Alert user that update is complete.
            if (e.Error != null)
            {
                MessageBox.Show("Could not install application update. We will try and upgrade the application later.", "Application Update Error");
                return;
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("The application update has been cancelled.", "Application Update Cancelled");
                return;
            }

            MessageBox.Show("The update was successful. Your application will now be restarted.", "Restart Application");
            Application.Restart();
        }
        //</SNIPPET10>
    }
}