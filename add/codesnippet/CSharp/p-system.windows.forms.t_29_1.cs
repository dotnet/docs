            // This method renders the GridStrip control's background.
            protected override void OnRenderToolStripBackground(
                ToolStripRenderEventArgs e)
            {
                base.OnRenderToolStripBackground(e);

                // This late initialization is a workaround. The gradient
                // depends on the bounds of the GridStrip control. The bounds 
                // are dependent on the layout engine, which hasn't fully
                // performed layout by the time the Initialize method runs.
                if (this.backgroundBrush == null)
                {
                    this.backgroundBrush = new LinearGradientBrush(
                       e.ToolStrip.ClientRectangle,
                       SystemColors.ControlLightLight,
                       SystemColors.ControlDark,
                       90,
                       true);
                }

                // Paint the GridStrip control's background.
                e.Graphics.FillRectangle(
                    this.backgroundBrush, 
                    e.AffectedBounds);
            }