        // The following methods handle the CheckChanged event 
        // for all the radio buttons. Each method calls a utility
        // method to set the ToolStripDropDownDirection appropriately.

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.HandleRadioButton(sender, ToolStripDropDownDirection.AboveLeft);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.HandleRadioButton(sender, ToolStripDropDownDirection.AboveRight);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.HandleRadioButton(sender, ToolStripDropDownDirection.BelowLeft);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this.HandleRadioButton(sender, ToolStripDropDownDirection.BelowRight);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            this.HandleRadioButton(sender, ToolStripDropDownDirection.Default);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            this.HandleRadioButton(sender, ToolStripDropDownDirection.Left);
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            this.HandleRadioButton(sender, ToolStripDropDownDirection.Right);
        }

        // This utility method sets the DefaultDropDownDirection property.
        private void HandleRadioButton(object sender, ToolStripDropDownDirection direction)
        {
            RadioButton rb = sender as RadioButton;

            if (rb != null)
            {
                if (rb.Checked)
                {
                    this.dropDownDirection = direction;
                    this.contextMenuStrip1.DefaultDropDownDirection = direction;
                }
            }
        }