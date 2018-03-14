
using System;
using System.Globalization;
using System.Data;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;
using System.ServiceProcess.Design;
using System.Management;
using System.Drawing;
using System.Windows.Forms;

namespace ServiceChangeSample
{

    public class ServiceChange
    {
        // Define the console application entry point.
        [STAThread]
        public static void ConsoleTestMain()
        {
            ServiceController sc = new ServiceController();

            Console.WriteLine("Query by service name or display name [S|D]:");
            String inputText = Console.ReadLine().ToUpper(CultureInfo.InvariantCulture);

            String serviceInput = "";

            switch (inputText)
            {
                case "S":
                    Console.WriteLine("Enter the service name:");
                    serviceInput = Console.ReadLine().ToLower(CultureInfo.InvariantCulture);
                    if (serviceInput.Length > 0)
                    {
                        sc.ServiceName = serviceInput;
                    }
                    break;
                case "D":
                    Console.WriteLine("Enter the service display name:");
                    serviceInput = Console.ReadLine();
                    if (serviceInput.Length > 0)
                    {
                        sc.DisplayName = serviceInput;
                    }
                    break;
                default:
                    // Quit if input was any other key.
                    break;
            }

            String scInfo;

            if (QueryService(ref sc, out scInfo))
            {
                Console.WriteLine(scInfo);

                Console.WriteLine("Would you like to change the service start mode [Y|N]:");
                inputText = Console.ReadLine().ToUpper(CultureInfo.InvariantCulture);

                if (inputText == "Y")
                {
                    Console.WriteLine("Enter the new start mode [Auto|Manual|Disabled]:");
                    serviceInput = Console.ReadLine().ToUpper(CultureInfo.InvariantCulture);

                    if (serviceInput.Length > 0)
                    {
                        ChangeServiceStartMode(ref sc, serviceInput, out scInfo);
                    }
                }
            }
        }

        public static bool QueryService(ref ServiceController sc, out String scInfo)
        {
            bool serviceValid = false;
            scInfo = "";

            try 
            {
                if ((sc.ServiceName.Length > 0) || 
                    (sc.DisplayName.Length > 0)   )
                {

                    sc.Refresh();

                    // Display information about this service.
                    scInfo += Environment.NewLine;
                    scInfo += String.Format("Service name:\t{0}", sc.ServiceName);
                    scInfo += Environment.NewLine;
                    scInfo += String.Format("Display name:\t{0}", sc.DisplayName);
                    scInfo += Environment.NewLine;
                    scInfo += String.Format("Service type:\t{0}", sc.ServiceType);
                    scInfo += Environment.NewLine;
                    scInfo += String.Format("Status:\t\t{0}", sc.Status);
                    scInfo += Environment.NewLine;

                    serviceValid = true;

                    // Query WMI for additional information about this service.
                    ManagementObject wmiService;
                    wmiService = new ManagementObject("Win32_Service.Name='" + sc.ServiceName + "'");
                    wmiService.Get();
                    scInfo += String.Format("Start name:\t{0}", wmiService["StartName"]);
                    scInfo += Environment.NewLine;
                    scInfo += String.Format("Start mode:\t{0}", wmiService["StartMode"]);
                    scInfo += Environment.NewLine;
                    scInfo += String.Format("Service path:\t{0}", wmiService["PathName"]);
                    scInfo += Environment.NewLine;
                    scInfo += String.Format("Description:\t{0}", wmiService["Description"]);
                    scInfo += Environment.NewLine;

                }
            }
            catch (InvalidOperationException)
            {
                serviceValid = false;
                scInfo = "";
            }
            
            return serviceValid;
        }

