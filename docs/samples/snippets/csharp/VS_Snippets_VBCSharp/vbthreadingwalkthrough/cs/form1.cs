using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace ThreadingWalkthroughCS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // <snippet4>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        // This event handler is called when the background thread finishes.
        // This method runs on the main thread.
        if (e.Error != null)
            MessageBox.Show("Error: " + e.Error.Message);
        else if (e.Cancelled)
            MessageBox.Show("Word counting canceled.");
        else
            MessageBox.Show("Finished counting words.");
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // This method runs on the main thread.
            Words.CurrentState state =
                (Words.CurrentState)e.UserState;
            this.LinesCounted.Text = state.LinesCounted.ToString();
            this.WordsCounted.Text = state.WordsMatched.ToString();
        }
        // </snippet4>

        // <snippet6>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // This event handler is where the actual work is done.
            // This method runs on the background thread.

            // Get the BackgroundWorker object that raised this event.
            System.ComponentModel.BackgroundWorker worker;
            worker = (System.ComponentModel.BackgroundWorker)sender;

            // Get the Words object and call the main method.
            Words WC = (Words)e.Argument;
            WC.CountWords(worker, e);
        }

        private void StartThread()
        {
            // This method runs on the main thread.
            this.WordsCounted.Text = "0";

            // Initialize the object that the background worker calls.
            Words WC = new Words();
            WC.CompareString = this.CompareString.Text;
            WC.SourceFile = this.SourceFile.Text;

            // Start the asynchronous operation.
            backgroundWorker1.RunWorkerAsync(WC);
        }
        // </snippet6>


        // <snippet8>
        private void Start_Click(object sender, EventArgs e)
        {
            StartThread();
        }
        // </snippet8>


        // <snippet10>
        private void Cancel_Click(object sender, EventArgs e)
        {
            // Cancel the asynchronous operation.
            this.backgroundWorker1.CancelAsync();
        }
        // </snippet10>

    }
}
