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

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            // Check whether the user clicked the arrow.
            if (arrowRectangle.Contains(e.Location) &&
                ComboBoxRenderer.IsSupported)
            {
                // Draw the arrow in the pressed state.
                arrowState = ComboBoxState.Pressed;

                // The user has activated the combo box.
                if (!isActivated)
                {
                    this.Text = "Clicked!";
                    textBoxState = ComboBoxState.Pressed;
                    isActivated = true;
                }

                // The user has deactivated the combo box.
                else
                {
                    this.Text = "Click here";
                    textBoxState = ComboBoxState.Normal;
                    isActivated = false;
                }

                // Redraw the control.
                Invalidate();
            }
        }