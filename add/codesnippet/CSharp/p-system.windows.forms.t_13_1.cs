        // This method defines the behavior for rendering the
        // background of a ToolStripItem. If the item is a
        // RolloverItem, it paints the item's BackgroundImage 
        // centered in the client area. If the mouse is in the 
        // item's client area, a border is drawn around it.
        // If the item is on a drop-down or if it is on the
        // overflow, a gradient is painted in the background.
        protected override void OnRenderItemBackground(
            ToolStripItemRenderEventArgs e)
        {
            base.OnRenderItemBackground(e);

            RolloverItem item = e.Item as RolloverItem;

            // If the ToolSTripItem is of type RolloverItem, 
            // perform custom rendering for the background.
            if (item != null)
            {
                if (item.Placement == ToolStripItemPlacement.Overflow ||
                    item.IsOnDropDown)
                {
                    using (LinearGradientBrush b = new LinearGradientBrush(
                        item.ContentRectangle,
                        Color.Salmon,
                        Color.DarkRed,
                        0f,
                        false))
                    {
                        e.Graphics.FillRectangle(b, item.ContentRectangle);
                    }
                }

                // The RolloverItem control only supports 
                // the ImageLayout.Center setting for the
                // BackgroundImage property.
                if (item.BackgroundImageLayout == ImageLayout.Center)
                {
                    // Get references to the item's ContentRectangle
                    // and BackgroundImage, for convenience.
                    Rectangle cr = item.ContentRectangle;
                    Image bgi = item.BackgroundImage;

                    // Compute the center of the item's ContentRectangle.
                    int centerX = (cr.Width - bgi.Width) / 2;
                    int centerY = (cr.Height - bgi.Height) / 2;

                    // If the item is selected, draw the background
                    // image as usual. Otherwise, draw it as disabled.
                    if (item.Selected)
                    {
                        e.Graphics.DrawImage(bgi, centerX, centerY);
                    }
                    else
                    {
                        ControlPaint.DrawImageDisabled(
                                e.Graphics,
                                bgi,
                                centerX,
                                centerY,
                                item.BackColor);
                    }
                }

                // If the item is in the rollover state, 
                // draw a border around it.
                if (item.Rollover)
                {
                    ControlPaint.DrawFocusRectangle(
                        e.Graphics,
                        item.ContentRectangle);
                }
            }
        }