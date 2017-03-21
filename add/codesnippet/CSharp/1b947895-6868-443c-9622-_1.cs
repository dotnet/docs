        // Draw the group box in the current state.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            GroupBoxRenderer.DrawGroupBox(e.Graphics, ClientRectangle,
                this.Text, this.Font, state);

            // Draw an additional inner border if visual styles are enabled.
            if (Application.RenderWithVisualStyles)
            {
                GroupBoxRenderer.DrawGroupBox(e.Graphics, innerRectangle, state);
            }
        }