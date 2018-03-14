            if (e.DataRepeaterItem.Controls[regionTextBox.Name].Text == "")
            {
                e.DataRepeaterItem.Controls["regionLabel"].ForeColor = Color.Red;
            }
            else
            {
                e.DataRepeaterItem.Controls["regionLabel"].ForeColor = Color.Black;
            }