        // This utility method computes the layout of the 
        // RolloverItem control's image area and the text area.
        // For brevity, only the following settings are 
        // supported:
        //
        // ToolStripTextDirection.Horizontal
        // TextImageRelation.ImageBeforeText 
        // TextImageRelation.ImageBeforeText
        // 
        // It would not be difficult to support vertical text
        // directions and other image/text relationships.
        private void ComputeImageAndTextLayout()
        {
            Rectangle cr = base.ContentRectangle;
            Image img = base.Owner.ImageList.Images[base.ImageKey];

            // Compute the center of the item's ContentRectangle.
            int centerY = (cr.Height - img.Height) / 2;

            // Find the dimensions of the image and the text 
            // areas of the item. The text occupies the space 
            // not filled by the image. 
            if (base.TextImageRelation == TextImageRelation.ImageBeforeText &&
                base.TextDirection == ToolStripTextDirection.Horizontal)
            {
                imageRect = new Rectangle(
                    base.ContentRectangle.Left,
                    centerY,
                    base.Image.Width,
                    base.Image.Height);

                textRect = new Rectangle(
                    imageRect.Width,
                    base.ContentRectangle.Top,
                    base.ContentRectangle.Width - imageRect.Width,
                    base.ContentRectangle.Height);
            }
            else if (base.TextImageRelation == TextImageRelation.TextBeforeImage &&
                     base.TextDirection == ToolStripTextDirection.Horizontal)
            {
                imageRect = new Rectangle(
                    base.ContentRectangle.Right - base.Image.Width,
                    centerY,
                    base.Image.Width,
                    base.Image.Height);

                textRect = new Rectangle(
                    base.ContentRectangle.Left,
                    base.ContentRectangle.Top,
                    imageRect.X,
                    base.ContentRectangle.Bottom);
            }
        }