        private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ListBox1.SelectedIndex != -1)
            {
                textBox1.Text = ListBox1.SelectedValue.ToString();
                // If we also wanted to get the displayed text we could use
                // the SelectedItem item property:
                // string s = ((USState)ListBox1.SelectedItem).LongName;
            }
        }