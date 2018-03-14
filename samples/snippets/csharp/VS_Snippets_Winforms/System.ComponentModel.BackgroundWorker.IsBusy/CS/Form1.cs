// <snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

public class Form1 : Form
{
    private BackgroundWorker backgroundWorker1;
    private Button downloadButton;
    private ProgressBar progressBar1;
    private XmlDocument document = null;

    public Form1()
    {
        InitializeComponent();

        // Instantiate BackgroundWorker and attach handlers to its
        // DowWork and RunWorkerCompleted events.
        backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
        backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
        backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
    }

    // <snippet2>
    private void downloadButton_Click(object sender, EventArgs e)
    {
        // Start the download operation in the background.
        this.backgroundWorker1.RunWorkerAsync();

        // Disable the button for the duration of the download.
        this.downloadButton.Enabled = false;

        // Once you have started the background thread you 
        // can exit the handler and the application will 
        // wait until the RunWorkerCompleted event is raised.

        // Or if you want to do something else in the main thread,
        // such as update a progress bar, you can do so in a loop 
        // while checking IsBusy to see if the background task is
        // still running.

        while (this.backgroundWorker1.IsBusy)
        {
            progressBar1.Increment(1);
            // Keep UI messages moving, so the form remains 
            // responsive during the asynchronous operation.
            Application.DoEvents();
        }
    }
    // </snippet2>

    // <snippet3>
    private void backgroundWorker1_DoWork(
        object sender,
        DoWorkEventArgs e)
    {
        document = new XmlDocument();

        // Uncomment the following line to
        // simulate a noticeable latency.
        //Thread.Sleep(5000);

        // Replace this file name with a valid file name.
        document.Load(@"http://www.tailspintoys.com/sample.xml");
    }
    // </snippet3>

    // <snippet4>
    private void backgroundWorker1_RunWorkerCompleted(
        object sender,
        RunWorkerCompletedEventArgs e)
    {
        // Set progress bar to 100% in case it's not already there.
        progressBar1.Value = 100;

        if (e.Error == null)
        {
            MessageBox.Show(document.InnerXml, "Download Complete");
        }
        else
        {
            MessageBox.Show(
                "Failed to download file",
                "Download failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        // Enable the download button and reset the progress bar.
        this.downloadButton.Enabled = true;
        progressBar1.Value = 0;
    }
    // </snippet4>

    #region Windows Form Designer generated code

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

    /// <summary>
    /// Required method for Designer support
    /// </summary>
    private void InitializeComponent()
    {
        this.downloadButton = new System.Windows.Forms.Button();
        this.progressBar1 = new System.Windows.Forms.ProgressBar();
        this.SuspendLayout();
        // 
        // downloadButton
        // 
        this.downloadButton.Location = new System.Drawing.Point(12, 12);
        this.downloadButton.Name = "downloadButton";
        this.downloadButton.Size = new System.Drawing.Size(100, 23);
        this.downloadButton.TabIndex = 0;
        this.downloadButton.Text = "Download file";
        this.downloadButton.UseVisualStyleBackColor = true;
        this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
        // 
        // progressBar1
        // 
        this.progressBar1.Location = new System.Drawing.Point(12, 50);
        this.progressBar1.Name = "progressBar1";
        this.progressBar1.Size = new System.Drawing.Size(100, 26);
        this.progressBar1.TabIndex = 1;
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(133, 104);
        this.Controls.Add(this.progressBar1);
        this.Controls.Add(this.downloadButton);
        this.Name = "Form1";
        this.Text = "Form1";
        this.ResumeLayout(false);

    }

    #endregion
}

static class Program
{
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
// </snippet1>