        private void Form1_Click(object sender, EventArgs e)
        {
            Control ctl;
            ctl = (Control)sender;
            ctl.SelectNextControl(ActiveControl, true, true, true, true);
        }