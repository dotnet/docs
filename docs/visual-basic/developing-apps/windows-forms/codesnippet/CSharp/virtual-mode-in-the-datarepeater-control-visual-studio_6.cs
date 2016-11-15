        private void Text_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtFirstName.Text == "")
            {
                MessageBox.Show("Please enter a name.");
                e.Cancel = true;
            }
        }