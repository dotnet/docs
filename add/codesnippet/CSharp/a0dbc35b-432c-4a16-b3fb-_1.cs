        private void RenderText5(PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, "Some text.",
                this.Font, new Point(10, 10), SystemColors.ControlText, TextFormatFlags.Bottom);
        }