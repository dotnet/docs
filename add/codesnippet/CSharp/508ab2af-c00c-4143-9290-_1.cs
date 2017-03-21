        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Ensure that visual styles are supported.
            if (!Application.RenderWithVisualStyles)
            {
                this.Text = "Visual styles are not enabled.";
                TextRenderer.DrawText(e.Graphics, this.Text,
                    this.Font, this.Location, this.ForeColor);
                return;
            }

            // Set the clip region to define the curved corners 
            // of the caption.
            SetClipRegion();

            // Draw each part of the window.
            foreach (KeyValuePair<string, VisualStyleElement> entry
                in windowElements)
            {
                if (SetRenderer(entry.Value))
                {
                    renderer.DrawBackground(e.Graphics,
                        elementRectangles[entry.Key]);
                }
            }

            // Draw the caption text.
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font,
                elementRectangles["windowCaption"], Color.White,
                TextFormatFlags.VerticalCenter |
                TextFormatFlags.HorizontalCenter);
        }