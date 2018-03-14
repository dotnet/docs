//<snippet000>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//<snippet001>
using System.Net;
using System.Threading;
using System.Web.ClientServices;
using System.Web.ClientServices.Providers;
using System.Web.Security;
//</snippet001>

namespace ClientAppServicesDemo
{
    public class Form1 : Form
    {
        private TextBox webSettingsTestTextBox;
        private Button managerOnlyButton;
        private CheckBox workOfflineCheckBox;
        private Button logoutButton;
        private Label label1;

        public Form1()
        {
            InitializeComponent();
        }

        //<snippet010>
        private void Form1_Load(object sender, EventArgs e)
        {
            //<snippet011>
            MessageBox.Show("Welcome to the Client Application Services Demo.",
                "Welcome!");

            if (!ValidateUsingCredentialsProvider()) return;
            //</snippet011>

            //<snippet012>
            DisplayButtonForManagerRole();
            //</snippet012>

            //<snippet013>
            BindWebSettingsTestTextBox();
            //</snippet013>

            //<snippet014>
            workOfflineCheckBox.Checked = ConnectivityStatus.IsOffline;
            //</snippet014>

            //<snippet015>
            ((ClientSettingsProvider)Properties.Settings.Default.Providers
                ["System.Web.ClientServices.Providers.ClientSettingsProvider"])
                .SettingsSaved += 
                new EventHandler<SettingsSavedEventArgs>(Form1_SettingsSaved);
            //</snippet015>
        }
        //</snippet010>

