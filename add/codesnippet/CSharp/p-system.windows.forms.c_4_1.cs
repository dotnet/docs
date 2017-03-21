        private void findButton_Click(object sender, System.EventArgs e) {
            int index = comboBox1.FindString(textBox2.Text);
            comboBox1.SelectedIndex = index;
        }