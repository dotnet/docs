        // Draw the check box in the current state.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            CheckBoxRenderer.DrawCheckBox(e.Graphics,
                ClientRectangle.Location, TextRectangle, this.Text,
                this.Font, TextFormatFlags.HorizontalCenter,
                clicked, state);
        }

        // Draw the check box in the checked or unchecked state, alternately.
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (!clicked)
            {
                clicked = true;
                this.Text = "Clicked!";
                state = CheckBoxState.CheckedPressed;
                Invalidate();
            }
            else
            {
                clicked = false;
                this.Text = "Click here";
                state = CheckBoxState.UncheckedNormal;
                Invalidate();
            }
        }