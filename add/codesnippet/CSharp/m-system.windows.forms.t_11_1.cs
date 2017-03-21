        // This method defines the behavior of the MouseEnter event.
        // It sets the state of the rolloverValue field to true and
        // tells the control to repaint.
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            this.rolloverValue = true;

            this.Invalidate();
        }