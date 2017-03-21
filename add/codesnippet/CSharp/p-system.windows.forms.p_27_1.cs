        // Draw the progress bar in its normal state.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (ProgressBarRenderer.IsSupported)
            {
                ProgressBarRenderer.DrawVerticalBar(e.Graphics,
                    ClientRectangle);
                this.Parent.Text = "VerticalProgressBar Enabled";
            }
            else
            {
                this.Parent.Text = "VerticalProgressBar Disabled";
            }
        }