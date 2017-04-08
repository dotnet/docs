//<Snippet1>
using System;
using System.ServiceProcess;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.ComponentModel;
using System.Configuration.Install;

namespace SimpleServiceCs
{
    public class SimpleService : ServiceBase
    {
        static void Main(string[] args)
        {
            ServiceBase.Run(new SimpleService());
        }

        protected override void OnStart(string[] args)
        {
            EventLog.WriteEntry("SimpleService", "Starting SimpleService");
            new Thread(RunMessagePump).Start();
        }

        void RunMessagePump()
        {
            EventLog.WriteEntry("SimpleService.MessagePump", "Starting SimpleService Message Pump");
            Application.Run(new HiddenForm());
        }

        protected override void OnStop()
        {
            Application.Exit();
        }
    }

    public partial class HiddenForm : Form
    {
        public HiddenForm()
        {
            InitializeComponent();
        }

        private void HiddenForm_Load(object sender, EventArgs e)
        {
            SystemEvents.TimeChanged += new EventHandler(SystemEvents_TimeChanged);
            SystemEvents.UserPreferenceChanged += new UserPreferenceChangedEventHandler(SystemEvents_UPCChanged);
        }

        private void HiddenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SystemEvents.TimeChanged -= new EventHandler(SystemEvents_TimeChanged);
            SystemEvents.UserPreferenceChanged -= new UserPreferenceChangedEventHandler(SystemEvents_UPCChanged);
        }

        private void SystemEvents_TimeChanged(object sender, EventArgs e)
        {
            EventLog.WriteEntry("SimpleService.TimeChanged", "Time changed; it is now " +
                DateTime.Now.ToLongTimeString());
        }

        private void SystemEvents_UPCChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            EventLog.WriteEntry("SimpleService.UserPreferenceChanged", e.Category.ToString());
        }
    }

    partial class HiddenForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(0, 0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HiddenForm";
            this.Text = "HiddenForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.HiddenForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HiddenForm_FormClosing);
            this.ResumeLayout(false);

        }
    }

    [RunInstaller(true)]
    public class SimpleInstaller : Installer
    {
        private ServiceInstaller serviceInstaller;
        private ServiceProcessInstaller processInstaller;

        public SimpleInstaller()
        {
            processInstaller = new ServiceProcessInstaller();
            serviceInstaller = new ServiceInstaller();

            // Service will run under system account
            processInstaller.Account = ServiceAccount.LocalSystem;

            // Service will have Start Type of Manual
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            serviceInstaller.ServiceName = "Simple Service";

            Installers.Add(serviceInstaller);
            Installers.Add(processInstaller);
        }
    }
}
//</Snippet1>
