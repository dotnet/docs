// This is kind of a ripoff of 'process_synchronizingobject.cs' for use as a znippet
// for the remarks section.

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SynchronizingObjectTest
{
    public class SyncForm : Form
    {
        private System.ComponentModel.Container components = null;
        private Process process1;

        public SyncForm()
        {
            InitializeComponent();
        }

        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.button1 = new Button();
            this.label1 = new Label();
            this.SuspendLayout();
            //
            // button1
            //
            this.button1.Location = new System.Drawing.Point(20, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Click Me";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            //
            // textbox
            //
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "textbox1";
            this.label1.Size = new System.Drawing.Size(160, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Waiting for the process 'notepad' to exit....";
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Visible = false;
            //
            // Form1
            //
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(200, 70);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "SyncForm";
            this.Text = "SyncForm";
            this.ResumeLayout(false);
        }
        #endregion

        [STAThread]
        static void Main()
        {
            Application.Run(new SyncForm());
        }

        private Button button1;
        private Label label1;

        private void button1_Click(object sender, System.EventArgs e)
        {
            this.button1.Hide();
            this.label1.Show();

            process1 = new Process();
            ProcessStartInfo process1StartInfo= new ProcessStartInfo("notepad");

            // <Snippet2>
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // </Snippet2>

            // Set method handling the exited event to be called
            process1.Exited += new EventHandler(TheProcessExited);
            // Set 'EnableRaisingEvents' to true, to raise 'Exited' event when process is terminated.
            process1.EnableRaisingEvents = true;

            this.Refresh();
            process1.StartInfo = process1StartInfo;
            process1.Start();

            process1.WaitForExit();
            process1.Close();
        }

        private void TheProcessExited(Object source, EventArgs e)
        {
            this.label1.Hide();
            this.button1.Show();
            MessageBox.Show("The process has exited.");
        }
    }
}