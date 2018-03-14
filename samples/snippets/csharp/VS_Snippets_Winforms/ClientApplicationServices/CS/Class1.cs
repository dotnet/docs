using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Web.ClientServices;
using System.Web.ClientServices.Providers;
using System.Windows.Forms;

namespace ClientAppServicesDemo
{
    class Misc
    {
        public void ValidateWithFixedStrings()
        {
            //<snippet300>
            if (!Membership.ValidateUser("manager", "manager!"))
            {
                MessageBox.Show("Unable to authenticate.", "Not logged in",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            //</snippet300>            
        }

        //<snippet301>
        private void SetAuthenticationServiceLocation()
        {
            ((ClientFormsAuthenticationMembershipProvider)
                System.Web.Security.Membership.Provider).ServiceUri =
                "http://localhost:55555/AppServices/Authentication_JSON_AppService.axd";
        }
        //</snippet301>

        //<snippet302>
        private void SetRolesServiceLocation()
        {
            ((ClientRoleProvider)System.Web.Security.Roles.Provider).ServiceUri = 
                "http://localhost:55555/AppServices/Role_JSON_AppService.axd";
        }
        //</snippet302>

        //<snippet303>
        private void SetWebSettingsServiceLocation()
        {
            ClientSettingsProvider.ServiceUri = 
                "http://localhost:55555/AppServices/Profile_JSON_AppService.axd";
        }
        //</snippet303>

        //<snippet304>
        private void AttachSettingsSavedEventHandler()
        {
            ((ClientSettingsProvider)Properties.Settings.Default.Providers
                ["System.Web.ClientServices.Providers.ClientSettingsProvider"])
                .SettingsSaved +=
                new EventHandler<SettingsSavedEventArgs>(Form1_SettingsSaved);
        }

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
        //</snippet304>

        public String Text
        {
            get { return string.Empty; }
            set { }
        }

        //<snippet305>
        private ClientFormsAuthenticationMembershipProvider formsMembershipProvider =
            (ClientFormsAuthenticationMembershipProvider)
            System.Web.Security.Membership.Provider;
        private String appName = "ClientAppServicesDemo";

        private void AttachUserValidatedEventHandler()
        {
            formsMembershipProvider.UserValidated += 
                new EventHandler<UserValidatedEventArgs>(Form1_UserValidated);
        }

        private void Form1_UserValidated(object sender, UserValidatedEventArgs e)
        {
            // Set the form's title bar to the application name and the user name.
            this.Text = String.Format("{0} ({1})", appName, e.UserName);
        }
        //</snippet305>

        //<snippet306>
        private bool ValidateUsingCredentialsProvider()
        {
            bool isAuthorized = false;
            try
            {
                ClientFormsAuthenticationMembershipProvider authProvider =
                    System.Web.Security.Membership.Provider as
                    ClientFormsAuthenticationMembershipProvider;

                // Call ValidateUser with empty strings in order to display the 
                // login dialog box configured as a credentials provider.
                isAuthorized = authProvider.ValidateUser(String.Empty, String.Empty);
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("Unable to access the authentication service.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (!isAuthorized)
            {
                MessageBox.Show("Unable to authenticate.", "Not logged in", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            return isAuthorized;
        }
        //</snippet306>

        private TextBox usernameTextBox = new TextBox();
        private TextBox passwordTextBox = new TextBox();
        private CheckBox rememberMeCheckBox = new CheckBox();

        //<snippet307>
        private bool ValidateUsingLoginControls()
        {
            bool isAuthorized = false;
            try
            {
                ClientFormsAuthenticationMembershipProvider authProvider =
                    System.Web.Security.Membership.Provider as
                    ClientFormsAuthenticationMembershipProvider;

                // Call ValidateUser with credentials retrieved from login controls.
                isAuthorized = authProvider.ValidateUser(usernameTextBox.Text,
                    passwordTextBox.Text, rememberMeCheckBox.Checked);
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("Unable to access the authentication service.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (!isAuthorized)
            {
                MessageBox.Show("Unable to authenticate.", "Not logged in",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            return isAuthorized;
        }
        //</snippet307>

        //<snippet308>
        private bool ValidateUsingServiceUri(String serviceUri)
        {
            bool isAuthorized = false;
            try
            {
                // Call the static overload of ValidateUser. Specify credentials 
                // retrieved from login controls and the service location.
                isAuthorized = 
                    ClientFormsAuthenticationMembershipProvider.ValidateUser(
                    usernameTextBox.Text, passwordTextBox.Text, serviceUri);
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("Unable to access the authentication service.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (!isAuthorized)
            {
                MessageBox.Show("Unable to authenticate.", "Not logged in",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            return isAuthorized;
        }
        //</snippet308>

        //<snippet309>
        private bool ValidateUsingWindowsAuthentication()
        {
            ClientWindowsAuthenticationMembershipProvider authProvider =
                System.Web.Security.Membership.Provider as
                ClientWindowsAuthenticationMembershipProvider;

            // Call ValidateUser and pass null values for the parameters.
            // This call always returns true.
            return authProvider.ValidateUser(null, null);
        }
        //</snippet309>

        //<snippet310>
        private void LogoutUsingWindowsAuthentication()
        {
            ClientWindowsAuthenticationMembershipProvider authProvider =
                System.Web.Security.Membership.Provider as
                ClientWindowsAuthenticationMembershipProvider;

            authProvider.Logout();
        }
        //</snippet310>

        //<snippet311>
        private void LogoutUsingFormsAuthentication()
        {
            ClientFormsAuthenticationMembershipProvider authProvider =
                (ClientFormsAuthenticationMembershipProvider)
                System.Web.Security.Membership.Provider;

            authProvider.Logout();
        }
        //</snippet311>

        //<snippet312>
        private void SaveSettings()
        {
            System.Security.Principal.IIdentity identity = 
                System.Threading.Thread.CurrentPrincipal.Identity;

            // Return if the user is not authenticated.
            if (identity == null || !identity.IsAuthenticated) return;

            // Return if the authentication type is not "ClientForms". 
            // This indicates that the user is not authenticated for 
            // client application services.
            if (!identity.AuthenticationType.Equals("ClientForms")) return;

            try
            {
                Properties.Settings.Default.Save();
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("Unable to access the Web settings service. " +
                    "Settings were not saved on the remote service.", 
                    "Not logged in", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //</snippet312>

        private Button managerOnlyButton = new Button();

        //<snippet313>
        private void DisplayButtonForManagerRole()
        {
            try
            {
                ClientRolePrincipal rolePrincipal =
                    System.Threading.Thread.CurrentPrincipal 
                    as ClientRolePrincipal;

                if (rolePrincipal != null && rolePrincipal.IsInRole("manager"))
                {
                    managerOnlyButton.Visible = true;
                }
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("Unable to access the roles service.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //</snippet313>

        //<snippet314>
        private void ResetRolesCache()
        {
            ((ClientRoleProvider)System.Web.Security.Roles.Provider).ResetCache();
        }
        //</snippet314>

        private CheckBox workOfflineCheckBox = new CheckBox();

        //<snippet315>
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
                catch (System.Net.WebException)
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
        //</snippet315>

        private void DisplayButtonForManagerRolePlain()
        {
            //<snippet316>
            if (System.Threading.Thread.CurrentPrincipal.IsInRole("manager"))
            {
                managerOnlyButton.Visible = true;
            }
            //</snippet316>
        }

        public void ValidateUserPlain()
        {
            //<snippet317>
            if (!System.Web.Security.Membership.ValidateUser(
                String.Empty, String.Empty))
            {
                MessageBox.Show("Unable to authenticate.", "Not logged in",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            //</snippet317>            

            //<snippet318>
            if (!System.Web.Security.Membership.ValidateUser(
                usernameTextBox.Text, passwordTextBox.Text))
            {
                MessageBox.Show("Unable to authenticate.", "Not logged in",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            //</snippet318>            

            //<snippet319>
            System.Web.Security.Membership.ValidateUser(
                String.Empty, String.Empty);
            //</snippet319>

        }

        private CheckBox checkBox1 = new CheckBox();

        //<snippet320>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ConnectivityStatus.IsOffline = checkBox1.Checked;
        }
        //</snippet320>

        private void PerformManagerTask(){}

        //<snippet321>
        private void AttemptManagerTask()
        {
            System.Security.Principal.IIdentity identity =
                System.Threading.Thread.CurrentPrincipal.Identity;

            // Return if the authentication type is not "ClientForms". 
            // This indicates that the user is logged out.
            if (!identity.AuthenticationType.Equals("ClientForms")) return;

            try
            {
                ClientRoleProvider provider =
                    (ClientRoleProvider)System.Web.Security.Roles.Provider;
                String userName = identity.Name;

                // Determine whether the user login has expired by attempting
                // to retrieve roles from the service. Call the ResetCache method
                // to ensure that the roles are retrieved from the service. If no 
                // roles are returned, then the login has expired. This assumes 
                // that every valid user has been assigned to one or more roles.
                provider.ResetCache();
                String[] roles = provider.GetRolesForUser(userName);
                if (roles.Length == 0)
                {
                    MessageBox.Show(
                        "Your login has expired. Please log in again to access " +
                        "the roles service.", "Attempting to access user roles...");

                    // Call ValidateUser with empty strings in order to 
                    // display the login dialog box configured as a 
                    // credentials provider.
                    if (!System.Web.Security.Membership.ValidateUser(
                        String.Empty, String.Empty))
                    {
                        MessageBox.Show("Unable to authenticate. " +
                            "Cannot retrieve user roles.", "Not logged in",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (provider.IsUserInRole(userName, "manager"))
                {
                    PerformManagerTask();
                }
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show(
                    "Unable to access the remote service. " +
                    "Cannot retrieve user roles.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //</snippet321>

        TextBox webSettingsTestTextBox = new TextBox();
        Label myLabel = new Label();

        private void SimpleWebSettings()
        {
            //<snippet322>
            webSettingsTestTextBox.Text =
                Properties.Settings.Default.WebSettingsTestText;
            //</snippet322>

            //<snippet323>
            Properties.Settings.Default.MySetting = "test";
            myLabel.Text = Properties.Settings.Default.MySetting;
            //</snippet323>

            //<snippet324>
            Properties.Settings.Default.Save();
            //</snippet324>
        }

    }
}

