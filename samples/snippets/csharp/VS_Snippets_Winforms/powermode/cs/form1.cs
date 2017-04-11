using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace PowerMode1
{
    public partial class Form1 : Form
    {
        // <snippet1> 
        public Form1()
        {
            InitializeComponent();
            SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);
        }

        void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            switch (SystemInformation.PowerStatus.BatteryChargeStatus)
            {
                case System.Windows.Forms.BatteryChargeStatus.Low:
                    MessageBox.Show("Battery is running low.", "Low Battery", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case System.Windows.Forms.BatteryChargeStatus.Critical:
                    MessageBox.Show("Battery is critcally low.", "Critical Battery", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    break;              
                default:
                    // Battery is okay.
                    break;
            }
        }
        // </snippet1>
        
        private void Hibernate()
        {
            // <snippet2>
            if (SystemInformation.PowerStatus.BatteryChargeStatus == System.Windows.Forms.BatteryChargeStatus.Critical)
            {
                Application.SetSuspendState(PowerState.Hibernate, false, false);
            }
            // </snippet2>

        }
        
        [STAThread]
        static void Main() 
        {
            Application.Run(new Form1());
        }
    }

}
