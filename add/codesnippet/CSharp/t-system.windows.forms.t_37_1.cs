        // This class implements a custom ToolStripRenderer for the 
        // GridStrip control. It customizes three aspects of the 
        // GridStrip control's appearance: GridStrip border, 
        // ToolStripButton border, and ToolStripButton image.
        internal class GridStripRenderer : ToolStripRenderer
        {   
            // The style of the empty cell's text.
            private static StringFormat style = new StringFormat();

            // The thickness (width or height) of a 
            // ToolStripButton control's border.
            static int borderThickness = 2;

            // The main bitmap that is the source for the 
            // subimagesthat are assigned to individual 
            // ToolStripButton controls.
            private Bitmap bmp = null;

            // The brush that paints the background of 
            // the GridStrip control.
            private Brush backgroundBrush = null;

            // This is the static constructor. It initializes the
            // StringFormat for drawing the text in the empty cell.
            static GridStripRenderer()
            {
                style.Alignment = StringAlignment.Center;
                style.LineAlignment = StringAlignment.Center;
            }

            // This method initializes the GridStripRenderer by
            // creating the image that is used as the source for
            // the individual button images.
            protected override void Initialize(ToolStrip ts)
            {
                base.Initialize(ts);

                this.InitializeBitmap(ts);
            }

            // This method initializes an individual ToolStripButton
            // control. It copies a subimage from the GridStripRenderer's
            // main image, according to the position and size of 
            // the ToolStripButton.
            protected override void InitializeItem(ToolStripItem item)
            {
                base.InitializeItem(item);

                GridStrip gs = item.Owner as GridStrip;

                // The empty cell does not receive a subimage.
                if ((item is ToolStripButton) &&
                    (item != gs.EmptyCell))
                {
                    // Copy the subimage from the appropriate 
                    // part of the main image.
                    Bitmap subImage = bmp.Clone(
                        item.Bounds,
                        PixelFormat.Undefined);

                    // Assign the subimage to the ToolStripButton
                    // control's Image property.
                    item.Image = subImage;
                }
            }

            // This utility method creates the main image that
            // is the source for the subimages of the individual 
            // ToolStripButton controls.
            private void InitializeBitmap(ToolStrip toolStrip)
            {
                // Create the main bitmap, into which the image is drawn.
                this.bmp = new Bitmap(
                    toolStrip.Size.Width,
                    toolStrip.Size.Height);

                // Draw a fancy pattern. This could be any image or drawing.
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    // Draw smoothed lines.
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    
                    // Draw the image. In this case, it is 
                    // a number of concentric ellipses. 
                    for (int i = 0; i < toolStrip.Size.Width; i += 8)
                    {
                        g.DrawEllipse(Pens.Blue, 0, 0, i, i);
                    }
                }
            }

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
        }