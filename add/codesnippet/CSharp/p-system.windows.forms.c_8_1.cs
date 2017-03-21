        // Draw the combo box in the current state.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!ComboBoxRenderer.IsSupported)
            {
                this.Parent.Text = "Visual Styles Disabled";
                return;
            }

            this.Parent.Text = "CustomComboBox Enabled";

            // Always draw the main text box and drop down arrow in their 
            // current states
            ComboBoxRenderer.DrawTextBox(e.Graphics, topTextBoxRectangle,
                this.Text, this.Font, textBoxState);
            ComboBoxRenderer.DrawDropDownButton(e.Graphics, arrowRectangle,
                arrowState);

            // Only draw the bottom text box if the arrow has been clicked
            if (isActivated)
            {
                ComboBoxRenderer.DrawTextBox(e.Graphics,
                    bottomTextBoxRectangle, bottomText, this.Font,
                    textBoxState);
            }
        }