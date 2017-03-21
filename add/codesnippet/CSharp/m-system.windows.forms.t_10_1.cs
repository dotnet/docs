        // The method defines the behavior of the Click event.
        // It simply toggles the state of the clickedValue field.
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            this.clickedValue ^= true;
        }