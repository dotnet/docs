// <snippet1>
// <snippet7>
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
// </snippet7>

namespace BackgroundWorkerExample
{
    public class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // <snippet2>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Do not access the form's BackgroundWorker reference directly.
            // Instead, use the reference provided by the sender parameter.
            BackgroundWorker bw = sender as BackgroundWorker;

            // Extract the argument.
            int arg = (int)e.Argument;

            // Start the time-consuming operation.
            e.Result = TimeConsumingOperation(bw, arg);

            // If the operation was canceled by the user, 
            // set the DoWorkEventArgs.Cancel property to true.
            if (bw.CancellationPending)
            {
                e.Cancel = true;
            }
        }
        // </snippet2>

        // <snippet3>
        // This event handler demonstrates how to interpret 
        // the outcome of the asynchronous operation implemented
        // in the DoWork event handler.
        private void backgroundWorker1_RunWorkerCompleted(
            object sender, 
            RunWorkerCompletedEventArgs e)
        {   
            if (e.Cancelled)
            {
                // The user canceled the operation.
                MessageBox.Show("Operation was canceled");
            }
            else if (e.Error != null)
            {
                // There was an error during the operation.
                string msg = String.Format("An error occurred: {0}", e.Error.Message);
                MessageBox.Show(msg);
            }
            else
            {
                // The operation completed normally.
                string msg = String.Format("Result = {0}", e.Result);
                MessageBox.Show(msg);
            }
        }
        // </snippet3>

        // <snippet4>
        // This method models an operation that may take a long time 
        // to run. It can be cancelled, it can raise an exception,
        // or it can exit normally and return a result. These outcomes
        // are chosen randomly.
        private int TimeConsumingOperation( 
            BackgroundWorker bw, 
            int sleepPeriod )
        {
            int result = 0;

            Random rand = new Random();

            while (!bw.CancellationPending)
            {
                bool exit = false;

                switch (rand.Next(3))
                {
                    // Raise an exception.
                    case 0:
                    {
                        throw new Exception("An error condition occurred.");
                        break;
                    }

                    // Sleep for the number of milliseconds
                    // specified by the sleepPeriod parameter.
                    case 1:
                    {
                        Thread.Sleep(sleepPeriod);
                        break;
                    }

                    // Exit and return normally.
                    case 2:
                    {
                        result = 23;
                        exit = true;
                        break;
                    }

                    default:
                    {
                        break;
                    }
                }

                if( exit )
                {
                    break;
                }
            }

            return result;
        }
        // </snippet4>

        // <snippet5>
        private void startBtn_Click(object sender, EventArgs e)
        {
            this.backgroundWorker1.RunWorkerAsync(2000);
        }
        // </snippet5>

        // <snippet6>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.backgroundWorker1.CancelAsync();
        }
        // </snippet6>

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.startBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(12, 12);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "Start";
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(94, 11);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(183, 49);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.startBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button cancelBtn;
    }

    public class Program
    {
        private Program()
        {
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}
// </snippet1>