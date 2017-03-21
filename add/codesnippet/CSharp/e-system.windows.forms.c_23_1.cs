        // The following example displays the location of the form in screen coordinates
        // on the caption bar of the form.
        private void Form1_Move(object sender, System.EventArgs e)
        {
            this.Text = "Form screen position = " + this.Location.ToString();
        }