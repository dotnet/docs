        void Form1_DoubleClick(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(20000, "Information", "This is the text",
                ToolTipIcon.Info );
        }