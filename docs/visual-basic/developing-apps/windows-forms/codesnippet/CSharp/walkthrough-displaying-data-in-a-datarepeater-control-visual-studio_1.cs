            // Alternate the back color.
            if ((e.DataRepeaterItem.ItemIndex % 2) != 0)
            // Apply the secondary back color.
            {
                e.DataRepeaterItem.BackColor = Color.AliceBlue;
            }
            else
            {
                // Apply the default back color.
                e.DataRepeaterItem.BackColor = dataRepeater1.BackColor;
            }