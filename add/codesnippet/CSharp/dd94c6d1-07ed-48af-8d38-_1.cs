        // Draw the radio button in the current state.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            RadioButtonRenderer.DrawRadioButton(e.Graphics,
                ClientRectangle.Location, TextRectangle, this.Text,
                this.Font, clicked, state);
        }

        // Draw the radio button in the checked or unchecked state.
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (!clicked)
            {
                clicked = true;
                this.Text = "Clicked!";
                state = RadioButtonState.CheckedPressed;
                Invalidate();
            }
            else
            {
                clicked = false;
                this.Text = "Click here";
                state = RadioButtonState.UncheckedNormal;
                Invalidate();
            }
        }