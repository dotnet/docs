        private void dataRepeater1_DrawItem(object sender, 
            Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            // Alternate the back color.
            if ((e.DataRepeaterItem.ItemIndex % 2) != 0)
            // Apply the secondary back color.
            {
                e.DataRepeaterItem.BackColor = Color.AliceBlue;
            }
            else
            {
                // Apply the default back color.
                e.DataRepeaterItem.BackColor = Color.White;
            }
            // Change the color of out-of-stock items to red.
            if (e.DataRepeaterItem.Controls["unitsInStockTextBox"].Text == "0")
            {
                e.DataRepeaterItem.Controls["unitsInStockTextBox"].BackColor = Color.Red;
            }
            else
            {
                e.DataRepeaterItem.Controls["unitsInStockTextBox"].BackColor = Color.White;
            }
        }