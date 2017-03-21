        private void button1_Click(object sender, EventArgs e)
        {
            if (binding1.SupportsSearching != true)
                MessageBox.Show("Cannot search the list.");
            else
            {
                int foundIndex = binding1.Find("Name", textBox1.Text);
                if (foundIndex > -1)
                    listBox1.SelectedIndex = foundIndex;
                else
                    MessageBox.Show("Font was not found.");
            }
        }