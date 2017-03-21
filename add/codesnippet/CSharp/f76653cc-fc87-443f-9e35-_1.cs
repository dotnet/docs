            // This method draws a border around the GridStrip control.
            protected override void OnRenderToolStripBorder(
                ToolStripRenderEventArgs e)
            {
                base.OnRenderToolStripBorder(e);

                ControlPaint.DrawFocusRectangle(
                    e.Graphics,
                    e.AffectedBounds,
                    SystemColors.ControlDarkDark,
                    SystemColors.ControlDarkDark);
            }