            // Set the default BackColor.
            e.DataRepeaterItem.BackColor = Color.White;
            // Loop through the controls on the DataRepeaterItem.
            foreach (Control c in e.DataRepeaterItem.Controls)
            {
                // Check the type of each control.
                if (c is TextBox)
                // If a TextBox, change the BackColor.
                {
                    c.BackColor = Color.AliceBlue;
                }
                else
                {
                    // Otherwise use the default BackColor.
                    c.BackColor = e.DataRepeaterItem.BackColor;
                }
            }