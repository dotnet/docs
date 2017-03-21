        private void showColorValueLabels()
        {
            label1.Text = "Red value is : " + trackBar1.Value.ToString();
            label3.Text = "Green Value is : " + trackBar2.Value.ToString();
            label2.Text = "Blue Value is : " + trackBar3.Value.ToString();
        }
        private void trackBar_Scroll(object sender, System.EventArgs e)
        {
            System.Windows.Forms.TrackBar myTB;
            myTB = (System.Windows.Forms.TrackBar) sender ;
            panel1.BackColor = Color.FromArgb(trackBar1.Value,trackBar2.Value,trackBar3.Value);
            myTB.Text = "Value is " + myTB.Value.ToString();
            showColorValueLabels();
        }