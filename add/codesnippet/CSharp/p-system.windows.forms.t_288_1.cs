        // This method defines the painting behavior of the control.
        // It performs the following operations:
        //
        // Computes the layout of the item's image and text.
        // Draws the item's background image.
        // Draws the item's image.
        // Draws the item's text.
        //
        // Drawing operations are implemented in the 
        // RolloverItemRenderer class.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.Owner != null)
            {
                // Find the dimensions of the image and the text 
                // areas of the item. 
                this.ComputeImageAndTextLayout();

                // Draw the background. This includes drawing a highlighted 
                // border when the mouse is in the client area.
                ToolStripItemRenderEventArgs ea = new ToolStripItemRenderEventArgs(
                     e.Graphics,
                     this);
                this.Owner.Renderer.DrawItemBackground(ea);

                // Draw the item's image. 
                ToolStripItemImageRenderEventArgs irea =
                    new ToolStripItemImageRenderEventArgs(
                    e.Graphics,
                    this,
                    imageRect );
                this.Owner.Renderer.DrawItemImage(irea);

                // If the item is on a drop-down, give its
                // text a different highlighted color.
                Color highlightColor = 
                    this.IsOnDropDown ?
                    Color.Salmon : SystemColors.ControlLightLight;

                // Draw the text, and highlight it if the 
                // the rollover state is true.
                ToolStripItemTextRenderEventArgs rea =
                    new ToolStripItemTextRenderEventArgs(
                    e.Graphics,
                    this,
                    base.Text,
                    textRect,
                    this.rolloverValue ? highlightColor : base.ForeColor,
                    base.Font,
                    base.TextAlign);
                this.Owner.Renderer.DrawItemText(rea);
            }
        }