        private void button2_Click(object sender, System.EventArgs e)
        {
            monthCalendar1.RemoveBoldedDate(DateTime.Parse(listBox1.SelectedItem.ToString().Substring(0,listBox1.SelectedItem.ToString().IndexOf(" "))));
            monthCalendar1.UpdateBoldedDates();
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            if(listBox1.Items.Count == 0)
                button3.Enabled = false;
        }