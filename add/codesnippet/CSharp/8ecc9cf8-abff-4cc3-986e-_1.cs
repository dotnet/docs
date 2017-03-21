        // Use DrawText with the current TextFormatFlags.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (TextBoxRenderer.IsSupported)
            {
                TextBoxRenderer.DrawTextBox(e.Graphics, textBorder, this.Text,
                    this.Font, textRectangle, textFlags, TextBoxState.Normal);

                this.Parent.Text = "CustomTextBox Enabled";
            }
            else
            {
                this.Parent.Text = "CustomTextBox Disabled";
            }
        }