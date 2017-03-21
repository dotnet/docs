        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Synchronize manual associations first.
            frmSettings1.FormText = this.Text + '.';
            frmSettings1.FormSize = this.Size;
            frmSettings1.Save();
        }