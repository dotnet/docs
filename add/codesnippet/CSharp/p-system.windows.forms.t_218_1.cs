            // This method draws a border around the button's image. If the background
            // to be rendered belongs to the empty cell, a string is drawn. Otherwise,
            // a border is drawn at the edges of the button.
            protected override void OnRenderButtonBackground(
                ToolStripItemRenderEventArgs e)
            {
                base.OnRenderButtonBackground(e);

                // Define some local variables for convenience.
                Graphics g = e.Graphics;
                GridStrip gs = e.ToolStrip as GridStrip;
                ToolStripButton gsb = e.Item as ToolStripButton;

                // Calculate the rectangle around which the border is painted.
                Rectangle imageRectangle = new Rectangle(
                    borderThickness, 
                    borderThickness, 
                    e.Item.Width - 2 * borderThickness, 
                    e.Item.Height - 2 * borderThickness);

                // If rendering the empty cell background, draw an 
                // explanatory string, centered in the ToolStripButton.
                if (gsb == gs.EmptyCell)
                {
                    e.Graphics.DrawString(
                        "Drag to here",
                        gsb.Font, 
                        SystemBrushes.ControlDarkDark,
                        imageRectangle, style);
                }
                else
                {
                    // If the button can be a drag source, paint its border red.
                    // otherwise, paint its border a dark color.
                    Brush b = gs.IsValidDragSource(gsb) ? b = 
                        Brushes.Red : SystemBrushes.ControlDarkDark;

                    // Draw the top segment of the border.
                    Rectangle borderSegment = new Rectangle(
                        0, 
                        0, 
                        e.Item.Width, 
                        imageRectangle.Top);
                    g.FillRectangle(b, borderSegment);

                    // Draw the right segment.
                    borderSegment = new Rectangle(
                        imageRectangle.Right,
                        0,
                        e.Item.Bounds.Right - imageRectangle.Right,
                        imageRectangle.Bottom);
                    g.FillRectangle(b, borderSegment);

                    // Draw the left segment.
                    borderSegment = new Rectangle(
                        0,
                        0,
                        imageRectangle.Left,
                        e.Item.Height);
                    g.FillRectangle(b, borderSegment);

                    // Draw the bottom segment.
                    borderSegment = new Rectangle(
                        0,
                        imageRectangle.Bottom,
                        e.Item.Width,
                        e.Item.Bounds.Bottom - imageRectangle.Bottom);
                    g.FillRectangle(b, borderSegment);
                }
            }