// <snippet1>

using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace SoundApiExample
{
    public class SoundTestForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox filepathTextbox;        
        private System.Windows.Forms.Button playOnceSyncButton;
        private System.Windows.Forms.Button playOnceAsyncButton;
        private System.Windows.Forms.Button playLoopAsyncButton;
        private System.Windows.Forms.Button selectFileButton;
        
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.Button loadSyncButton;
        private System.Windows.Forms.Button loadAsyncButton;        
        private SoundPlayer player;

        public SoundTestForm()
        {
            // Initialize Forms Designer generated code.
            InitializeComponent();
			
            // Disable playback controls until a valid .wav file 
            // is selected.
            EnablePlaybackControls(false);

            // Set up the status bar and other controls.
            InitializeControls();

            // Set up the SoundPlayer object.
            InitializeSound();
        }

        // Sets up the status bar and other controls.
        private void InitializeControls()
        {
            // Set up the status bar.
            StatusBarPanel panel = new StatusBarPanel();
            panel.BorderStyle = StatusBarPanelBorderStyle.Sunken;
            panel.Text = "Ready.";
            panel.AutoSize = StatusBarPanelAutoSize.Spring;
            this.statusBar.ShowPanels = true;
            this.statusBar.Panels.Add(panel);
        }

        // Sets up the SoundPlayer object.
        private void InitializeSound()
        {
            // Create an instance of the SoundPlayer class.
            player = new SoundPlayer();

            // Listen for the LoadCompleted event.
            player.LoadCompleted += new AsyncCompletedEventHandler(player_LoadCompleted);

            // Listen for the SoundLocationChanged event.
            player.SoundLocationChanged += new EventHandler(player_LocationChanged);
        }

        private void selectFileButton_Click(object sender, 
            System.EventArgs e)
        {
            // Create a new OpenFileDialog.
            OpenFileDialog dlg = new OpenFileDialog();

            // Make sure the dialog checks for existence of the 
            // selected file.
            dlg.CheckFileExists = true;

            // Allow selection of .wav files only.
            dlg.Filter = "WAV files (*.wav)|*.wav";
            dlg.DefaultExt = ".wav";

            // Activate the file selection dialog.
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file's path from the dialog.
                this.filepathTextbox.Text = dlg.FileName;

                // Assign the selected file's path to 
                // the SoundPlayer object.  
                player.SoundLocation = filepathTextbox.Text;
            }
        }

        // Convenience method for setting message text in 
        // the status bar.
        private void ReportStatus(string statusMessage)
        {
            // If the caller passed in a message...
            if ((statusMessage != null) && (statusMessage != String.Empty))
            {
                // ...post the caller's message to the status bar.
                this.statusBar.Panels[0].Text = statusMessage;
            }
        }
        
        // Enables and disables play controls.
        private void EnablePlaybackControls(bool enabled)
        {   
            this.playOnceSyncButton.Enabled = enabled;
            this.playOnceAsyncButton.Enabled = enabled;
            this.playLoopAsyncButton.Enabled = enabled;
            this.stopButton.Enabled = enabled;
        }
    
        private void filepathTextbox_TextChanged(object sender, 
            EventArgs e)
        {
            // Disable playback controls until the new .wav is loaded.
            EnablePlaybackControls(false);
        }

        private void loadSyncButton_Click(object sender, 
            System.EventArgs e)
        {   
            // Disable playback controls until the .wav is 
            // successfully loaded. The LoadCompleted event 
            // handler will enable them.
            EnablePlaybackControls(false);

            // <snippet2>
            try
            {
                // Assign the selected file's path to 
                // the SoundPlayer object.  
                player.SoundLocation = filepathTextbox.Text;

                // Load the .wav file.
                player.Load();
            }
            catch (Exception ex)
            {
                ReportStatus(ex.Message);
            }
            // </snippet2>
        }

        private void loadAsyncButton_Click(System.Object sender, 
            System.EventArgs e)
        {
            // Disable playback controls until the .wav is 
            // successfully loaded. The LoadCompleted event 
            // handler will enable them.
            EnablePlaybackControls(false);

            // <snippet3>
            try
            {
                // Assign the selected file's path to 
                // the SoundPlayer object.  
                player.SoundLocation = this.filepathTextbox.Text;

                // Load the .wav file.
                player.LoadAsync();
            }
            catch (Exception ex)
            {
                ReportStatus(ex.Message);
            }
            // </snippet3>
        }

        // Synchronously plays the selected .wav file once.
        // If the file is large, UI response will be visibly 
        // affected.
        private void playOnceSyncButton_Click(object sender, 
            System.EventArgs e)
        {	
            // <snippet4>
            ReportStatus("Playing .wav file synchronously.");
            player.PlaySync();
            ReportStatus("Finished playing .wav file synchronously.");
            // </snippet4>
        }

        // Asynchronously plays the selected .wav file once.
        private void playOnceAsyncButton_Click(object sender, 
            System.EventArgs e)
        {
            // <snippet5>
            ReportStatus("Playing .wav file asynchronously.");
            player.Play();
            // </snippet5>
        }

        // Asynchronously plays the selected .wav file until the user
        // clicks the Stop button.
        private void playLoopAsyncButton_Click(object sender, 
            System.EventArgs e)
        {
            // <snippet6>
            ReportStatus("Looping .wav file asynchronously.");
            player.PlayLooping();
            // </snippet6>
        }

        // Stops the currently playing .wav file, if any.
        private void stopButton_Click(System.Object sender,
            System.EventArgs e)
        {	
            // <snippet7>
            player.Stop();
            ReportStatus("Stopped by user.");
            // </snippet7>
        }

        // <snippet8>
        // Handler for the LoadCompleted event.
        private void player_LoadCompleted(object sender, 
            AsyncCompletedEventArgs e)
        {   
            string message = String.Format("LoadCompleted: {0}", 
                this.filepathTextbox.Text);
            ReportStatus(message);
            EnablePlaybackControls(true);
        }
        // </snippet8>

        // <snippet9>
        // Handler for the SoundLocationChanged event.
        private void player_LocationChanged(object sender, EventArgs e)
        {   
            string message = String.Format("SoundLocationChanged: {0}", 
                player.SoundLocation);
            ReportStatus(message);
        }
        // </snippet9>

        // <snippet10>
        private void playSoundFromResource(object sender, EventArgs e)
        {
            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream s = a.GetManifestResourceStream("<AssemblyName>.chimes.wav");
            SoundPlayer player = new SoundPlayer(s);
            player.Play();
        }
        // </snippet10>

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.filepathTextbox = new System.Windows.Forms.TextBox();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.loadSyncButton = new System.Windows.Forms.Button();
            this.playOnceSyncButton = new System.Windows.Forms.Button();
            this.playOnceAsyncButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.playLoopAsyncButton = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.loadAsyncButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // filepathTextbox
            // 
            this.filepathTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.filepathTextbox.Location = new System.Drawing.Point(7, 25);
            this.filepathTextbox.Name = "filepathTextbox";
            this.filepathTextbox.Size = new System.Drawing.Size(263, 20);
            this.filepathTextbox.TabIndex = 1;
            this.filepathTextbox.Text = "";
            this.filepathTextbox.TextChanged += new System.EventHandler(this.filepathTextbox_TextChanged);
            // 
            // selectFileButton
            // 
            this.selectFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectFileButton.Location = new System.Drawing.Point(276, 25);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(23, 21);
            this.selectFileButton.TabIndex = 2;
            this.selectFileButton.Text = "...";
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = ".wav path or URL:";
            // 
            // loadSyncButton
            // 
            this.loadSyncButton.Location = new System.Drawing.Point(7, 53);
            this.loadSyncButton.Name = "loadSyncButton";
            this.loadSyncButton.Size = new System.Drawing.Size(142, 23);
            this.loadSyncButton.TabIndex = 4;
            this.loadSyncButton.Text = "Load Synchronously";
            this.loadSyncButton.Click += new System.EventHandler(this.loadSyncButton_Click);
            // 
            // playOnceSyncButton
            // 
            this.playOnceSyncButton.Location = new System.Drawing.Point(7, 86);
            this.playOnceSyncButton.Name = "playOnceSyncButton";
            this.playOnceSyncButton.Size = new System.Drawing.Size(142, 23);
            this.playOnceSyncButton.TabIndex = 5;
            this.playOnceSyncButton.Text = "Play Once Synchronously";
            this.playOnceSyncButton.Click += new System.EventHandler(this.playOnceSyncButton_Click);
            // 
            // playOnceAsyncButton
            // 
            this.playOnceAsyncButton.Location = new System.Drawing.Point(149, 86);
            this.playOnceAsyncButton.Name = "playOnceAsyncButton";
            this.playOnceAsyncButton.Size = new System.Drawing.Size(147, 23);
            this.playOnceAsyncButton.TabIndex = 6;
            this.playOnceAsyncButton.Text = "Play Once Asynchronously";
            this.playOnceAsyncButton.Click += new System.EventHandler(this.playOnceAsyncButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(149, 109);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(147, 23);
            this.stopButton.TabIndex = 7;
            this.stopButton.Text = "Stop";
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // playLoopAsyncButton
            // 
            this.playLoopAsyncButton.Location = new System.Drawing.Point(7, 109);
            this.playLoopAsyncButton.Name = "playLoopAsyncButton";
            this.playLoopAsyncButton.Size = new System.Drawing.Size(142, 23);
            this.playLoopAsyncButton.TabIndex = 8;
            this.playLoopAsyncButton.Text = "Loop Asynchronously";
            this.playLoopAsyncButton.Click += new System.EventHandler(this.playLoopAsyncButton_Click);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 146);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(306, 22);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 9;
            this.statusBar.Text = "(no status)";
            // 
            // loadAsyncButton
            // 
            this.loadAsyncButton.Location = new System.Drawing.Point(149, 53);
            this.loadAsyncButton.Name = "loadAsyncButton";
            this.loadAsyncButton.Size = new System.Drawing.Size(147, 23);
            this.loadAsyncButton.TabIndex = 10;
            this.loadAsyncButton.Text = "Load Asynchronously";
            this.loadAsyncButton.Click += new System.EventHandler(this.loadAsyncButton_Click);
            // 
            // SoundTestForm
            // 
            this.ClientSize = new System.Drawing.Size(306, 168);
            this.Controls.Add(this.loadAsyncButton);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.playLoopAsyncButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.playOnceAsyncButton);
            this.Controls.Add(this.playOnceSyncButton);
            this.Controls.Add(this.loadSyncButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectFileButton);
            this.Controls.Add(this.filepathTextbox);
            this.MinimumSize = new System.Drawing.Size(310, 165);
            this.Name = "SoundTestForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Sound API Test Form";
            this.ResumeLayout(false);

        }
        #endregion
        
        [STAThread]
        static void Main()
        {
            Application.Run(new SoundTestForm());
        }
    }
}
// </snippet1>