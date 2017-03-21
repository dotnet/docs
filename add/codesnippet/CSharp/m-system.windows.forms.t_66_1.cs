        // This method defines the behavior of the MouseLeave event.
        // It sets the state of the rolloverValue field to false and
        // tells the control to repaint.
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            this.rolloverValue = false;

            this.Invalidate();
        }