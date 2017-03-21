        private void addGrandButton_Click(object sender, System.EventArgs e) {
            comboBox1.BeginUpdate();
            for (int i = 0; i < 1000; i++) {
                comboBox1.Items.Add("New Item " + i.ToString());
            }
            comboBox1.EndUpdate();
        }