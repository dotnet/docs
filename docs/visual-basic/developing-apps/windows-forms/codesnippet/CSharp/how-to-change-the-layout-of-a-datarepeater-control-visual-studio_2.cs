        private void dataRepeater1_LayoutStyleChanged_1(object sender, EventArgs e)
        {
            // Call a method to re-initialize the template.
            dataRepeater1.BeginResetItemTemplate();
            if (dataRepeater1.LayoutStyle == DataRepeaterLayoutStyles.Vertical)
            // Change the height of the template and rearrange the controls.
            {
                dataRepeater1.ItemTemplate.Height = 150;
                dataRepeater1.ItemTemplate.Controls["TextBox1"].Location = new Point(20, 40);
                dataRepeater1.ItemTemplate.Controls["TextBox2"].Location = new Point(150, 40);
            }
            else
            {
                // Change the width of the template and rearrange the controls.
                dataRepeater1.ItemTemplate.Width = 150;
                dataRepeater1.ItemTemplate.Controls["TextBox1"].Location = new Point(40, 20);
                dataRepeater1.ItemTemplate.Controls["TextBox2"].Location = new Point(40, 150);
            }
            // Apply the changes to the template.
            dataRepeater1.EndResetItemTemplate();
        }