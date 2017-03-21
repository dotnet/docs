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