        //<snippet020>
        private bool ValidateUsingCredentialsProvider()
        {
            bool isAuthorized = false;
            try
            {
                // Call ValidateUser with empty strings in order to display the 
                // login dialog box configured as a credentials provider.
                isAuthorized = Membership.ValidateUser(
                    String.Empty, String.Empty);
            }
            catch (System.Net.WebException)
            {
                if (DialogResult.OK == MessageBox.Show(
                    "Unable to access the authentication service." +
                    Environment.NewLine + "Attempt login in offline mode?",
                    "Warning", MessageBoxButtons.OKCancel, 
                    MessageBoxIcon.Warning))
                {
                    ConnectivityStatus.IsOffline = true;
                    isAuthorized = Membership.ValidateUser(
                        String.Empty, String.Empty);
                }
            }

            if (!isAuthorized)
            {
                MessageBox.Show("Unable to authenticate.", "Not logged in",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            return isAuthorized;
        }
        //</snippet020>

        //<snippet030>
        private void DisplayButtonForManagerRole()
        {
            try
            {
                if (Thread.CurrentPrincipal.IsInRole("manager"))
                {
                    managerOnlyButton.Visible = true;
                }
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("Unable to access the role service.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //</snippet030>

        //<snippet040>
        private void BindWebSettingsTestTextBox()
        {
            try
            {
                this.webSettingsTestTextBox.DataBindings.Add("Text",
                    Properties.Settings.Default, "WebSettingsTestText");
            }
            catch (WebException)
            {
                MessageBox.Show("Unable to access the Web settings service.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //</snippet040>

        //<snippet050>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            // Return without saving if the authentication type is not
            // "ClientForms". This indicates that the user is logged out.
            if (!Thread.CurrentPrincipal.Identity.AuthenticationType
              .Equals("ClientForms")) return;

            try
            {
                Properties.Settings.Default.Save();
            }
            catch (WebException ex)
            {
                if (ex.Message.Contains("You must log on to call this method."))
                {
                    MessageBox.Show(
                        "Your login has expired. Please log in again to save " +
                        "your settings.", "Attempting to save settings...");

                    try
                    {
                        // Call ValidateUser with empty strings in order to 
                        // display the login dialog box configured as a 
                        // credentials provider.
                        if (!Membership.ValidateUser(String.Empty, String.Empty))
                        {
                            MessageBox.Show("Unable to authenticate. " +
                                "Settings were not saved on the remote service.",
                                "Not logged in", MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
                        }
                        else
                        {
                            // Try again.
                            SaveSettings();
                        }
                    }
                    catch (System.Net.WebException)
                    {
                        MessageBox.Show(
                            "Unable to access the authentication service. " +
                            "Settings were not saved on the remote service.",
                            "Not logged in", MessageBoxButtons.OK, 
                            MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Unable to access the Web settings service. " +
                        "Settings were not saved on the remote service.", 
                        "Not logged in", MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning);
                }
            }
        }
        //</snippet050>

        //<snippet070>
        private void logoutButton_Click(object sender, EventArgs e)
        {
            SaveSettings();

            ClientFormsAuthenticationMembershipProvider authProvider =
                (ClientFormsAuthenticationMembershipProvider)
                System.Web.Security.Membership.Provider;

            try
            {
                authProvider.Logout();
            }
            catch (WebException ex)
            {
                MessageBox.Show("Unable to access the authentication service." +
                    Environment.NewLine + "Logging off locally only.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ConnectivityStatus.IsOffline = true;
                authProvider.Logout();
                ConnectivityStatus.IsOffline = false;
            }

            Application.Restart();
        }
        //</snippet070>

        //<snippet080>
        private void workOfflineCheckBox_CheckedChanged(
            object sender, EventArgs e)
        {
            ConnectivityStatus.IsOffline = workOfflineCheckBox.Checked;
            if (!ConnectivityStatus.IsOffline)
            {
                try
                {
                    // Silently re-validate the user.
                    ((ClientFormsIdentity)
                        System.Threading.Thread.CurrentPrincipal.Identity)
                        .RevalidateUser();

                    // If any settings have been changed locally, save the new
                    // new values to the Web settings service.
                    SaveSettings();

                    // If any settings have not been changed locally, check 
                    // the Web settings service for updates. 
                    Properties.Settings.Default.Reload();
                }
                catch (WebException)
                {
                    MessageBox.Show(
                        "Unable to access the authentication service. " +
                        Environment.NewLine + "Staying in offline mode.",
                        "Warning", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    workOfflineCheckBox.Checked = true;
                }
            }
        }
        //</snippet080>

        //<snippet090>
        private void Form1_SettingsSaved(object sender,
            SettingsSavedEventArgs e)
        {
            // If any settings were not saved, display a list of them.
            if (e.FailedSettingsList.Count > 0)
            {
                String failedSettings = String.Join(
                    Environment.NewLine,
                    e.FailedSettingsList.ToArray());

                String message = String.Format("{0}{1}{1}{2}",
                    "The following setting(s) were not saved:",
                    Environment.NewLine, failedSettings);

                MessageBox.Show(message, "Unable to save settings",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //</snippet090>

        private void InitializeComponent()
        {
            this.managerOnlyButton = new System.Windows.Forms.Button();
            this.workOfflineCheckBox = new System.Windows.Forms.CheckBox();
            this.webSettingsTestTextBox = new System.Windows.Forms.TextBox();
            this.logoutButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // managerOnlyButton
            // 
            this.managerOnlyButton.Location = new System.Drawing.Point(11, 51);
            this.managerOnlyButton.Name = "managerOnlyButton";
            this.managerOnlyButton.Size = new System.Drawing.Size(124, 50);
            this.managerOnlyButton.TabIndex = 1;
            this.managerOnlyButton.Text = "&Manager task";
            this.managerOnlyButton.UseVisualStyleBackColor = true;
            this.managerOnlyButton.Visible = false;
            // 
            // workOfflineCheckBox
            // 
            this.workOfflineCheckBox.AutoSize = true;
            this.workOfflineCheckBox.Location = new System.Drawing.Point(166, 12);
            this.workOfflineCheckBox.Name = "workOfflineCheckBox";
            this.workOfflineCheckBox.Size = new System.Drawing.Size(83, 17);
            this.workOfflineCheckBox.TabIndex = 2;
            this.workOfflineCheckBox.Text = "&Work offline";
            this.workOfflineCheckBox.UseVisualStyleBackColor = true;
            this.workOfflineCheckBox.CheckedChanged +=
                new System.EventHandler(this.workOfflineCheckBox_CheckedChanged);
            // 
            // webSettingsTestTextBox
            // 
            this.webSettingsTestTextBox.Location = new System.Drawing.Point(11, 25);
            this.webSettingsTestTextBox.Name = "webSettingsTestTextBox";
            this.webSettingsTestTextBox.Size = new System.Drawing.Size(124, 20);
            this.webSettingsTestTextBox.TabIndex = 0;
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(152, 51);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(124, 50);
            this.logoutButton.TabIndex = 3;
            this.logoutButton.Text = "&Log out";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "WebSettingsTestText";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(286, 111);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.workOfflineCheckBox);
            this.Controls.Add(this.webSettingsTestTextBox);
            this.Controls.Add(this.managerOnlyButton);
            this.Name = "Form1";
            this.Text = "Client Application Services Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(
                this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }
}
//</snippet000>