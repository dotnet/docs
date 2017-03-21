        // Draw the large or small button, depending on the current state.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw the smaller pressed button image
            if (state == PushButtonState.Pressed)
            {
                // Set the background color to the parent if visual styles  
                // are disabled, because DrawParentBackground will only paint  
                // over the control background if visual styles are enabled.
                this.BackColor = Application.RenderWithVisualStyles ?
                    Color.Azure : this.Parent.BackColor;

                // If you comment out the call to DrawParentBackground, 
                // the background of the control will still be visible 
                // outside the pressed button, if visual styles are enabled.
                ButtonRenderer.DrawParentBackground(e.Graphics,
                    ClientRectangle, this);
                ButtonRenderer.DrawButton(e.Graphics, ClickRectangle,
                    this.Text, this.Font, true, state);
            }

            // Draw the bigger unpressed button image.
            else
            {
                ButtonRenderer.DrawButton(e.Graphics, ClientRectangle,
                    this.Text, this.Font, false, state);
            }
        }

        // Draw the smaller pressed button image.
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.Text = "Clicked!";
            state = PushButtonState.Pressed;
            Invalidate();
        }

        // Draw the button in the hot state. 
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.Text = "Click here";
            state = PushButtonState.Hot;
            Invalidate();
        }

        // Draw the button in the unpressed state.
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.Text = "Click here";
            state = PushButtonState.Normal;
            Invalidate();
        }