        public static bool ChangeServiceStartMode(ref ServiceController sc, String startMode, out String scInfo)
        {
            bool startModeChanged = false;
            ManagementObject wmiService;
            wmiService = new ManagementObject("Win32_Service.Name='" + sc.ServiceName + "'");
            wmiService.Get();
            String origStartMode = wmiService["StartMode"].ToString();
            
            scInfo = "";

            startMode = startMode.ToUpper(CultureInfo.InvariantCulture);

            if (startMode.Equals("AUTO") ||
                startMode.Equals("MANUAL") ||
                startMode.Equals("DISABLED")  )
            {
                if (startMode.Equals(origStartMode.ToUpper(CultureInfo.InvariantCulture)))
                {
                    scInfo += String.Format("Requested mode is the same as the current mode; no change necessary.");
                    scInfo += Environment.NewLine;
                }
                else {

                    // Change the start mode to requested value.
                    scInfo += String.Format("Setting service start mode to {0}...",
                        startMode);
                    scInfo += Environment.NewLine;

                        
                    // See Win32_Service schema for ChangeStartMode input values.
                    String [] startArgs = {startMode};

                    Object retVal;
                    retVal = wmiService.InvokeMethod("ChangeStartMode", startArgs);
                    if (retVal.ToString() != "0")
                    {
                        scInfo += String.Format("Warning:  Win32_Service.ChangeStartMode failed with return value {0}", 
                            retVal.ToString());
                        scInfo += Environment.NewLine;
                    }
                    else 
                    {
                        scInfo += String.Format("Service {0} start mode changed to {1}",
                            sc.ServiceName, startMode);
                        scInfo += Environment.NewLine;
                    }
                }
            }
            else 
            {
                scInfo += String.Format("Invalid start mode.");
                scInfo += Environment.NewLine;
            }
            return startModeChanged;
        }

        //<Snippet1>
        // Prompt the user for service installation account values.
        public static bool GetServiceAccount(ref ServiceProcessInstaller svcInst)
        {
            bool accountSet = false;
            ServiceInstallerDialog svcDialog = new ServiceInstallerDialog();

            // Query the user for the service account type.
            do
            {
                svcDialog.TopMost = true;
                svcDialog.ShowDialog();

                if (svcDialog.Result == ServiceInstallerDialogResult.OK)
                {
                    // Do a very simple validation on the user
                    // input.  Check to see whether the user name
                    // or password is blank.

                    if ((svcDialog.Username.Length > 0) &&
                        (svcDialog.Password.Length > 0)   )
                    {
                        // Use the account and password.
                        accountSet = true;

                        svcInst.Account = ServiceAccount.User;
                        svcInst.Username = svcDialog.Username;
                        svcInst.Password = svcDialog.Password;
                    }
                }
                else if (svcDialog.Result == ServiceInstallerDialogResult.UseSystem)
                {
                    svcInst.Account = ServiceAccount.LocalSystem;
                    svcInst.Username = null;
                    svcInst.Password = null;
                    accountSet  = true;
                }
                    
                if (!accountSet )
                {
                    // Display a message box.  Tell the user to
                    // enter a valid user and password, or cancel
                    // out to leave the service account alone.
                    DialogResult result;
                    result = MessageBox.Show("Invalid user name or password for service installation."+
                                             "  Press Cancel to leave the service account unchanged.",
                                             "Change Service Account", 
                                             MessageBoxButtons.OKCancel,
                                             MessageBoxIcon.Hand);

                    if (result == DialogResult.Cancel)
                    {
                        // Break out of loop.
                        break;
                    }
                }
            } while (!accountSet);

            return accountSet;
        }
        //</Snippet1>
    }

    public class ServiceSampleForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button query_button = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button startMode_button = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button changeMode_button = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button startName_button = new System.Windows.Forms.Button();
        private System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();

        private System.Windows.Forms.Label modeLabel = new System.Windows.Forms.Label();
        private System.Windows.Forms.ComboBox modeComboBox = new System.Windows.Forms.ComboBox();

        private ServiceController currentService = new ServiceController();
        
        private void query_button_Click(object sender, System.EventArgs e)
        {
            textBox.Text = "Querying service configuration...";

            String scInfo;
            currentService.DisplayName = "TelNet";

            if (ServiceChange.QueryService(ref currentService, out scInfo))
            {    
                textBox.Text = scInfo;

                this.startName_button.Enabled = true;
                this.startMode_button.Enabled = true;

                this.modeLabel.Visible = true;
                this.modeComboBox.Visible = true;
            }
            else 
            {
                textBox.Text = "Could not read configuration information for service.";
            }
        }

