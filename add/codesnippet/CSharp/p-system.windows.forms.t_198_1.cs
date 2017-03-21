        protected override void OnRenderItemImage(
            ToolStripItemImageRenderEventArgs e)
        {
            base.OnRenderItemImage(e);

            RolloverItem item = e.Item as RolloverItem;

            // If the ToolSTripItem is of type RolloverItem, 
            // perform custom rendering for the image.
            if (item != null)
            {
                if (item.Clicked)
                {
                    // The item is in the clicked state, so 
                    // draw the image as usual.
                    e.Graphics.DrawImage(
                        e.Image,
                        e.ImageRectangle.X,
                        e.ImageRectangle.Y);
                }
                else
                {
                    // In the unclicked state, gray out the image.
                    ControlPaint.DrawImageDisabled(
                        e.Graphics,
                        e.Image,
                        e.ImageRectangle.X,
                        e.ImageRectangle.Y,
                        item.BackColor);
                }
            }
        }