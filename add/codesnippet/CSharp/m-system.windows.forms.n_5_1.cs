        private void SetBalloonTip()
        {
            notifyIcon1.Icon = SystemIcons.Exclamation;
            notifyIcon1.BalloonTipTitle = "Balloon Tip Title";
            notifyIcon1.BalloonTipText = "Balloon Tip Text.";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
            this.Click += new EventHandler(Form1_Click);
        }
        
        void Form1_Click(object sender, EventArgs e) 
        {
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(30000);

        }