        private void startMode_button_Click(object sender, 
            System.EventArgs e)
        {
            String scInfo;
            String wmiStartMode = "";

            switch (this.modeComboBox.SelectedItem.ToString())
            {
                case "Automatic":
                    wmiStartMode = "Auto";
                    break;
                case "Manual":
                    wmiStartMode = "Manual";
                    break;
                case "Disabled":
                    wmiStartMode = "Disabled";
                    break;
            }

            if (ServiceChange.ChangeServiceStartMode(ref currentService, wmiStartMode, out scInfo))
            {            
                textBox.Text = "Service start mode updated successfully.";
            }
            else 
            {
                textBox.Text = scInfo;
            }
        }
        
        private void startName_button_Click(object sender, System.EventArgs e)
        {
            ServiceProcessInstaller svcProcInst = new ServiceProcessInstaller();

            textBox.Text = "Displaying service installer dialog...";

            if (ServiceChange.GetServiceAccount(ref svcProcInst))
            { 
                textBox.Text = "Changing the service account is not currently implemented in this application.";
            }
            else 
            {
                textBox.Text = "No change made to service account.";
            }

            String scInfo;
            if (ServiceChange.QueryService(ref currentService, out scInfo))
            {    
                textBox.Text += Environment.NewLine + scInfo;
            }
        }


        public ServiceSampleForm()
        {
            this.SuspendLayout();            

            // Set properties for query_button. 
            this.query_button.Enabled = true;
            this.query_button.Location = new System.Drawing.Point(8, 16);
            this.query_button.Name = "query_button";
            this.query_button.Size = new System.Drawing.Size(124, 30);            
            this.query_button.Text = "Query Service";
            this.query_button.Click += new System.EventHandler(this.query_button_Click);            
            
            // Set properties for startMode_button.
            this.startMode_button.Enabled = false;
            this.startMode_button.Location = new System.Drawing.Point(264, 16);
            this.startMode_button.Name = "startMode_button";
            this.startMode_button.Size = new System.Drawing.Size(124, 30);            
            this.startMode_button.Text = "Change Service Start Mode";
            this.startMode_button.Click += new System.EventHandler(this.startMode_button_Click);            
            // Set properties for modeLabel
            this.modeLabel.Location = new System.Drawing.Point(395, 20);
            this.modeLabel.Size = new Size(180, 22);
            this.modeLabel.Text = "Select a service mode:"; 
            this.modeLabel.Visible = false;
            // Set properties for modeComboBox
            this.modeComboBox.Location = new System.Drawing.Point(560, 16);
            this.modeComboBox.Size = new Size(190, 23);
            this.modeComboBox.Name = "modeComboBox";
            this.modeComboBox.Items.AddRange( new string[] { "Automatic", "Manual", "Disabled" } );
            this.modeComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left
                | System.Windows.Forms.AnchorStyles.Right 
                | System.Windows.Forms.AnchorStyles.Top;
            this.modeComboBox.SelectedIndex = 0;
            this.modeComboBox.Visible = false;

            // Set properties for startName_button.
            this.startName_button.Enabled = false;
            this.startName_button.Location = new System.Drawing.Point(136, 16);
            this.startName_button.Name = "startName_button";
            this.startName_button.Size = new System.Drawing.Size(124, 30);            
            this.startName_button.Text = "Change Service Account";
            this.startName_button.Click += new System.EventHandler(this.startName_button_Click);            

            // Set properties for textBox.        
            this.textBox.Anchor = (System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Bottom
                | System.Windows.Forms.AnchorStyles.Left 
                | System.Windows.Forms.AnchorStyles.Right);
            this.textBox.Location = new System.Drawing.Point(8, 48);
            this.textBox.Multiline = true;
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(744, 280);            
            this.textBox.Text = "";            
            
            // Set properties for the ServiceSampleForm.
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(768, 340);
            this.MinimumSize = new System.Drawing.Size(750, 340);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {this.textBox, 
                                    this.query_button, this.startMode_button, this.startName_button,
                                    this.modeComboBox, this.modeLabel });
            this.Name = "ServiceSampleForm";
            this.Text = "Query and Change Service Configuration";
            this.ResumeLayout(false);
        }

        protected override void Dispose( bool disposing )
        {
            base.Dispose( disposing );
        }

        // Define the windows application entry point.
        [STAThread]
        static void Main() 
        {
            Application.Run(new ServiceSampleForm());
        }
    }
}
