        private void dataRepeater1_ItemCloned(object sender, 
            Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            ListBox Source = (ListBox)dataRepeater1.ItemTemplate.Controls["listBox1"];
            ListBox listBox1 = (ListBox)e.DataRepeaterItem.Controls["listBox1"];
            foreach (string s in Source.Items)
            {
                listBox1.Items.Add(s);
            }
        }